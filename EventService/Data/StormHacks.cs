using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
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
                var cfs = db.Database.SqlQuery<CustomField>($@"
Select
	ET.EventTypeID as eventTypeId
	, ET.Facets.value('(/DisplayName/text())[1]', 'nvarchar(MAX)') as eventTypeName
	, FD.FieldType as _fieldType
	--, FD.OwnerCalendarID
	, FD.Facets.value('(/CF[@id=-3]/text())[1]', 'nvarchar(MAX)') as displayName
	, FD.Facets.value('(/Description/text())[1]', 'nvarchar(MAX)') as [description]
	, FD.Facets.value('(/CF[@id=-2]/text())[1]', 'nvarchar(MAX)') as _defaultValue
	, FD.Facets.value('(/CF[@id=-4]/text())[1]', 'int') as minChars
	, FD.Facets.value('(/CF[@id=-5]/text())[1]', 'int') as maxChars
	, FD.Facets.value('(/CF[@id=-6]/text())[1]', 'money') as minValue
	, FD.Facets.value('(/CF[@id=-7]/text())[1]', 'money') as maxValue
	, FD.Facets.value('(/CF[@id=-8]/text())[1]', 'varchar(5)') as [_required]
	, FD.Facets.value('(/CF[@id=-9]/text())[1]', 'varchar(5)') as [_multiple]
	, FD.Facets.value('(/CF[@id=-10]/text())[1]', 'nvarchar(max)') as displayStyle
	, dbo.AssetDisplayNames(FD.Facets.value('(/CF[@id=-11]/text())[1]', 'int')) as _assetDisplayNames
	, dbo.AllowedValues(CONVERT(nvarchar(max), FD.Facets.query('/CF[@id=-1]'))) as _allowedValues
    --, FD.Facets as _facets
from EventTypes ET
	inner join EventTypeFieldDefs ETFD on ETFD.EventTypeID = ET.EventTypeID
	inner join FieldDefs FD on FD.FieldDefID = ETFD.FieldDefID
where ET.EventTypeFlags = 0 AND ET.Unlive = 0 AND FD.Unlive = 0 AND FD.OwnerCalendarID IN ({string.Join(",", calIds)})
order by ET.EventTypeID
").ToList();

                return cfs;
            }
        }

/*
        private class CustomFieldQueryResult
        {
            public string _assetAllowedValues { get; set; }
            public int eventTypeId { get; set; }
            public string eventTypeName { get; set; }
            public string _facets { get; set; }
            public short _fieldType { get; set; }
        }


        private static CustomField ParseFacets(string facets)
        {
            var 

            var xFacets = XElement.Parse($"<r>{facets}</r>");

            var cfs = xFacets.Elements("CF").ToList();

            var allowedValues = cfs.Where(cf => (int) cf.Attribute("id") == -1).Select(cf => cf.Value).ToList();


        }
*/


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

        public static string MakeKeyFromDisplayName(string s)
        {
            return $"event{Regex.Replace(Regex.Replace(s, @"[^\w\s]+", string.Empty).Trim(), @"\s+(\S)", m => m.Groups[1].Value.ToUpperInvariant())}";
        }

        public class CalendarsOwned
        {
            [JsonIgnore]
            public string _showPredefined { get; set; }

            public string CalendarDisplayName { get; set; }
            public int CalendarID { get; set; }
            public bool ShowPredefined => bool.TryParse(_showPredefined, out var b) && b;
        }
    }
}