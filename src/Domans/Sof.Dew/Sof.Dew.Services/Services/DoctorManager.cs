using Sof;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Dew.Services
{
    public class DoctorManager : ServiceBase
    {
        public bool Add(Models.Doctor doctor)
        {
            using (var db = this.dbContext)
            {
                db.Doctors.Add(doctor);
                return db.SaveChanges() > 0;
            }
        }
    }
}
