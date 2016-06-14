namespace HRIS_R01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("organization")]
    public partial class organization
    {
        public int ID { get; set; }

        public int? IDV { get; set; }

        public int? ParentIDV { get; set; }
    }
}
