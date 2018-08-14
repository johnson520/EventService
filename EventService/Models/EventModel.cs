using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// ReSharper disable NotAccessedField.Global

// ReSharper disable UnusedMember.Global

namespace EventService.Models
{
    public class EventModel
    {
        public long eventId;

        public bool eventAllDay;
        public string eventDescription;
        public int eventDurationDays;
        public int eventDurationHours;
        public int eventDurationMinutes;
        public string eventLocation;
        public bool eventPrivate;

        [JsonConverter(typeof(StringEnumConverter))]
        public EventRepeat eventRepeat;

        //  move into structure for repeat
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string eventRepeatMonthlyOn;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string eventRepeatAnnuallyOn;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string eventRepeatDailyEvery;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string eventRepeatWeeklyEvery;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string eventRepeatMonthlyEvery;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] eventRepeatWeeklyDays;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string eventRepeatThru;

        public string eventStartDate;
        public string eventStartTime;
        public string eventTemplate;
        public string eventTitle;
        public string eventWebLink;

        public Dictionary<string, object> customFields;

        public string owningCalendar;
        public string[] alsoShowsOn;
    }

    public enum EventRepeat
    {
        None,
        Daily,
        Weekly,
        Monthly,
        Annually
    }
}
