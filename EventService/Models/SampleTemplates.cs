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

        public static readonly Question[] EmptyTemplateQuestions = { };

        private static readonly Question[] SampleExtra =
        {
            new Question
            {
                defaultValue = null,
                key = "eventFeaturedEvent",
                displayName = "Featured event",
                required = false,
                order = 110,
                fieldType = FieldType.checkbox
            },
            new Question
            {
                defaultValue = "",
                key = "eventSubmitterPhone",
                displayName = "Submitter phone",
                required = false,
                order = 111,
                fieldType = FieldType.textbox,
                type = "tel"
            },
            new Question
            {
                defaultValue = "",
                key = "eventSubmitterEmail",
                displayName = "Submitter email",
                required = true,
                order = 112,
                fieldType = FieldType.textbox,
                type = "email"
            },
            new Question
            {
                defaultValue = "",
                key = "eventSubmitterName",
                displayName = "Submitter name",
                required = true,
                order = 113,
                fieldType = FieldType.textbox,
                type = "text"
            }
        };

        public static Question[] SampleTemplateQuestions => DefaultTemplateQuestions.Concat(SampleExtra).ToArray();

        public static Question[] DefaultTemplateQuestions =>
            new[]
            {
                new Question("Event Image")
                {
                    fieldType = FieldType.imagepicker,
                    allowedValues = DefaultEventImages.Concat(ImagesBlob.GetCustomImages()).ToArray(),
                    defaultValue = "none"
                },
                new Question("Audience")
                {
                    key = "eventAudience",
                    required = true,
                    fieldType = FieldType.multiselect,
                    allowedValues = new[] { new QOption("Adults"), new QOption("Children"), new QOption("Seniors"), new QOption("Teens") },
                    defaultValue = new string[0]
                },
                new Question("Event Type")
                {
                    fieldType = FieldType.multiselect,
                    required = true,
                    allowedValues = new[]
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
                    defaultValue = new string[0]
                }
            };
    }
}
