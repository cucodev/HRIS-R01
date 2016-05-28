namespace HRIS_R01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("category")]
    public partial class category
    {
        public int id { get; set; }

       // [ForeignKey]
        public int? uidparent { get; set; }

        [StringLength(10)]
        public string uid { get; set; }

        [StringLength(100)]
        public string uidname { get; set; }

        public virtual categoryparent categoryparent { get; set; }
    }
}
