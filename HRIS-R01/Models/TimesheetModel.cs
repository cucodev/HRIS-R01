namespace HRIS_R01.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TimesheetModel : DbContext
    {
        public TimesheetModel()
            : base("name=TimesheetModel")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<timesheet> timesheets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<timesheet>()
                .Property(e => e.REASON)
                .IsUnicode(false);
        }
    }
}
