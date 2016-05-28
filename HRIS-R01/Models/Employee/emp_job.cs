namespace HRIS_R01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class emp_job
    {
        public int ID { get; set; }

        public int? IDV { get; set; }

        [Required]
        [StringLength(10)]
        public string UID { get; set; }

        public int? empStatus { get; set; }

        public int? empPosition { get; set; }

        public int? empJoblevel { get; set; }

        public int? empDivison { get; set; }

        public int? empDepartement { get; set; }

        [StringLength(10)]
        public string empCity { get; set; }

        [StringLength(10)]
        public string rowStatus { get; set; }

        public TimeSpan? lastUpdate { get; set; }

        public virtual emp_master emp_master { get; set; }
    }
}
