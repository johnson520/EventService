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
    
    public partial class VMember
    {
        public int CalendarID { get; set; }
        public int IdentityID { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayName { get; set; }
        public short MemberFlags { get; set; }
        public Nullable<short> AccountFlags { get; set; }
        public Nullable<short> AccountType { get; set; }
    }
}