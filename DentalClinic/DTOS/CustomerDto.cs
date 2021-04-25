using DentalClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.DTOS
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DayOfBirth { get; set; }
        public CustomerSex CustomerSex { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
