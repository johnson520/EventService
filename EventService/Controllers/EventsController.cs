using System.Collections.Generic;
using System.Web.Http;

namespace EventService.Controllers
{
    public class EventsController : ApiController
    {
        public IEnumerable<string> GetEvents()
        {
            return new[] {"Event1", "Event2"};
        }
    }
}