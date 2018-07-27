using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// ReSharper disable UnusedMember.Global

namespace EventService.Models
{
    public class EventModel
    {
        public bool eventAllDay;
        public string eventDescription;
        public int eventDurationDays;
        public int eventDurationHours;
        public int eventDurationMinutes;
        public string eventLocation;
        public bool eventPrivate;

        [JsonConverter(typeof(StringEnumConverter))]
        public EventRepeat eventRepeat;

        public string eventStartDate;
        public string eventStartTime;
        public string eventTemplate;
        public string eventTitle;
        public string eventWebLink;

        public Dictionary<string, object> customFields;
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
