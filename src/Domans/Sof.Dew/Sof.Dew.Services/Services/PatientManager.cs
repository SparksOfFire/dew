using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sof.Extensions;

namespace Sof.Dew.Services
{
    public class PatientManager : ServiceBase, Sof.IService
    {
        public List<Models.Patient> GetPatients(Func<Models.Patient, bool> predicate)
        {
            predicate.ThrowIfNull("predicate");
            return this.dbContext.Patients.AsNoTracking().Where(predicate).ToList();
        }

        public int AddPatients(IEnumerable<Models.Patient> patients)
        {
            patients.ThrowIfNull("patients");
            this.dbContext.Patients.AddRange(patients);
            return this.dbContext.SaveChanges();
        }
    }
}
