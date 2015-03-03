using Sof.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sof.Identity.Core
{
    public class PasswordValidator
    {
        /// <summary>
        ///  获取或设置最小密码长度
        /// </summary>
        public int RequiredLength { get; set; }

        /// <summary>
        ///  或取或设置密码是否必须由英文字母或数字组成
        /// </summary>
        public bool RequireNonLetterOrDigit { get; set; }

        /// <summary>
        ///  获取或设置密码是否必须包含小写的英文字母
        /// </summary>
        public bool RequireLowercase { get; set; }

        /// <summary>
        /// 获取或设置密码是否必须包含大写的英文字母
        /// </summary>
        public bool RequireUppercase { get; set; }

        /// <summary>
        /// 获取或设置密码是否必须包含数字
        /// </summary>
        public bool RequireDigit { get; set; }

        /// <summary>
        ///  验证密码是否符合规则
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual Task<IdentityResult> ValidateAsync(string item)
        {
            item.ThrowIfNull("item");
            List<string> list = new List<string>();
            if (string.IsNullOrWhiteSpace(item) || item.Length < this.RequiredLength)
            {
                list.Add(string.Format(CultureInfo.CurrentCulture, "密码太短", new object[]
				{
					this.RequiredLength
				}));
            }
            if (this.RequireNonLetterOrDigit && item.All(new Func<char, bool>(this.IsLetterOrDigit)))
            {
                list.Add("密码必须是由大小写英文字母或数字组成");
            }
            if (this.RequireDigit && item.All((char c) => !this.IsDigit(c)))
            {
                list.Add("密码必须包含数字");
            }
            if (this.RequireLowercase && item.All((char c) => !this.IsLower(c)))
            {
                list.Add("密码必须包含大写的英文字母");
            }
            if (this.RequireUppercase && item.All((char c) => !this.IsUpper(c)))
            {
                list.Add("密码必须包含小写的英文字母");
            }
            if (list.Count == 0)
            {
                return Task.FromResult<IdentityResult>(IdentityResult.Success);
            }
            return Task.FromResult<IdentityResult>(IdentityResult.Failed(new string[]
			{
				string.Join(" ", list)
			}));
        }
        /// <summary>
        ///  检查字符是否是0-9的数字
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
        /// <summary>
        ///  检查字符是否是a-z的小写字母
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual bool IsLower(char c)
        {
            return c >= 'a' && c <= 'z';
        }
        /// <summary>
        ///  检查字符是否是A-Z的大写字母
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual bool IsUpper(char c)
        {
            return c >= 'A' && c <= 'Z';
        }
        /// <summary>
        ///  检查字符是否是a-zA-Z的字母或0-9的数字
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual bool IsLetterOrDigit(char c)
        {
            return this.IsUpper(c) || this.IsLower(c) || this.IsDigit(c);
        }
    }
}
