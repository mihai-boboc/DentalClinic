using DentalClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentalClinic.DTOS
{
    public class ProcedureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public Speciality Speciality { get; set; }
        public double Price { get; set; }
    }
}