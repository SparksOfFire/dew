using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof
{
    public abstract class DisposableObject : IDisposable
    {
        protected DisposableObject()
        {
            IsDisposed = false;
        }

        public bool IsDisposed { get; private set; }

        protected abstract void Dispose(bool disposing);

        public void Dispose()
        {
            if (IsDisposed) return;
            Dispose(true);
            IsDisposed = true;
            GC.SuppressFinalize(this);
        }

        ~DisposableObject()
        {
            Dispose(false);
        }
    }
}
