using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IASHandyMan.Areas.Reviews.Models
{
    public class ReportVM
    {
        public double NormalHours { get; set; }
        public double NightHours { get; set; }
        public double SundayHours { get; set; }
        public double SundayOvertime { get; set; }
        public double NightOvertime { get; set; }
        public double NormalOvertime { get; set; }
    }
}
