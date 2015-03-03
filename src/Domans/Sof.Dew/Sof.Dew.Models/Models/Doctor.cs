using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Dew.Models
{
    /// <summary>
    /// 医生 
    /// </summary>
    public class Doctor : Data.IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }

        [Required]
        public string DoctorName { get; set; }

        [Display(Name = "性别")]
        public Enums.Sex Sex { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
