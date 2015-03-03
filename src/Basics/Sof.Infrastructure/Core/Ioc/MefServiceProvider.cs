using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sof.Ioc
{
    public class MefServiceProvider : IServiceProvider
    {
        public TService GetService<TService>(string contractName = null)
        {
            return Mef.GetExportedValue<TService>(contractName);
        }

        public IEnumerable<TService> GetServices<TService>(string contractName = null)
        {
            return Mef.GetExportedValues<TService>(contractName);
        }

        public void Invoke<TService>(Action<TService> action, string contractName = null)
        {
            var service = GetService<TService>(contractName);
            action(service);
        }

        public TResult Invoke<TService, TResult>(Func<TService, TResult> func, string contractName = null)
        {
            var service = GetService<TService>(contractName);
            return func(service);
        }
    }
}
