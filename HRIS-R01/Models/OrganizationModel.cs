namespace HRIS_R01.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OrganizationModel : DbContext
    {
        public OrganizationModel()
            : base("name=OrganizationModel")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<organization> organizations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
