using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PruebaTecnicaInnovationStrategiesv2.Models;

namespace PruebaTecnicaInnovationStrategiesv2.Controllers
{
    public class RegistroInfraccionesVehicularesController : ApiController
    {
        private InnovationStrategiesDGTEntities db = new InnovationStrategiesDGTEntities();

        // GET: api/RegistroInfraccionesVehiculares
        public IQueryable<RegistroInfraccionesVehiculare> GetRegistroInfraccionesVehiculares()
        {
            return db.RegistroInfraccionesVehiculares;
        }

        // GET: api/RegistroInfraccionesVehiculares/5
        [ResponseType(typeof(RegistroInfraccionesVehiculare))]
        public IHttpActionResult GetHistorialInfraccionesConductor(string DNIConductorHabitual, string Nombre, string Apellido)
        {
            Models.Request.ConductorRequest model = new Models.Request.ConductorRequest
            {
                DNI = DNIConductorHabitual,
                Nombre = Nombre,
                Apellido = Apellido,
            };

            var HistorialInfraccionesConductor = db.procHistorialInfraccionesConductor(model.DNI,model.Nombre,model.Apellido);
            if (HistorialInfraccionesConductor == null)
            {
                return NotFound();
            }
            return Ok(HistorialInfraccionesConductor);
        }

        // PUT: api/RegistroInfraccionesVehiculares/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegistroInfraccionesVehiculare(Models.Request.RegistroInfraccionesVehicularesRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.procInfraccionesVehicularesUpdate(model.Hora, model.Fecha, model.Conductor, model.Vehiculo, model.IdentificadorInfraccion, null, null, null);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return Ok("El Registro se Actualizo Exitosamente");
        }

        // POST: api/RegistroInfraccionesVehiculares
        [ResponseType(typeof(RegistroInfraccionesVehiculare))]
        public IHttpActionResult PostRegistroInfraccionesVehiculare(Models.Request.RegistroInfraccionesVehicularesRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.procInfraccionesVehicularesInsert(model.Hora,model.Fecha,model.Conductor,model.Vehiculo,model.IdentificadorInfraccion, null, null,null);
                if (RegistroInfraccionesVehiculareExists(model.IdRegistroInfraccionesVehiculares))
                {
                    return Conflict();
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return Ok("El Registro se Inserto Exitosamente y Se Actualizan los Puntos a Descontar");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistroInfraccionesVehiculareExists(int id)
        {
            return db.RegistroInfraccionesVehiculares.Count(e => e.IdRegistroInfraccionesVehiculares == id) > 0;
        }
    }
}