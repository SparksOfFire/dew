using System;
using System.Collections.Generic;

namespace Sof
{
    /// <summary>
    ///  定义一种检索服务对象的机制，服务对象是为其他对象提供自定义支持的对象。
    /// </summary>
    public interface IServiceProvider
    {
        /// <summary>
        ///  获取一个服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        TService GetService<TService>(string name = null);

        /// <summary>
        ///  获取多个服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="name">服务约定名称</param>
        /// <returns></returns>
        IEnumerable<TService> GetServices<TService>(string name = null);

        /// <summary>
        /// 调用服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="action">操作</param>
        /// <param name="name">服务约定名称</param>
        void Invoke<TService>(Action<TService> action, string name);

        /// <summary>
        /// 调用服务,并返回数据
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="func">操作</param>
        /// <param name="contractName">服务约定名称</param>
        /// <returns></returns>
        TResult Invoke<TService, TResult>(Func<TService, TResult> func, string contractName = null);
    }
}
