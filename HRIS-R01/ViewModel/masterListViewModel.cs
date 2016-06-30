using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HRIS_R01.Models.Session;

namespace HRIS_R01.ViewModel
{
    public class masterListViewModel
    {
        [Required]
        public int cID { get; set; }

        public string cUID { get; set; }
        public string cUIDParent { get; set; }
        public string cUIDType { get; set; }

        [Required]
        public string cUIDName { get; set; }
    }
}