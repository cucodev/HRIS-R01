namespace HRIS_R01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class emp_edu
    {
        public int ID { get; set; }

        public int IDV { get; set; }

        [Required]
        [StringLength(10)]
        public string UID { get; set; }

        public int? edu { get; set; }

        [StringLength(10)]
        public string Latest_Edu { get; set; }

        [StringLength(100)]
        public string Latest_Major { get; set; }

        [Required]
        [StringLength(10)]
        public string rowStatus { get; set; }

        public DateTime? lastUpdate { get; set; }

        public virtual emp_master emp_master { get; set; }
    }
}
