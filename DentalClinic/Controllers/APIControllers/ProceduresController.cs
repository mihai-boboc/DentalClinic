
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using DentalClinic.DAL;
using DentalClinic.DTOS;
using DentalClinic.Models;

namespace DentalClinic.Controllers.APIControllers
{
    public class ProceduresController : ApiController
    {
        private ClinicDbContext db = new ClinicDbContext();

        // GET: api/Procedures
        public IHttpActionResult GetProcedures()
        {
            var procetureDtosList = new List<ProcedureDto>();

            var procedureList = db.Procedures.ToList();

            foreach(var procedure in procedureList)
            {
                procetureDtosList.Add(Mapper.Map<Procedure, ProcedureDto>(procedure));
            }
                
            return Ok(procetureDtosList);
        }


        // DELETE: api/Procedures/5
        [ResponseType(typeof(Procedure))]
        public IHttpActionResult DeleteProcedure(int id)
        {
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return NotFound();
            }

            db.Procedures.Remove(procedure);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProcedureExists(int id)
        {
            return db.Procedures.Count(e => e.Id == id) > 0;
        }
    }
}