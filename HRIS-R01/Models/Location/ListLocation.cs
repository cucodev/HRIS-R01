namespace HRIS_R01.Models.Location
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ListLocation : DbContext
    {
        public ListLocation()
            : base("name=ListLocation")
        {
        }

        public virtual DbSet<location> locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<location>()
                .Property(e => e.uidname)
                .IsUnicode(false);
        }
    }
}
