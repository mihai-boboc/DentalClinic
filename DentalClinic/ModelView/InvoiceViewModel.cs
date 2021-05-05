using DentalClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ModelView
{
    public class InvoiceViewModel
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public List<int> AppoimentIds { get; set; }
        public virtual List<Appointment> Appoiments { get; set; }
    }
}
