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
    
    public partial class CalendarTimeBlock
    {
        public int CalendarID { get; set; }
        public long TimeBlockID { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime WriteTime { get; set; }
        public int WriterIdentityID { get; set; }
        public short CalendarTimeBlockFlags { get; set; }
        public bool Unlive { get; set; }
        public byte Commitment { get; set; }
        public byte ReminderChannel { get; set; }
        public byte ReminderAnticipation { get; set; }
    
        public virtual Calendar Calendar { get; set; }
        public virtual TimeBlock TimeBlock { get; set; }
    }
}
