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
    
    public partial class OutlookAppointment
    {
        public long TimeBlockID { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime WriteTime { get; set; }
        public int WriterIdentityID { get; set; }
        public string Categories { get; set; }
        public int Importance { get; set; }
        public int NoAging { get; set; }
        public int ReminderMinutesBeforeStart { get; set; }
        public int ReminderOverrideDefault { get; set; }
        public int ReminderPlaySound { get; set; }
        public int ReminderSet { get; set; }
        public string ReminderSoundFile { get; set; }
        public System.DateTime ReplyTime { get; set; }
    }
}
