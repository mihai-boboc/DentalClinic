
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using DentalClinic.DAL;
using DentalClinic.DTOS;
using DentalClinic.Models;

namespace DentalClinic.Controllers.APIControllers
{
    public class CustomersController : ApiController
    {
        private ClinicDbContext db = new ClinicDbContext();

        // GET: api/Customers
        public IHttpActionResult GetCustomers()
        {
            var customerDtoList = new List<CustomerDto>();
            var customerList = db.Customers.ToList();

            foreach(var customer in customerList)
            {
                customerDtoList.Add(Mapper.Map<Customer, CustomerDto>(customer));
            }

            return Ok(customerDtoList);
        }

        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
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

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }
    }
}