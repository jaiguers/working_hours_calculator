using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IASHandyMan.Areas.Reviews.Models
{
    public class RequestHoursVM
    {
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Identificación del técnico *")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Número de la semana*")]
        public int Week { get; set; }
    }
}
