using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DentalClinic.DAL;
using DentalClinic.Models;
using DentalClinic.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Controllers
{
    public class AppointmentController : Controller
    {
        private ClinicDbContext db = new ClinicDbContext();

        // GET: Appointment
        public System.Web.Mvc.ActionResult Index()
        {
            ViewBag.Date = "";
            var appointments = db.Appointments.Include(a => a.Customer).Include(a => a.Doctor).Include(a => a.Nurse).Include(a => a.Procedure);
            return View(appointments.ToList());
        }

        // GET: Appointment/Details/5
        public System.Web.Mvc.ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointment/Create
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("Default")]
        public System.Web.Mvc.ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name");
            ViewBag.NurseId = new SelectList(db.Nurses, "Id", "Name");
            ViewBag.ProcedureId = new SelectList(db.Procedures, "Id", "Name");
            return View();
        }
        [System.Web.Mvc.Route("AutoCompleteDate")]
        public System.Web.Mvc.ActionResult CreateAutoCompleteDate([FromQuery] DateTime date,int id)
        {
            var appointment = new Appointment
            {
                StartFrom = date,
                DoctorId = id,
                CustomerId = null,
                NurseId = null,
                ProcedureId = null
                
            };

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name");
            ViewBag.NurseId = new SelectList(db.Nurses, "Id", "Name");
            ViewBag.ProcedureId = new SelectList(db.Procedures, "Id", "Name");
            return View("Create",appointment);
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("Default")]
        [ValidateAntiForgeryToken]
        public System.Web.Mvc.ActionResult Create([System.Web.Mvc.Bind(Include = "Id,StartFrom,CustomerId,DoctorId,NurseId,ProcedureId,Observations")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", appointment.CustomerId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name", appointment.DoctorId);
            ViewBag.NurseId = new SelectList(db.Nurses, "Id", "Name", appointment.NurseId);
            ViewBag.ProcedureId = new SelectList(db.Procedures, "Id", "Name", appointment.ProcedureId);
            return View(appointment);
        }

        // GET: Appointment/Edit/5
        [System.Web.Mvc.Route("Default")]
        [System.Web.Mvc.HttpGet]
        public System.Web.Mvc.ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", appointment.CustomerId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name", appointment.DoctorId);
            ViewBag.NurseId = new SelectList(db.Nurses, "Id", "Name", appointment.NurseId);
            ViewBag.ProcedureId = new SelectList(db.Procedures, "Id", "Name", appointment.ProcedureId);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.Route("Default")]
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public System.Web.Mvc.ActionResult Edit([System.Web.Mvc.Bind(Include = "Id,StartFrom,CustomerId,DoctorId,NurseId,ProcedureId,Observations")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", appointment.CustomerId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "Name", appointment.DoctorId);
            ViewBag.NurseId = new SelectList(db.Nurses, "Id", "Name", appointment.NurseId);
            ViewBag.ProcedureId = new SelectList(db.Procedures, "Id", "Name", appointment.ProcedureId);
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        public System.Web.Mvc.ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public System.Web.Mvc.ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
