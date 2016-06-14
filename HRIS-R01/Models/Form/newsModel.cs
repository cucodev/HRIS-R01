namespace HRIS_R01.Models.Form
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class newsModel : DbContext
    {
        public newsModel()
            : base("name=newsModel")
        {
        }

        public virtual DbSet<notifnew> notifnews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<notifnew>()
                .Property(e => e.title)
                .IsFixedLength();

            modelBuilder.Entity<notifnew>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<notifnew>()
                .Property(e => e.filepath)
                .IsUnicode(false);
        }
    }
}
