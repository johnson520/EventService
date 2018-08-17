using System.Web.Http;
using EventService.Models;
using Newtonsoft.Json;

namespace EventService.Controllers
{
    public class EventTemplatesController : ApiController
    {
        public EventTemplates Get()
        {
            return new EventTemplates
            {
                {"Empty", SampleTemplates.EmptyTemplateQuestions},
                {"Default Template", SampleTemplates.DefaultTemplateQuestions},
                {"Sample", SampleTemplates.SampleTemplateQuestions}
            };
        }

        [Route("api/templates/{calendar}")]
        [HttpGet]
        public EventTemplates GetForCalendar(string calendar)
        {
            switch (calendar.ToLowerInvariant())
            {
                case "apolloscalendar":
                    return new EventTemplates
                    {
                        {"Empty", SampleTemplates.EmptyTemplateQuestions},
                        {"Default Template", SampleTemplates.DefaultTemplateQuestions},
                        {"Sample", SampleTemplates.SampleTemplateQuestions}
                    };
                case "tedscalendar":
                    return JsonConvert.DeserializeObject<EventTemplates>(SampleTemplates.DefaultJson);
                default:
                    return new EventTemplates
                    {
                        {"Default Template", SampleTemplates.DefaultTemplateQuestions}
                    };
            }
        }
    }
}