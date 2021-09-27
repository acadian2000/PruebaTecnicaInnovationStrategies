using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnicaInnovationStrategiesv2.Models.Request
{
    public class InfraccionRequest
    {
        public int IdElector { get; set; }

        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo Se aceptan numeros para el campo Identificador")]
        public string Identificador { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Numero de Puntos a Descontar es Obligatorio")]
        public Nullable<int> PuntosaDescontar { get; set; }
    }
}