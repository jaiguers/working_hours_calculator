using IASHandyMan.CrossCutting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IASHandyMan.Areas.Technician.Models
{
    public class PersonServicesVM
    {
        public PersonServicesVM()
        {
            PersonServiceList = new List<PersonServicesAM>();
        }

        public List<PersonServicesAM> PersonServiceList { get; set; }
    }
}
