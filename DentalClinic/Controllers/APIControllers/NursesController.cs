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
using AutoMapper;
using DentalClinic.DAL;
using DentalClinic.DTOS;
using DentalClinic.Models;

namespace DentalClinic.Controllers.APIControllers
{
    public class NursesController : ApiController
    {
        private ClinicDbContext db = new ClinicDbContext();

        // GET: api/Nurses
        public IHttpActionResult GetNurses()
        {
            var nurseListDto = new List<NurseDto>();

            var nurseList = db.Nurses.ToList();

            foreach(var nurse in nurseList)
            {
                nurseListDto.Add(Mapper.Map<Nurse, NurseDto>(nurse));
            }

            return Ok(nurseList);
        }

        public IHttpActionResult GetNurseBySpeciality(string id)
        {
            var nurseListDtoList = new List<NurseDto>();

            var specialityEnum = (Speciality)Enum.Parse(typeof(Speciality), id);

            var nurseList = db.Nurses.Where(x => x.Speciality == specialityEnum).ToList();

            foreach (var procedure in nurseList)
            {
                nurseListDtoList.Add(Mapper.Map<Nurse, NurseDto>(procedure));
            }

            return Ok(nurseListDtoList);
        }

        [Route("api/nurses/id/{id}")]
        public IHttpActionResult GetNurseById(int id)
        {

            var nurse = db.Nurses.SingleOrDefault(x => x.Id == id);

            return Ok(Mapper.Map<Nurse, NurseDto>(nurse));
        }

        // DELETE: api/Nurses/5
        [ResponseType(typeof(Nurse))]
        public IHttpActionResult DeleteNurse(int id)
        {
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return NotFound();
            }

            db.Nurses.Remove(nurse);
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

        private bool NurseExists(int id)
        {
            return db.Nurses.Count(e => e.Id == id) > 0;
        }
    }
}