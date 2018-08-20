using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using EventService.DBModel;
using EventService.Models;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace EventService.Data
{
    public static class StormHacks
    {
        private const string FieldDefOwnerEmail = "FieldDefOwner@grawgroup.com";

        private static int? FieldDefCalendarId()
        {
            return GetOwnedCalendars(FieldDefOwnerEmail).FirstOrDefault()?.CalendarID;
        }

        public static List<CustomField> GetCustomFields(List<int> calIds, bool includeSample)
        {
            if (includeSample)
            {
                var fieldDefCalendarId = FieldDefCalendarId();
                if (fieldDefCalendarId != null)
                    calIds.Add(fieldDefCalendarId.Value);
            }

            using (var db = new Storm11Entities())
            {
                var cfs = db.Database.SqlQuery<CustomFieldQueryResult>($@"
select
	ET.EventTypeID as eventTypeId
	, ET.Facets.value('(/DisplayName/text())[1]', 'nvarchar(MAX)') as eventTypeName
	, FD.FieldType as _fieldType
    , FD.Facets as _fdFacets
from EventTypes ET
	inner join EventTypeFieldDefs ETFD on ETFD.EventTypeID = ET.EventTypeID
	inner join FieldDefs FD on FD.FieldDefID = ETFD.FieldDefID
where ET.EventTypeFlags = 0 AND ET.Unlive = 0 AND FD.Unlive = 0 AND FD.OwnerCalendarID IN ({string.Join(",", calIds)})
order by ET.EventTypeID
").ToList().Select(qr => ParseFacets(qr, db)).ToList();

                return cfs;
            }
        }

        public static List<CalendarsOwned> GetOwnedCalendars(string email)
        {
            using (var db = new Storm11Entities())
            {
                return db.Database.SqlQuery<CalendarsOwned>(@"
SELECT
  CALS.CalendarID,
  CALS.DisplayName AS CalendarDisplayName,
  TempestViewSettings.value('(/EditorConfig/ShowPredefined/text())[1]', 'varchar(5)') AS _showPredefined
FROM [Storm11].[dbo].[Calendars] CALS
    INNER JOIN [Storm11].[dbo].[Identities] IDS
        ON IDS.IdentityID = CALS.OwnerIdentityID
WHERE IDS.EmailAddress = @email
    AND CALS.Unlive = 0",
                    new SqlParameter("@email", email)).ToList();
            }
        }

        public static string MakeKeyFromDisplayName(string s, string prefix = "")
        {
            return $"{prefix}{Regex.Replace(Regex.Replace(s, @"[^\w\s]+", string.Empty).Trim(), @"\s+(\S)", m => m.Groups[1].Value.ToUpperInvariant())}";
        }

        private static CustomField ParseFacets(CustomFieldQueryResult qr, Storm11Entities db)
        {
            int? IntCFValue(IEnumerable<XElement> xElements, int id)
            {
                return int.TryParse(xElements.FirstOrDefault(cf => (int) cf.Attribute("id") == id)?.Value, out var i) ? i : (int?) null;
            }

            decimal? DecimalCFValue(IEnumerable<XElement> xElements, int id)
            {
                return decimal.TryParse(xElements.FirstOrDefault(cf => (int) cf.Attribute("id") == id)?.Value, out var d) ? d : (decimal?) null;
            }

            bool BoolCFValue(IEnumerable<XElement> xElements, int id)
            {
                return bool.TryParse(xElements.FirstOrDefault(cf => (int) cf.Attribute("id") == id)?.Value, out var b) && b;
            }

            var facets = XElement.Parse($"<r>{qr._fdFacets}</r>");
            var cfs = facets.Elements("CF").ToList();
            var allowedValues = cfs.Where(cf => (int) cf.Attribute("id") == -1).Select(cf => new AllowedValue(cf.Value)).ToList();

            var assetDefId = IntCFValue(cfs, -11);
            if (assetDefId.HasValue)
                allowedValues.AddRange(db.Assets.Where(a => a.AssetDefID == assetDefId.Value).ToList().Select(a => new AllowedValue {key = a.AssetID.ToString(), value = a.DisplayName}));

            var result = new CustomField
            {
                eventTypeName = qr.eventTypeName,
                eventTypeId = qr.eventTypeId,
                fieldType = (FieldType) qr._fieldType,
                description = facets.Element("Description")?.Value,
                displayName = cfs.FirstOrDefault(cf => (int) cf.Attribute("id") == -3)?.Value,
                _defaultValue = cfs.FirstOrDefault(cf => (int) cf.Attribute("id") == -2)?.Value,
                minChars = IntCFValue(cfs, -4),
                maxChars = IntCFValue(cfs, -5),
                minValue = DecimalCFValue(cfs, -6),
                maxValue = DecimalCFValue(cfs, -7),
                required = BoolCFValue(cfs, -8),
                multipleValues = BoolCFValue(cfs, -9),
                allowedValues = allowedValues.Count > 0 ? allowedValues : null
            };

            return result;
        }

        public class CalendarsOwned
        {
            [JsonIgnore]
            public string _showPredefined { get; set; }

            public string CalendarDisplayName { get; set; }
            public int CalendarID { get; set; }
            public bool ShowPredefined => bool.TryParse(_showPredefined, out var b) && b;
        }

        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
        private class CustomFieldQueryResult
        {
            public string _fdFacets { get; set; }
            public short _fieldType { get; set; }
            public int eventTypeId { get; set; }
            public string eventTypeName { get; set; }
        }
    }
}