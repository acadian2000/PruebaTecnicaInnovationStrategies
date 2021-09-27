using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnicaInnovationStrategiesv2.Models.Request
{
    public class RegistroInfraccionesVehicularesRequest
    {
        public int IdRegistroInfraccionesVehiculares { get; set; }

        [Required]
        public string Hora { get; set; }

        [Required]
        public string Fecha { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo Se aceptan numeros para el campo Numero de Documento ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El Numero de Documento es Obligatorio")]
        [StringLength(10, MinimumLength = 8)]
        [Display(Name = "DNI del Conductor")]
        public string Conductor { get; set; }

        [Required(ErrorMessage = "Se requiere el Numero de Matricula o Placa del Auto")]
        [Display(Name = "Numero de Matricula o Placa del Auto")]
        public string Vehiculo { get; set; }

        [Required(ErrorMessage ="Se requiere el Codigo de la Infraccion")]
        [Display(Name = "Codigo de la Infraccion")]
        public string IdentificadorInfraccion { get; set; }

        public Nullable<int> PuntosConductorAntesInfraccion { get; set; }
        public Nullable<int> PuntosaDescontar { get; set; }
        public Nullable<int> PuntosConductorDespuesInfraccion { get; set; }
    }
}