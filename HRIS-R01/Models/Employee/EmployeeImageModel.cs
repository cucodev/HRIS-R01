namespace HRIS_R01.Models.Employee
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeImageModel : DbContext
    {
        public EmployeeImageModel()
            : base("name=EmployeeImageModel")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<emp_image> emp_image { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
