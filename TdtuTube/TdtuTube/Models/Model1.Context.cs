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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TdtuTubeEntities : DbContext
    {
        public TdtuTubeEntities()
            : base("name=TdtuTubeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AdminMenu> AdminMenus { get; set; }
        public virtual DbSet<HomeMenu> HomeMenus { get; set; }
        public virtual DbSet<HomeMenuType> HomeMenuTypes { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
    }
}
