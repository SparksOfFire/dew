using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sof.Extensions;

namespace Sof.Dew.Services
{
    public class PatientManager : ServiceBase, Sof.Core.IService
    {
        public List<Models.Patient> GetPatients(Func<Models.Patient, bool> predicate)
        {
            predicate.ThrowIfNull("predicate");
            
            using (var db = this.dbContext)
            {
                return db.Patients.Where(predicate).ToList();
            }
        }

        public int AddPatients(IEnumerable<Models.Patient> patients)
        {
            patients.ThrowIfNull("patients");

            using (var db = this.dbContext)
            {
                db.Patients.AddRange(patients);
                return db.SaveChanges();
            }
        }
    }
}
