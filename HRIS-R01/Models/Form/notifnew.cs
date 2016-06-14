namespace HRIS_R01.Models.Form
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class notifnew
    {
        public int id { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public int? cattype { get; set; }

        [Column(TypeName = "text")]
        public string filepath { get; set; }

        public int? lastupdateby { get; set; }

        public TimeSpan? lastupdate { get; set; }
    }
}
