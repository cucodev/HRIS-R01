namespace HRIS_R01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class emp_birth
    {
        public int ID { get; set; }

        public int? IDV { get; set; }

        [Required]
        [StringLength(10)]
        public string UID { get; set; }

        [StringLength(20)]
        public string BIRTH_PLACE { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BIRTH_DATE { get; set; }

        public int? NATIONALITY { get; set; }

        [StringLength(10)]
        public string rowStatus { get; set; }

        [StringLength(10)]
        public string lastUpdate { get; set; }

        public virtual emp_master emp_master { get; set; }
    }
}
