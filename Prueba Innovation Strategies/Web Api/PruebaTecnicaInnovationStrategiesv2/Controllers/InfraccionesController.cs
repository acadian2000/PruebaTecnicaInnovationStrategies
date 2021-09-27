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
    public class InfraccionesController : ApiController
    {
        private InnovationStrategiesDGTEntities db = new InnovationStrategiesDGTEntities();

        // GET: api/Infracciones
        public IQueryable<Infraccione> GetInfracciones()
        {
            return db.Infracciones;
        }

        // GET: api/Infracciones/5
        [ResponseType(typeof(Infraccione))]
        public IHttpActionResult GetInfraccione(string Identificadorv1, string Descripcionv1, int? PuntosaDescontarv1)
        {

            Models.Request.InfraccionRequest model = new Models.Request.InfraccionRequest
            {
                Identificador = Identificadorv1,
                Descripcion = Descripcionv1,
                PuntosaDescontar = PuntosaDescontarv1
            };

            var infraccione = db.procInfraccionesSelectxFiltrado(model.Identificador,model.Descripcion,model.PuntosaDescontar);
            if (infraccione == null)
            {
                return NotFound();
            }

            return Ok(infraccione);
        }

        // PUT: api/Infracciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInfraccione(Models.Request.InfraccionRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.procInfraccionesUpdate(model.Identificador,model.Descripcion,model.PuntosaDescontar);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            return Ok("El Registro se Actualizo Exitosamente");
        }

        // POST: api/Infracciones
        [ResponseType(typeof(Infraccione))]
        public IHttpActionResult PostInfraccione(Models.Request.InfraccionRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            try
            {
                db.procInfraccionesInsert(model.Identificador,model.Descripcion,model.PuntosaDescontar);
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

        private bool InfraccioneExists(string id)
        {
            return db.Infracciones.Count(e => e.Identificador == id) > 0;
        }
    }
}