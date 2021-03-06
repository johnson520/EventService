//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventService.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecurrencePattern
    {
        public long TimeBlockID { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime WriteTime { get; set; }
        public int WriterIdentityID { get; set; }
        public byte Frequency { get; set; }
        public byte RepeatInterval { get; set; }
        public short MonthOfYear { get; set; }
        public short DayOfMonth { get; set; }
        public byte DaysOfWeek { get; set; }
        public short ByPosition { get; set; }
        public int StartTime { get; set; }
        public int Duration { get; set; }
        public byte EndType { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public short Instances { get; set; }
        public short RecurrenceTimeZoneCode { get; set; }
        public System.DateTime ModStartDate { get; set; }
        public string Facets { get; set; }
    
        public virtual TimeBlock TimeBlock { get; set; }
    }
}
