using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.DTOS
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime StartFrom { get; set; }
        public int CustomerId { get; set; }
        public int DoctorId { get; set; }
        public int NurseId { get; set; }
        public int ProcedureId { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public virtual DoctorDto Doctor { get; set; }
        public virtual NurseDto Nurse { get; set; }
        public virtual ProcedureDto Procedure { get; set; }
        public string Observations { get; set; }
    }
}
