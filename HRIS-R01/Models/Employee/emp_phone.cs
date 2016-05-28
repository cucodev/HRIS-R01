namespace HRIS_R01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class emp_phone
    {
        public int ID { get; set; }

        public int? IDV { get; set; }

        [Required]
        [StringLength(10)]
        public string UID { get; set; }

        [StringLength(20)]
        public string Phone1 { get; set; }

        [StringLength(20)]
        public string Phone2 { get; set; }

        [StringLength(20)]
        public string Phone3 { get; set; }

        [StringLength(20)]
        public string Phone4 { get; set; }

        [StringLength(200)]
        public string phone_temp { get; set; }

        [StringLength(10)]
        public string rowStatus { get; set; }

        public TimeSpan? lastUpdate { get; set; }

        public virtual emp_master emp_master { get; set; }
    }
}
