using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
        public DateTime StartFrom { get; set; }
        public int CustomerId { get; set; }
        public int DoctorId { get; set; }
        public int NurseId { get; set; }
        public int ProcedureId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Nurse Nurse { get; set; }
        public virtual Procedure Procedure { get; set; }
        public string Observations { get; set; }
    }
}
