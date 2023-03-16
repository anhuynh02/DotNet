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
    
    public partial class Video
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Video()
        {
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<Like>();
        }
    
        public int id { get; set; }
        public int user_id { get; set; }
        public int tag_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Nullable<int> like_count { get; set; }
        public Nullable<int> view_count { get; set; }
        public Nullable<int> comment_count { get; set; }
        public bool privacy { get; set; }
        public string length { get; set; }
        public string thumbnail { get; set; }
        public string path { get; set; }
        public bool feature { get; set; }
        public string meta { get; set; }
        public Nullable<bool> hide { get; set; }
        public Nullable<int> order { get; set; }
        public Nullable<System.DateTime> datebegin { get; set; }
        public bool status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like> Likes { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual User User { get; set; }
    }
}
