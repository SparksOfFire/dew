using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Dew.Models
{
    public class Patient : Data.IEntity
    {
        public string PatientId { get; set; }

        [Display(Name = "姓名")]
        [Required]
        public string PatientName { get; set; }

        [Display(Name = "性别")]
        public Enums.Sex Sex { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
