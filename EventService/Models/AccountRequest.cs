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
    
    public partial class AccountRequest
    {
        public int IdentityID { get; set; }
        public int InviterIdentityID { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime WriteTime { get; set; }
        public int WriterIdentityID { get; set; }
        public short AccountRequestType { get; set; }
        public short AccountRequestFlags { get; set; }
        public System.DateTime RequestTime { get; set; }
        public System.DateTime MailSentTime { get; set; }
        public System.DateTime FormStartTime { get; set; }
        public System.DateTime AccountCreationTime { get; set; }
        public string InviterMessage { get; set; }
        public string RequestUserAgent { get; set; }
    }
}
