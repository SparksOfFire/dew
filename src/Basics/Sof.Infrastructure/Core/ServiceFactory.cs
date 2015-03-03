using Sof.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Sof
{
    /// <summary>
    /// 提供服务对象的创建和调用
    /// </summary>
    public static class ServiceFactory
    {
        /// <summary>
        /// 获取服务提供程序的集合
        /// </summary>
        public static ServiceProviderCollection ServiceProviders { get; private set; }

        /// <summary>
        /// 获取或设置服务提供程序名，如果设置了 ProviderName 则只能从该提供程序获取服务
        /// </summary>
        public static string ProviderName { get; set; }

        static ServiceFactory()
        {
            ServiceProviders = new ServiceProviderCollection();
        }

        private static Sof.IServiceProvider GetProvider()
        {
            if (!ProviderName.IsEmpty())
            {
                var provider = ServiceProviders[ProviderName];
                provider.ThrowIfNull("ProviderName", "指定的 ProviderName =" + ProviderName + "无效");
                return provider;
            }
            return null;
        }
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="providerType">服务提供程序类型</param>
        /// <param name="contractName">服务约定配置名称</param>
        /// <returns></returns>
        public static TService GetService<TService>(string contractName = null)
        {
            return GetProvider().GetService<TService>();
        }
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="providerType">服务提供程序类型</param>
        /// <param name="contractName">服务约定配置名称</param>
        /// <returns></returns>
        public static IEnumerable<TService> GetServices<TService>(string contractName = null)
        {
            return GetProvider().GetServices<TService>();
        }
        /// <summary>
        /// 调用服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="action">调用方法</param>
        /// <param name="providerType">服务提供程序类型</param>
        /// <param name="contractName">服务约定配置名称</param>
        public static void Invoke<TService>(Action<TService> action, string contractName = null)
        {
            action.ThrowIfNull("action");

            var service = GetProvider().GetService<TService>(contractName);
            if (service == null) throw new Exception("未获取到服务" + typeof(TService).FullName);
            action(service);
        }
    }

    /// <summary>
    /// 服务提供程序集合
    /// </summary>
    public class ServiceProviderCollection : Collection<Sof.IServiceProvider>
    {
        public Sof.IServiceProvider this[string typeName]
        {
            get
            {
                return this.Items.FirstOrDefault(p => p.GetType().FullName == typeName);
            }
        }
    }
}
