using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Dew.Services
{
    public class ServiceBase : Sof.Core.IService
    {
        internal Sof.Dew.DewDbContext GetDbContext()
        {
            return Sof.Core.ServiceFactory.GetService<Sof.Dew.DewDbContext>();
        }
    }
}
