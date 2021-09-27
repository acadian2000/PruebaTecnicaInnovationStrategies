using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnicaInnovationStrategiesv2.Models.Request
{
    public class VehiculoRequest
    {
        public int IdEVehiculo { get; set; }

        [Required]
        public string Matricula { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo Se aceptan letras para el campo Marca")]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo Se aceptan numeros para el campo Numero de Documento ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Numero de Documento es Obligatorio")]
        [StringLength(10, MinimumLength = 8)]
        public string DNIConductorHabitual { get; set; }
    }
}