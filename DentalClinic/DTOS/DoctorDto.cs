using DentalClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.DTOS
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Speciality Speciality { get; set; }
        public int WorkAgreementPercentage { get; set; }
    }
}
