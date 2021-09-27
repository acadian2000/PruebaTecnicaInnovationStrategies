using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PruebaTecnicaInnovationStrategiesv2.Models.Interfaces
{
    public interface IConductors
    {
        IHttpActionResult AddConductor(Models.Request.ConductorRequest model);
        IHttpActionResult PutConductor(Models.Request.ConductorRequest model);
        IHttpActionResult GetConductorsSelectTopUsuario(int TopUsuario);
    }
}
