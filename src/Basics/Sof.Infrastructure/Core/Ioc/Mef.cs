using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Web;

namespace Sof.Ioc
{
    /// <summary>
    /// MEF 对象提供。
    /// </summary>
    public static class Mef
    {
        private const string MefItemKey = "Sof.Ioc.Mef.CompositionContainer";
        private static AggregateCatalog _catalog = new AggregateCatalog();
        [ThreadStatic]
        private static CompositionContainer _container;
        private static CompositionContainer container
        {
            get
            {
                // 初始化 AggregateCatalog
                if (Catalogs.Count == 0) Catalogs.Add(GetDefaultCatalog());

                // Web 环境 从HttpContext 获取 CompositionContainer ，确保每个请求的实例是唯一的
                if (HttpContext.Current != null)
                {
                    var container = HttpContext.Current.Items[MefItemKey];
                    if (container == null)
                    {
                        _container = new CompositionContainer(_catalog, true);
                        HttpContext.Current.Items.Add(MefItemKey, _container);
                    }
                }
                else if (_container == null)
                {
                    // 每个线程保存一个 CompositionContainer 确保每个线程的实例是唯一的
                    _container = new CompositionContainer(_catalog, true);
                }
                return _container;
            }
        }

        public static ICollection<ComposablePartCatalog> _initcatalogs;
        public static ICollection<ComposablePartCatalog> Catalogs { get { return _catalog.Catalogs; } }
        private static ComposablePartCatalog GetDefaultCatalog()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (System.Web.HttpContext.Current != null)
            {
                path = System.Web.HttpContext.Current.Server.MapPath("~/bin");
            }
            return new DirectoryCatalog(path);
        }

        /// <summary>
        /// 获取具有指定的协定名称的已导出对象或指定类型的默认值，如果有多个匹配的已导出对象，则引发异常。
        /// </summary>
        /// <typeparam name="T">要返回的已导出对象的类型。</typeparam>
        /// <param name="contractName">要返回的已导出对象的协定名称，或者为 null 或空字符串 ("") 以使用默认的协定名称。</param>
        /// <returns>如果找到匹配项，则为具有指定的协定名称的已导出对象；否则为 T 的默认值。</returns>
        /// <exception cref="System.ComponentModel.Composition.ImportCardinalityMismatchException">
        /// System.ComponentModel.Composition.Hosting.CompositionContainer 中，有多个具有指定的协定名称的已导出对象。</exception>
        /// <exception cref="System.ObjectDisposedException"> 
        /// System.ComponentModel.Composition.Hosting.CompositionContainer 对象已被释放。</exception>
        /// <exception cref="System.ComponentModel.Composition.CompositionContractMismatchException">
        /// 不能将基础导出对象强制转换为 T。</exception>
        /// <exception cref=" System.ComponentModel.Composition.CompositionException:">
        /// 组合期间发生错误。System.ComponentModel.Composition.CompositionException.Errors 将包含所发生错误的集合。
        /// </exception>
        public static T GetExportedValue<T>(string contractName = null)
        {
            return container.GetExportedValueOrDefault<T>(contractName);
        }

        /// <summary>
        /// 获取具有指定的协定名称的所有已导出对象。
        /// </summary>
        /// <typeparam name="T">要返回的已导出对象的类型。</typeparam>
        /// <param name="contractName">要返回的已导出对象的协定名称；或者为 null 或空字符串 ("") 以使用默认的协定名称。</param>
        /// <exception cref=" System.ObjectDisposedException">
        /// System.ComponentModel.Composition.Hosting.CompositionContainer 对象已被释放。</exception>
        /// <exception cref="System.ComponentModel.Composition.CompositionContractMismatchException">
        /// 一个或多个基础导出值不能强制转换为 T。</exception>
        /// <exception cref="System.ComponentModel.Composition.CompositionException">
        /// 组合期间发生错误。System.ComponentModel.Composition.CompositionException.Errors 将包含所发生错误的集合。</exception>
        /// <returns>
        /// 如果找到匹配项，则为具有指定的协定名称的已导出对象；否则为空的 System.Collections.ObjectModel.Collection<T>对象。
        /// </returns>
        public static IEnumerable<T> GetExportedValues<T>(string contractName = null)
        {
            return container.GetExportedValues<T>(contractName);
        }
    }
}
