using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebThunder.t2.DataModels
{
    public interface IModel
    {
        /// <summary>
        /// List of Templates that the user can select from.
        /// Changes based on which calendar is selected.
        /// </summary>
        List<ITemplate> templates { get; set; }

        /// <summary>
        /// List of owning calendars that user can pick from.  May also be used for also shows on list
        /// We might be able to globally cache this in the client?
        /// </summary>
        List<ICalendar> calendars { get; set; }

        /// <summary>
        /// Full details of the currently selected template including field definitions
        /// </summary>
        ITemplate currentTemplate { get; set; }

        /// <summary>
        /// Full details of the current calendar.  
        /// Not yet implemented.  Will have information such as time zone and whether to allow event time zones.
        /// We might be able to globally cache this in the client?
        /// </summary>
        ICalendar currentCalendar { get; set; }

        /// <summary>
        /// Full details of an event when editing an existing event.  Null when creating new events.
        /// </summary>
        IEvent currentEvent { get; set; }
    }
}