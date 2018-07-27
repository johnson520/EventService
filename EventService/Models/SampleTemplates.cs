using System.Linq;

namespace EventService.Models
{
    public static class SampleTemplates
    {
        public static readonly Question[] DefaultTemplateQuestions =
        {
            new Question("Event Image")
            {
                controlType = ControlType.imagepicker,
                options = new[]
                {
                    new Option("None"),
                    new Option { url = "https://www.trumba.com/images/trumba_logo_sm.gif", key = "trumba-logo", value = "Trumba" },
                    new Option { url = "http://wmgf.us/wp-content/uploads/2016/02/Washington_Huskies.png", key = "uw-huskies-logo", value = "Huskies" },
                    new Option
                    {
                        url = "https://static.nfl.com/static/content/public/static/wildcat/assets/img/logos/teams/SEA.svg",
                        key = "nfl-seahawks",
                        value = "Seahawks"
                    }
                },
                value = "none"
            },
            new Question("Audience")
            {
                key = "eventAudience",
                required = true,
                controlType = ControlType.multiselect,
                options = new[] { new Option("Adults"), new Option("Children"), new Option("Seniors"), new Option("Teens") },
                value = new string[0]
            },
            new Question("Event Type")
            {
                controlType = ControlType.multiselect,
                required = true,
                options = new[]
                {
                    new Option("Class"),
                    new Option("Exhibit"),
                    new Option("Festival"),
                    new Option("Job Fair"),
                    new Option("Meeting"),
                    new Option("Performance"),
                    new Option("Seminar"),
                    new Option("Tour"),
                    new Option("Trade Show"),
                    new Option("Webinar")
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
