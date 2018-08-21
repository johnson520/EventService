using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        private static readonly Uri qaTrumbaEndPoint = new Uri("https://www.qatrumba.com/api/t2/model");

        private static HttpClient httpClient;

        [HttpGet]
        [Route("api/trumbamodel")]
        public async Task<HttpResponseMessage> GetTrumbaModel([FromUri] int? calendarId = null, [FromUri] int? eventId = null)
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add(".THUNDERAUTH10",
                    "C7742EAFFA4BE2847560F10662E7B76F80E70A1A773059E64DE67142B434BE00484F688FF88C12381E7D3B791E545721138ACC11E8434013ADF5931E695C8C746A529E7F917B07BA5A47CF0A8191E0D12C8E7A8BCD4553A63189EE81A5C649853F449833CC8C337462F845BE8A1E21FB2D098F9B3959BAB316A3D7033632FCB34FE841DF2D89C37CE434A81BDF52212405AA1154");
            }

            var uriString = qaTrumbaEndPoint.AbsoluteUri;

            if (calendarId.HasValue)
                uriString += $"?calendarid={calendarId.Value}";

            if (eventId.HasValue)
                uriString += $"?calendarid={eventId.Value}";

            return await httpClient.GetAsync(new Uri(uriString));
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
        public string AddCustomImage([FromBody] AllowedValue cid)
        {
            if (cid == null || string.IsNullOrEmpty(cid.key) || string.IsNullOrEmpty(cid.value) || string.IsNullOrEmpty(cid.url))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return ImagesBlob.SaveCustomImage(cid);
        }

        [Route("api/images")]
        [HttpGet]
        public List<AllowedValue> GetCustomImages()
        {
            return ImagesBlob.GetCustomImages();
        }

        [Route("api/image/{filename}/{ext}")]
        [HttpDelete]
        public bool DeleteCustomImage(string filename, string ext)
        {
            return ImagesBlob.DeleteCustomImage($"{filename}.{ext}");
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
