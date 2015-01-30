using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Dew.Models
{
    /// <summary>
    /// 医生 
    /// </summary>
    public class Doctor
    {
        public string DoctorId { get; set; }
        [Required]
        public string DoctorName { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
