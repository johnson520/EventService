using System;
using System.Collections.Generic;

namespace WebThunder.t2.DataModels
{
    public interface IEvent
    {
        long eventID { get; set; }
        int ownerCalendarID { get; set; }
        int[] alsoShowsOn { get; set; }
        string title { get; set; }
        string description { get; set; }
        string weblink { get; set; }
        DateTime startDateTime { get; set; }
        DateTime endDateTime { get; set; }
        bool allDay { get; set; }
        List<IFieldValue> fieldValues { get; set; }
    }
}