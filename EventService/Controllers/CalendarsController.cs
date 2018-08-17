using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Xml.Linq;
using EventService.Data;
using EventService.Models;

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
        [Route("api/xmltest")]
        public List<string> XmlTest()
        {
            var contacts = XElement.Parse(  
                @"<Contacts>  
        <Contact>  
            <Name>Patrick Hines</Name>  
            <Phone Type=""home"">206-555-0144</Phone>  
            <Phone type=""work"">425-555-0145</Phone>  
            <Address>  
            <Street1>123 Main St</Street1>  
            <City>Mercer Island</City>  
            <State>WA</State>  
            <Postal>68042</Postal>  
            </Address>  
            <NetWorth>10</NetWorth>  
        </Contact>  
        <Contact>  
            <Name>Gretchen Rivas</Name>  
            <Phone Type=""mobile"">206-555-0163</Phone>  
            <Address>  
            <Street1>123 Main St</Street1>  
            <City>Mercer Island</City>  
            <State>WA</State>  
            <Postal>68042</Postal>  
            </Address>  
            <NetWorth>11</NetWorth>  
        </Contact>  
    </Contacts>");

            return contacts.Elements("Contact").Select(c => c.Element("Name")?.Value).ToList();
        }
    }
}