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
    
    public partial class Partner
    {
        public int CalendarID { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime WriteTime { get; set; }
        public int WriterIdentityID { get; set; }
        public string ShortName { get; set; }
        public string DisplayName { get; set; }
        public short EnabledEventActions { get; set; }
        public string WebUrl { get; set; }
        public string LogoPath { get; set; }
        public string ValidationKey { get; set; }
        public string Settings { get; set; }
        public short SettingsVersion { get; set; }
    
        public virtual Calendar Calendar { get; set; }
    }
}