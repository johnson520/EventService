using System.Linq;
using EventService.Data;

namespace EventService.Models
{
    public static class SampleTemplates
    {
        private static readonly QOption[] DefaultEventImages =
        {
            new QOption("None"),
            new QOption { url = "https://www.trumba.com/images/trumba_logo_sm.gif", key = "trumba-logo", value = "Trumba" },
            new QOption { url = "http://wmgf.us/wp-content/uploads/2016/02/Washington_Huskies.png", key = "uw-huskies-logo", value = "Huskies" },
            new QOption
            {
                url = "https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/SEA.svg",
                key = "nfl-seahawks",
                value = "Seahawks"
            }
        };

        public static readonly Question[] DefaultTemplateQuestions =
        {
            new Question("Event Image")
            {
                controlType = ControlType.imagepicker,
                options = DefaultEventImages,
                value = "none"
            },
            new Question("Audience")
            {
                key = "eventAudience",
                required = true,
                controlType = ControlType.multiselect,
                options = new[] { new QOption("Adults"), new QOption("Children"), new QOption("Seniors"), new QOption("Teens") },
                value = new string[0]
            },
            new Question("Event Type")
            {
                controlType = ControlType.multiselect,
                required = true,
                options = new[]
                {
                    new QOption("Class"),
                    new QOption("Exhibit"),
                    new QOption("Festival"),
                    new QOption("Job Fair"),
                    new QOption("Meeting"),
                    new QOption("Performance"),
                    new QOption("Seminar"),
                    new QOption("Tour"),
                    new QOption("Trade Show"),
                    new QOption("Webinar")
                },
                value = new string[0]
            }
        };

        public static readonly Question[] EmptyTemplateQuestions = { };

        private static readonly Question[] SampleExtra =
        {
            new Question
            {
                value = null,
                key = "eventFeaturedEvent",
                label = "Featured event",
                required = false,
                order = 110,
                controlType = ControlType.checkbox
            },
            new Question
            {
                value = "",
                key = "eventSubmitterPhone",
                label = "Submitter phone",
                required = false,
                order = 111,
                controlType = ControlType.textbox,
                type = "tel"
            },
            new Question
            {
                value = "",
                key = "eventSubmitterEmail",
                label = "Submitter email",
                required = true,
                order = 112,
                controlType = ControlType.textbox,
                type = "email"
            },
            new Question
            {
                value = "",
                key = "eventSubmitterName",
                label = "Submitter name",
                required = true,
                order = 113,
                controlType = ControlType.textbox,
                type = "text"
            }
        };

        public static readonly Question[] SampleTemplateQuestions = DefaultTemplateQuestions.Concat(SampleExtra).ToArray();
    }
}
