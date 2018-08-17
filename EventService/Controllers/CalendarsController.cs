﻿using System.Collections.Generic;
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
            return StormHacks.GetOwnedCalendars(email);
        }

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
        public object GetSampleAssets()
        {
            return JsonConvert.DeserializeObject(SampleTemplates.LibraryAssets);
        }
    }
}