using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IASHandyMan.CrossCutting.ApplicationModel
{
    public class PersonAM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Nombre *")]
        public string Name { get; set; }
        [Display(Name = "Segundo nombre")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Apellido *")]
        public string SurName { get; set; }

        [Display(Name = "Segundo apellido")]
        public string SecondSurName { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Número de identificación *")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Celular *")]
        public string Cellphone { get; set; }

        public DateTime RegistrationDate { get; set; }

        public long IdState { get; set; }
        public StatesAM States { get; set; }
    }
}
