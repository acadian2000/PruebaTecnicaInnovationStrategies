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
using PruebaTecnicaInnovationStrategiesv2.Models.Interfaces;

namespace PruebaTecnicaInnovationStrategiesv2.Controllers
{
    public class ConductorsController : ApiController 
    {
        private InnovationStrategiesDGTEntities db = new InnovationStrategiesDGTEntities();

        private IConductors conductors;

        public ConductorsController(Moq.Mock<IConductors> conductoresVehiculos)
        {

        }

        public ConductorsController(IConductors conductors)
        {
            this.conductors = conductors;
        }

        // GET: api/Conductors
        public IQueryable<Conductor> GetConductors()
        {           
            return db.Conductors;
        }

        // GET: api/Conductors/5
        [ResponseType(typeof(Conductor))]
        public IHttpActionResult GetConductorsSelectxDNI(string NumDNI)
        {
            Models.Request.ConductorRequest model = new Models.Request.ConductorRequest
            {
                DNI = NumDNI
            };

            var conductor = db.procConductorSelectxDNI(model.DNI);
            if (conductor == null)
            {
                return NotFound();
            }

            return Ok(conductor);
        }


        // GET: api/Conductors/5
        [ResponseType(typeof(Conductor))]
        public IHttpActionResult GetConductorsSelectTopUsuario(int TopUsuario)
        {        
            var conductor = db.procConductorSelectTOP(TopUsuario);
            if (conductor == null)
            {
                return NotFound();
            }

            return Ok(conductor);
        }

        // PUT: api/Conductors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConductor(Models.Request.ConductorRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.procConductorUpdate(model.DNI,model.Nombre,model.Apellido,model.Puntos);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            return Ok("El Registro se Actualizo Exitosamente");
        }

        // POST: api/Conductors
        [ResponseType(typeof(void))]
        public IHttpActionResult AddConductor(Models.Request.ConductorRequest model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
         
            try
            {
                conductors.AddConductor(model);
                db.procConductorInsert(model.DNI, model.Nombre, model.Apellido, model.Puntos);
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

        private bool ConductorExists(string id)
        {
            return db.Conductors.Count(e => e.DNI == id) > 0;
        }
    }
}