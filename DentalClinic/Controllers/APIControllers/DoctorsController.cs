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
    public class DoctorsController : ApiController
    {
        private ClinicDbContext db = new ClinicDbContext();

        // GET: api/Doctors
        public IHttpActionResult GetDoctors()
        {
            var doctorListDto = new List<DoctorDto>();
            var doctorList = db.Doctors.ToList();

            foreach(var doctor in doctorList)
            {
                doctorListDto.Add(Mapper.Map<Doctor, DoctorDto>(doctor));
            }

            return Ok(doctorList);
        }

        public IHttpActionResult DeleteDoctor(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }

            db.Doctors.Remove(doctor);
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

        private bool DoctorExists(int id)
        {
            return db.Doctors.Count(e => e.Id == id) > 0;
        }
    }
}