using System;

namespace IASHandyMan.CrossCutting.ApplicationModel
{
    public class PersonServicesAM
    {
        public long Id { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
        public long IdServices { get; set; }
        public long IdPerson { get; set; }
        public int WeekNumber { get; set; }
        public virtual PersonAM Person { get; set; }
        public virtual ServicesAM Services { get; set; }
    }
}
