//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TdtuTube.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subscribe
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int subscribe_user_id { get; set; }
        public Nullable<bool> subscribe_state { get; set; }
        public string meta { get; set; }
        public Nullable<bool> hide { get; set; }
        public Nullable<int> order { get; set; }
        public Nullable<System.DateTime> datebegin { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
