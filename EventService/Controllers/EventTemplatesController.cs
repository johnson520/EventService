using System.Web.Http;
using EventService.Models;

namespace EventService.Controllers
{
    public class EventTemplatesController : ApiController
    {
        // GET api/<controller>
        public EventTemplates Get()
        {
            return new EventTemplates
            {
                { "Empty", SampleTemplates.EmptyTemplateQuestions },
                { "Default Template", SampleTemplates.DefaultTemplateQuestions },
                { "Sample", SampleTemplates.SampleTemplateQuestions }
            };
        }
    }
}
