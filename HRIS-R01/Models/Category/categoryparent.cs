namespace HRIS_R01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("categoryparent")]
    public partial class categoryparent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public categoryparent()
        {
            categories = new HashSet<category>();
        }

        public int id { get; set; }

        [StringLength(10)]
        public string uid { get; set; }

        [StringLength(10)]
        public string uidparent { get; set; }

        [StringLength(10)]
        public string uidtype { get; set; }

        [StringLength(50)]
        public string uidname { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<category> categories { get; set; }
    }
}
