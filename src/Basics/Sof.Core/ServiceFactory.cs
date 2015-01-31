using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Sof.Extensions;

namespace Sof.Core
{
    /// <summary>
    /// 提供服务对象的创建和调用
    /// </summary>
    public static class ServiceFactory
    {
        /// <summary>
        /// 获取服务提供程序的集合
        /// </summary>
        public static Dictionary<string, Sof.Core.IServiceProvider> ServiceProviders { get; private set; }

        static ServiceFactory()
        {
            ServiceProviders = new Dictionary<string, Sof.Core.IServiceProvider>();
            ServiceProviders.Add("MEF", new Ioc.MefServiceProvider());
            //ServiceProviders.Add("WCF", new Wcf.WcfServiceProvider());
        }

        // 获取服务提供程序
        private static Sof.Core.IServiceProvider GetServiceProvider(string provider)
        {
            if (string.IsNullOrWhiteSpace(provider)) provider = ConfigurationManager.AppSettings["ServiceProvider"];
            if (string.IsNullOrWhiteSpace(provider)) provider = ProviderType.MEF.ToString();
            var invoker = ServiceProviders.FirstOrDefault(s => s.Key == provider);
            if (invoker.Value == null) throw new Exception("未配置名为 " + provider + " 的服务提供程序！");
            return invoker.Value;
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="providerType">服务提供程序类型</param>
        /// <param name="contractName">服务约定配置名称</param>
        /// <returns></returns>
        public static TService GetService<TService>(ProviderType providerType = ProviderType.Default, string contractName = null)
        {
            var provider = GetServiceProvider(providerType == ProviderType.Default ? null : providerType.ToString());
            if (provider == null) return default(TService);
            else return provider.GetService<TService>();
        }

        /// <summary>
        /// 调用服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="action">调用方法</param>
        /// <param name="providerType">服务提供程序类型</param>
        /// <param name="contractName">服务约定配置名称</param>
        public static void Invoke<TService>(Action<TService> action, ProviderType providerType = ProviderType.Default, string contractName = null)
        {
            action.ThrowIfNull("action");
            
            var service = GetService<TService>(providerType, contractName);
            if (service == null) throw new Exception("未获取到服务" + typeof(TService).FullName);
            action(service);
        }
    }

    /// <summary>
    /// 服务提供程序类型
    /// </summary>
    public enum ProviderType
    {
        Default,
        MEF,
        WCF
    }
}
