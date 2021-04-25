using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Models
{
    public enum CustomerSex {Male,Female }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerSex CustomerSex { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
