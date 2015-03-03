using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Identity.Services
{
    public abstract class ServiceBase : Sof.DisposableObject
    {
        private DataAccess.IdentityDbContext _dbcontext;
        internal DataAccess.IdentityDbContext DbContext
        {
            get { return _dbcontext ?? (_dbcontext = new DataAccess.IdentityDbContext()); }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this._dbcontext != null)
            {
                this._dbcontext.Dispose();
            }
            this._dbcontext = null;
        }
    }
}
