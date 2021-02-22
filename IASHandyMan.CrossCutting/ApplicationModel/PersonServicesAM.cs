using System;
using System.ComponentModel.DataAnnotations;

namespace IASHandyMan.CrossCutting.ApplicationModel
{
    public class PersonServicesAM
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Fecha y hora de inicio *")]
        public DateTime? StarDate { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Fecha y hora fin *")]
        public DateTime? EndDate { get; set; }
        public long IdServices { get; set; }
        public long IdPerson { get; set; }
        public int WeekNumber { get; set; }
        public string IdUser { get; set; }
        public virtual PersonAM Person { get; set; }
        public virtual ServicesAM Services { get; set; }
    }
}
