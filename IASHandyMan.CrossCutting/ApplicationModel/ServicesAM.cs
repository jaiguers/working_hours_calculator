using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IASHandyMan.CrossCutting.ApplicationModel
{
    public class ServicesAM
    {
        public long Id { get; set; }
        public string Names { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Identificación del servicio *")]
        public string Identification { get; set; }
    }
}
