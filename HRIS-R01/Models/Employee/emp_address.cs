namespace HRIS_R01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class emp_address
    {
        public int ID { get; set; }

        public int? IDV { get; set; }

        [StringLength(10)]
        public string UID { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Kelurahan { get; set; }

        public long? Kecamatan { get; set; }

        public long? Kabupaten { get; set; }

        public long? Provinsi { get; set; }

        public int? Country { get; set; }

        [StringLength(10)]
        public string rowStatus { get; set; }

        public virtual emp_master emp_master { get; set; }
    }
}
