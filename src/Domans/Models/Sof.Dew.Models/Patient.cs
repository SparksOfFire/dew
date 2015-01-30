using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Dew.Models
{
    public class Patient
    {
        public string PatientId { get; set; }

        [Required]
        public string PatientName { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
