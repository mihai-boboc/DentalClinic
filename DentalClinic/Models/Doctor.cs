using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Models
{
    public enum Speciality {General, Orthodontics, Periodontics,
        Prosthodontics, Endodontics, Implantology, Surgery }
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Speciality Speciality { get; set; }
        public int WorkAgreementPercentage { get; set; }
    }
}
