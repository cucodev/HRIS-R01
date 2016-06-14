using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_R01.Models.Common
{
    public class Common
    {
        public int idv { get; set; }
        public int empLev { get; set; }
        public int empDep { get; set; }
        public int empPos { get; set; }
        public int empDiv { get; set; }
        public int balanceMax { get; set; }
        public int balanceCurr { get; set; }
    }
}