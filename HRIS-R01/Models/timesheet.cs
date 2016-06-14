namespace HRIS_R01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("timesheet")]
    public partial class timesheet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? IDV { get; set; }

        public int? IDVAPPROVAL { get; set; }

        public DateTime? WORKIN { get; set; }

        public DateTime? WORKOUT { get; set; }

        public DateTime? WORKDURATION { get; set; }

        public DateTime? INADJUSTED { get; set; }

        public DateTime? OUTADJUSTED { get; set; }

        public DateTime? DATEADJUSTED { get; set; }

        public DateTime? DATEAPPROVED { get; set; }

        [StringLength(200)]
        public string REASON { get; set; }
    }
}
