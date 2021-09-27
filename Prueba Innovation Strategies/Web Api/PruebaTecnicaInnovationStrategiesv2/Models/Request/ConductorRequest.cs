using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnicaInnovationStrategiesv2.Models.Request
{
    public class ConductorRequest
    {
        public int IdConductor { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo Se aceptan numeros para el campo Numero de Documento ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Numero de Documento es Obligatorio")]
        [StringLength(10, MinimumLength = 8)]
        public string DNI { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo Se aceptan letras para el campo nombre")]
        public string Nombre { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo Se aceptan letras para el campo apellido")]
        public string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Numero de Puntos es Obligatorio")]
        public Nullable<int> Puntos { get; set; }
    }
}