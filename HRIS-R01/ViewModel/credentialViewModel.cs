using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HRIS_R01.Models.Employee;
using HRIS_R01.Models.Session;


namespace HRIS_R01.ViewModel
{
    
    public class credentialViewModel
    {

        [Required]
        public int cID { get; set; }

        public int cIDParent { get; set; }
        public int cIDParentLevel { get; set; }

        [Required]
        public string cNIP { get; set; }

        public Nullable<int> cUID_ABSENCE { get; set; }
        public string cName { get; set; }
        public string cNickName { get; set; }
        public Nullable<int> cEmpPosition { get; set; }
        public Nullable<int> cEmpJobLevel { get; set; }
        public Nullable<int> cEmpDivision { get; set; }
        public Nullable<int> cEmpDepartement { get; set; }
        public string cEmpOfficeLocation { get; set; }

        [Required]
        [Display(Name = "EMAIL")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address.")]
        public string cUser { get; set; }

        [Required]
        public DateTime cStart { get; set; }
        public DateTime cStop { get; set; }




        
    }
}