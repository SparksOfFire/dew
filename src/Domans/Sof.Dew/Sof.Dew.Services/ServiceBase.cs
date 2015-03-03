using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Dew
{
    public class ServiceBase : Sof.IService
    {
        internal Sof.Dew.DewDbContext dbContext
        {
            get { return Sof.ServiceFactory.GetService<Sof.Dew.DewDbContext>(); }
        }
    }
}
