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
    
    public partial class Feedback
    {
        public int FeedbackID { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime WriteTime { get; set; }
        public int WriterIdentityID { get; set; }
        public int FeedbackType { get; set; }
        public int SubmitterIdentityID { get; set; }
        public System.DateTime SubmitTime { get; set; }
        public string Feedback1 { get; set; }
        public int ResponseState { get; set; }
        public System.DateTime ResponseTime { get; set; }
        public string Response { get; set; }
    }
}
