namespace HRIS_R01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class emp_contact
    {
        public int ID { get; set; }

        public int? IDV { get; set; }

        [Required]
        [StringLength(10)]
        public string UID { get; set; }

        [StringLength(300)]
        public string contact1 { get; set; }

        [StringLength(300)]
        public string contact2 { get; set; }

        [StringLength(300)]
        public string contact3 { get; set; }

        [StringLength(300)]
        public string contact4 { get; set; }

        public string contact_temp { get; set; }

        [StringLength(10)]
        public string rowStatus { get; set; }

        [StringLength(10)]
        public string lastUpdate { get; set; }

        public virtual emp_master emp_master { get; set; }
    }
}
