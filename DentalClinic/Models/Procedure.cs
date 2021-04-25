using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Models
{
    public class Procedure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public Speciality Speciality { get; set; }
        public double Price { get; set; }

    }
}
