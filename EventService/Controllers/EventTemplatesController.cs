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
            switch (calendar)
            {
                case "ApollosCalendar":
                    return new EventTemplates
                    {
                        {"Empty", SampleTemplates.EmptyTemplateQuestions},
                        {"Default Template", SampleTemplates.DefaultTemplateQuestions},
                        {"Sample", SampleTemplates.SampleTemplateQuestions}
                    };
                case "TedsCalendar":
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