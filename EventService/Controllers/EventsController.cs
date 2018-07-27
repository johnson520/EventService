using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using System.Web.Http;
using EventService.Models;
using Newtonsoft.Json;

namespace EventService.Controllers
{
    public class EventsController : ApiController
    {
        private static Dictionary<long, EventModel> _events;

        public IEnumerable<EventModel> GetEvents()
        {
            LoadEvents();
            return _events.Values;
        }

        [Route("api/event/{id}")]
        [HttpGet]
        public EventModel GetEvent(long id)
        {
            LoadEvents();
            return _events.TryGetValue(id, out var em) ? em : null;
        }
        
        [Route("api/testevent")]
        [HttpGet]
        public EventModel CreateTestEvent()
        {
            LoadEvents();

            var id = NextEventId();
            _events[id] = new EventModel() { eventDescription = $"Event #{id} created at {DateTime.Now.ToString()}", eventStartDate = $"{DateTime.Now:yyyy-MM-dd}", eventStartTime = $"{DateTime.Now:HH:mm}"};
            SaveEvents();

            return _events[id];
        }

        [Route("api/event")]
        [HttpPost]
        public EventModel CreateEvent([FromBody] EventModel em)
        {
            LoadEvents();

            var id = NextEventId();
            _events[id] = em;
            SaveEvents();

            return _events[id];
        }

        private static long NextEventId()
        {
            return _events.Count == 0 ? 1 : _events.Keys.Max(k => k) + 1;
        }

        private static void SaveEvents()
        {
            var path = HostingEnvironment.MapPath("/App_Data/events.json");

            if (path != null)
                File.WriteAllText(path, JsonConvert.SerializeObject(_events), Encoding.UTF8);
            else
                throw new Exception("Failed to MapPath /App_Data/events.json");
        }

        private static void LoadEvents()
        {
            if (_events != null)
                return;

            var path = HostingEnvironment.MapPath("/App_Data/events.json");

            if (path != null)
                try
                {
                    _events = JsonConvert.DeserializeObject<Dictionary<long, EventModel>>(File.ReadAllText(path, Encoding.UTF8));
                }
                catch (FileNotFoundException)
                {
                    _events = new Dictionary<long, EventModel>();
                }
            else
                throw new Exception("Failed to MapPath /App_Data/events.json");
        }
    }
}
