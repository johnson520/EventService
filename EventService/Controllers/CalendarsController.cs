using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EventService.Data;
using EventService.Models;
using Newtonsoft.Json;

namespace EventService.Controllers
{
    public class CalendarsController : ApiController
    {
        [HttpGet]
        [Route("api/calendars")]
        public List<StormHacks.CalendarsOwned> GetCalendars([FromUri] string email)
        {
         //   return StormHacks.GetOwnedCalendars(email);
            return JsonConvert.DeserializeObject<List<StormHacks.CalendarsOwned>>(cals).Where(c => c.CalendarDisplayName != "Default Field Owner").ToList();
        }

        private const string cals = "[{\"CalendarDisplayName\":\"Apollo\'s Calendar\",\"CalendarID\":51,\"ShowPredefined\":false},{\"CalendarDisplayName\":\"Linda\'s Calendar\",\"CalendarID\":72,\"ShowPredefined\":true},{\"CalendarDisplayName\":\"Ted\'s Calendar\",\"CalendarID\":73,\"ShowPredefined\":false},{\"CalendarDisplayName\":\"Default Field Owner\",\"CalendarID\":74,\"ShowPredefined\":false},{\"CalendarDisplayName\":\"Matt\'s Calendar\",\"CalendarID\":75,\"ShowPredefined\":true},{\"CalendarDisplayName\":\"Ryan\'s Calendar\",\"CalendarID\":76,\"ShowPredefined\":true}]";

        [HttpGet]
        [Route("api/eventtypes/{calId}")]
        public Dictionary<string, List<CustomField>> GetEventTypes([FromUri] string email, int calId)
        {
            var calendars = StormHacks.GetOwnedCalendars(email).Where(c => c.CalendarID == calId).ToList();

            var eventTypes = StormHacks.GetCustomFields(calendars.Select(c => c.CalendarID).ToList(), calendars.Any(c => c.ShowPredefined));
            return eventTypes.GroupBy(et => et.eventTypeName).ToDictionary(g => g.Key, g=> g.ToList());
        }

        [HttpGet]
        [Route("api/assets")]
        public AssetsResponse GetSampleAssets()
        {
            return JsonConvert.DeserializeObject<AssetsResponse>(SampleTemplates.LibraryAssets);
        }
    }
}