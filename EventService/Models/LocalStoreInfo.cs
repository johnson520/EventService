//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LocalStoreInfo
    {
        public System.DateTime CreationTime { get; set; }
        public System.DateTime WriteTime { get; set; }
        public int WriterIdentityID { get; set; }
        public string Name { get; set; }
        public short LocalStoreInfoFlags { get; set; }
        public int SchemaVersion { get; set; }
        public int DatabaseID { get; set; }
        public short NextMaintenanceType { get; set; }
        public System.DateTime NextMaintenanceStartTime { get; set; }
        public System.DateTime NextMaintenanceEndTime { get; set; }
    }
}
