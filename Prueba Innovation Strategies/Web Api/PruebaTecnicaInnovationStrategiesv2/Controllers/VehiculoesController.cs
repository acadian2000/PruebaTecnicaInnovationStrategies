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
    public class VehiculoesController : ApiController
    {
        private InnovationStrategiesDGTEntities db = new InnovationStrategiesDGTEntities();

        // GET: api/Vehiculoes
        public IQueryable<Vehiculo> GetVehiculoes()
        {
            return db.Vehiculoes;
        }

        // GET: api/Vehiculoes/5
        [ResponseType(typeof(Vehiculo))]
        public IHttpActionResult GetVehiculo(string Matriculap, string Marcap, string Modelop, string DNIConductorHabitualp)
        {
            if (string.IsNullOrEmpty(Matriculap) || string.IsNullOrEmpty(Marcap) || string.IsNullOrEmpty(Modelop) || string.IsNullOrEmpty(DNIConductorHabitualp))
            {
                Matriculap = string.Empty;
                Marcap = string.Empty;
                Modelop = string.Empty;
                DNIConductorHabitualp = string.Empty;
            }

            Models.Request.VehiculoRequest model = new Models.Request.VehiculoRequest
            {
                Matricula = Matriculap,
                Marca = Marcap,
                Modelo = Modelop,
                DNIConductorHabitual = DNIConductorHabitualp
            };

            var vehiculo = db.procVehiculoSelectFiltrado(model.Matricula, model.Marca, model.Modelo, model.DNIConductorHabitual);
            if (vehiculo == null)
            {
               return NotFound();
            }
            
            return Ok(vehiculo);
        }

        // PUT: api/Vehiculoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehiculo(Models.Request.VehiculoRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.procVehiculoUpdate(model.Matricula,model.Marca,model.Modelo,model.DNIConductorHabitual);
                if (!VehiculoExists(model.Matricula))
                {
                    return NotFound();
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            return Ok("El Registro se Actualizo Exitosamente");
        }

        // POST: api/Vehiculoes
        [ResponseType(typeof(Vehiculo))]
        public IHttpActionResult PostVehiculo(Models.Request.VehiculoRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.procVehiculoInsert(model.Matricula, model.Marca, model.Modelo, model.DNIConductorHabitual);
                if (VehiculoExists(model.Matricula))
                {
                    return Conflict();
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return Ok("El Registro se Guardo Exitosamente");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehiculoExists(string id)
        {
            return db.Vehiculoes.Count(e => e.Matricula == id) > 0;
        }
    }
}