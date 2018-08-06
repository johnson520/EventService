using System.Linq;
using System.Web.Http;
using EventService.Data;
using EventService.Models;
using Newtonsoft.Json;

namespace EventService.Controllers
{
    public class EventTemplatesController : ApiController
    {
        private static readonly EventTemplates _defaultTemplates = new EventTemplates
        {
            { "Empty", SampleTemplates.EmptyTemplateQuestions },
            { "Default Template", SampleTemplates.DefaultTemplateQuestions },
            { "Sample", SampleTemplates.SampleTemplateQuestions }
        };

        // GET api/<controller>
        public EventTemplates Get()
        {
            var templates = JsonConvert.DeserializeObject<EventTemplates>(JsonConvert.SerializeObject(_defaultTemplates));
            var customImages = ImagesBlob.GetCustomImages();

            foreach (var template in templates.Values)
            {
                foreach (var question in template)
                {
                    if (question.controlType == ControlType.imagepicker)
                        question.options = question.options.Concat(customImages).ToArray();
                }
            }

            return templates;
        }
    }
}
