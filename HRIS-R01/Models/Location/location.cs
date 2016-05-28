namespace HRIS_R01.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("location")]
    public partial class location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        public long? uidparent { get; set; }

        public long? uidtype { get; set; }

        [StringLength(300)]
        public string uidname { get; set; }
    }
}
