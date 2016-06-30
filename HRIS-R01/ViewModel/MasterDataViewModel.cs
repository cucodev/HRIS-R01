using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRIS_R01.Models;
using HRIS_R01.Models.Session;
using System.ComponentModel.DataAnnotations;

namespace HRIS_R01.ViewModel
{
    public partial class CategoryViewModel
    {
        [Required]
        public int chield_id { get; set; }

        public Nullable<int> chield_uidparent { get; set; }
        public string chield_uid { get; set; }
        public string chield_uidname { get; set; }
    }

    public partial class CategoryParentViewModel
    {
        [Required]
        public int parent_id { get; set; }

        public string parent_uid { get; set; }
        public string parent_uidparent { get; set; }
        public string parent_uidtype { get; set; }
        public string parent_uidname { get; set; }
    }

    public partial class MasterDataViewModel
    {
        public List<MasterDataViewModel> MaintainMasterData { get; set; }
    }



}