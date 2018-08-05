using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Web.Http;
using EventService.Data;
using EventService.Models;

namespace EventService.Controllers
{
    public class EventsController : ApiController
    {
        public List<EventModel> GetEvents()
        {
            return EventsTable.GetAll();
        }

        [Route("api/event/{id}")]
        [HttpGet]
        public EventModel GetEvent(long id)
        {
            return EventsTable.GetOne(id);
        }

        [Route("api/testevent")]
        [HttpGet]
        public EventModel CreateTestEvent()
        {
            return EventsTable.Create(new EventModel
            {
                eventTitle = $"Event created at {DateTime.Now.ToString()}",
                eventStartDate = $"{DateTime.Now:yyyy-MM-dd}",
                eventStartTime = $"{DateTime.Now:HH:mm}"
            });
        }

        [Route("api/event")]
        [HttpPost]
        public EventModel CreateEvent([FromBody] EventModel em)
        {
            if (em == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return EventsTable.Create(em);
        }

        [Route("api/image")]
        [HttpPost]
        public string AddCustomImage([FromBody] QOption cid)
        {
            if (cid == null || string.IsNullOrEmpty(cid.key) || string.IsNullOrEmpty(cid.value) || string.IsNullOrEmpty(cid.url))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return ImagesBlob.SaveCustomImage(cid);
        }

        [Route("api/event/{id}")]
        [HttpPut]
        public EventModel UpdateEvent(long id, [FromBody] EventModel em)
        {
            return EventsTable.Update(em);
        }
        
        [Route("api/event/{id}")]
        [HttpDelete]
        public bool DeleteEvent(long id)
        {
            return EventsTable.Delete(id);
        }
    }
}
