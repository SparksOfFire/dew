using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Identity.Core
{
    /// <summary>
    ///  用户信息接口，包含一个Id,Name 和SecurityStamp
    /// </summary>
    public interface IUser : IUser<long>
    {

    }

    /// <summary>
    ///  用户信息接口，包含一个Id和Name
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IUser<out TKey>
    {
        /// <summary>
        ///  用户ID
        /// </summary>
        TKey Id { get; }

        /// <summary>
        ///  用户名
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string SecurityStamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string PasswordHash { get; set; }
    }
}
