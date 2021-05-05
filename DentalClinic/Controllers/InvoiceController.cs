using DentalClinic.DAL;
using DentalClinic.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentalClinic.Controllers
{
    public class InvoiceController : Controller
    {
        private ClinicDbContext db = new ClinicDbContext();
        // GET: Invoice
        public ActionResult Index(int id)
        {
            var customer = db.Customers.SingleOrDefault(x => x.Id == id);
            var appointments = db.Appointments.Where(x => x.CustomerId == id).ToList();

            var invoiceViewModel = new InvoiceViewModel()
            {
                Customer = customer,
                Appoiments = appointments
            };

            return View(invoiceViewModel);
        }
    }
}