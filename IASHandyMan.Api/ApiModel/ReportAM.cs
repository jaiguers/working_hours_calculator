using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IASHandyMan.Api.ApiModel
{
    public class ReportAM
    {
        public double NormalHours { get; set; }
        public double NightHours { get; set; }
        public double SundayHours { get; set; }
        public double SundayOvertime { get; set; }
        public double NightOvertime { get; set; }
        public double NormalOvertime { get; set; }
    }
}
