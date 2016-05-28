namespace HRIS_R01.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ListCategory : DbContext
    {
        public ListCategory()
            : base("name=ListCategory")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<categoryparent> categoryparents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .Property(e => e.uid)
                .IsFixedLength();

            modelBuilder.Entity<category>()
                .Property(e => e.uidname)
                .IsFixedLength();

            modelBuilder.Entity<categoryparent>()
                .Property(e => e.uid)
                .IsFixedLength();

            modelBuilder.Entity<categoryparent>()
                .Property(e => e.uidparent)
                .IsFixedLength();

            modelBuilder.Entity<categoryparent>()
                .Property(e => e.uidtype)
                .IsFixedLength();

            modelBuilder.Entity<categoryparent>()
                .Property(e => e.uidname)
                .IsFixedLength();

            modelBuilder.Entity<categoryparent>()
                .HasMany(e => e.categories)
                .WithOptional(e => e.categoryparent)
                .HasForeignKey(e => e.uidparent);
        }
    }
}
