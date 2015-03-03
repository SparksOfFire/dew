using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Identity.Core
{
    public class IdentityResult
    {
        private static readonly IdentityResult _success = new IdentityResult(true);
        /// <summary>
        ///  如果操作成功返回 true
        /// </summary>
        public bool Succeeded { get; private set; }
        /// <summary>
        ///  获取错误列表
        /// </summary>
        public IEnumerable<string> Errors { get; private set; }
        /// <summary>
        /// 静态的成功返回结果
        /// </summary>
        /// <returns></returns>
        public static IdentityResult Success { get { return IdentityResult._success; } }
        /// <summary>
        ///   失败返回结果的构造函数
        /// </summary>
        /// <param name="errors"></param>
        public IdentityResult(params string[] errors)
            : this((IEnumerable<string>)errors)
        {
        }
        /// <summary>
        ///  失败返回结果的构造函数
        /// </summary>
        /// <param name="errors"></param>
        public IdentityResult(IEnumerable<string> errors)
        {
            if (errors == null)
            {
                errors = new string[] { "操作失败" };
            }
            this.Succeeded = false;
            this.Errors = errors;
        }
        /// <summary>
        /// 成功结果的构造函数
        /// </summary>
        /// <param name="success"></param>
        protected IdentityResult(bool success)
        {
            this.Succeeded = success;
            this.Errors = new string[0];
        }
        /// <summary>
        ///  获取失败返回结果
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static IdentityResult Failed(params string[] errors)
        {
            return new IdentityResult(errors);
        }
    }
}
