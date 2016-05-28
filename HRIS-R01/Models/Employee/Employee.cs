namespace HRIS_R01.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Employee : DbContext
    {
        public Employee()
            : base("name=HRISDBEmployee")

        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<emp_address> emp_address { get; set; }
        public virtual DbSet<emp_birth> emp_birth { get; set; }
        public virtual DbSet<emp_contact> emp_contact { get; set; }
        public virtual DbSet<emp_edu> emp_edu { get; set; }
        public virtual DbSet<emp_job> emp_job { get; set; }
        public virtual DbSet<emp_master> emp_master { get; set; }
        public virtual DbSet<emp_master_absence> emp_master_absence { get; set; }
        public virtual DbSet<emp_phone> emp_phone { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<emp_address>()
                .Property(e => e.UID)
                .IsFixedLength();

            modelBuilder.Entity<emp_address>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<emp_address>()
                .Property(e => e.Kelurahan)
                .IsFixedLength();

            modelBuilder.Entity<emp_address>()
                .Property(e => e.rowStatus)
                .IsFixedLength();

            modelBuilder.Entity<emp_birth>()
                .Property(e => e.UID)
                .IsFixedLength();

            modelBuilder.Entity<emp_birth>()
                .Property(e => e.BIRTH_PLACE)
                .IsFixedLength();

            modelBuilder.Entity<emp_birth>()
                .Property(e => e.rowStatus)
                .IsFixedLength();

            modelBuilder.Entity<emp_birth>()
                .Property(e => e.lastUpdate)
                .IsFixedLength();

            modelBuilder.Entity<emp_contact>()
                .Property(e => e.UID)
                .IsFixedLength();

            modelBuilder.Entity<emp_contact>()
                .Property(e => e.rowStatus)
                .IsFixedLength();

            modelBuilder.Entity<emp_contact>()
                .Property(e => e.lastUpdate)
                .IsFixedLength();

            modelBuilder.Entity<emp_edu>()
                .Property(e => e.UID)
                .IsFixedLength();

            modelBuilder.Entity<emp_edu>()
                .Property(e => e.Latest_Edu)
                .IsFixedLength();

            modelBuilder.Entity<emp_edu>()
                .Property(e => e.Latest_Major)
                .IsFixedLength();

            modelBuilder.Entity<emp_edu>()
                .Property(e => e.rowStatus)
                .IsFixedLength();

            modelBuilder.Entity<emp_job>()
                .Property(e => e.UID)
                .IsFixedLength();

            modelBuilder.Entity<emp_job>()
                .Property(e => e.empCity)
                .IsFixedLength();

            modelBuilder.Entity<emp_job>()
                .Property(e => e.rowStatus)
                .IsFixedLength();

            modelBuilder.Entity<emp_master>()
                .Property(e => e.UID)
                .IsFixedLength();

            modelBuilder.Entity<emp_master>()
                .Property(e => e.Religion)
                .IsFixedLength();

            modelBuilder.Entity<emp_master>()
                .Property(e => e.empStatus)
                .IsFixedLength();

            modelBuilder.Entity<emp_master>()
                .Property(e => e.rowStatus)
                .IsFixedLength();

            modelBuilder.Entity<emp_master>()
                .HasMany(e => e.emp_address)
                .WithOptional(e => e.emp_master)
                .HasForeignKey(e => e.IDV);

            modelBuilder.Entity<emp_master>()
                .HasMany(e => e.emp_birth)
                .WithOptional(e => e.emp_master)
                .HasForeignKey(e => e.IDV);

            modelBuilder.Entity<emp_master>()
                .HasMany(e => e.emp_contact)
                .WithOptional(e => e.emp_master)
                .HasForeignKey(e => e.IDV);

            modelBuilder.Entity<emp_master>()
                .HasMany(e => e.emp_edu)
                .WithRequired(e => e.emp_master)
                .HasForeignKey(e => e.IDV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<emp_master>()
                .HasMany(e => e.emp_job)
                .WithOptional(e => e.emp_master)
                .HasForeignKey(e => e.IDV);

            modelBuilder.Entity<emp_master>()
                .HasMany(e => e.emp_phone)
                .WithOptional(e => e.emp_master)
                .HasForeignKey(e => e.IDV);

            modelBuilder.Entity<emp_master_absence>()
                .Property(e => e.UID)
                .IsFixedLength();

            modelBuilder.Entity<emp_master_absence>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<emp_phone>()
                .Property(e => e.UID)
                .IsFixedLength();

            modelBuilder.Entity<emp_phone>()
                .Property(e => e.Phone1)
                .IsFixedLength();

            modelBuilder.Entity<emp_phone>()
                .Property(e => e.Phone2)
                .IsFixedLength();

            modelBuilder.Entity<emp_phone>()
                .Property(e => e.Phone3)
                .IsFixedLength();

            modelBuilder.Entity<emp_phone>()
                .Property(e => e.Phone4)
                .IsFixedLength();

            modelBuilder.Entity<emp_phone>()
                .Property(e => e.rowStatus)
                .IsFixedLength();
        }

        public System.Data.Entity.DbSet<HRIS_R01.Models.category> categories { get; set; }
    }
}
