using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Identity.Core
{
    public static class Configuration
    {
        public static bool SupportsUserTwoFactor { get; set; }

        ///// <summary>
        ///// Returns true if the store is an IUserPasswordStore
        ///// </summary>
        //public  bool SupportsUserPassword
        //{
        //    get
        //    {
        //        return this.Store is IUserPasswordStore<TUser, TKey>;
        //    }
        //}
        ///// <summary>
        /////     Returns true if the store is an IUserSecurityStore
        ///// </summary>
        //public  bool SupportsUserSecurityStamp
        //{
        //    get
        //    {
        //        this.ThrowIfDisposed();
        //        return this.Store is IUserSecurityStampStore<TUser, TKey>;
        //    }
        //}
        ///// <summary>
        /////     Returns true if the store is an IUserRoleStore
        ///// </summary>
        //public  bool SupportsUserRole
        //{
        //    get
        //    {
        //        this.ThrowIfDisposed();
        //        return this.Store is IUserRoleStore<TUser, TKey>;
        //    }
        //}
        ///// <summary>
        /////     Returns true if the store is an IUserLoginStore
        ///// </summary>
        //public  bool SupportsUserLogin
        //{
        //    get
        //    {
        //        this.ThrowIfDisposed();
        //        return this.Store is IUserLoginStore<TUser, TKey>;
        //    }
        //}
        ///// <summary>
        /////     Returns true if the store is an IUserEmailStore
        ///// </summary>
        //public  bool SupportsUserEmail
        //{
        //    get
        //    {
        //        this.ThrowIfDisposed();
        //        return this.Store is IUserEmailStore<TUser, TKey>;
        //    }
        //}
        ///// <summary>
        /////     Returns true if the store is an IUserPhoneNumberStore
        ///// </summary>
        //public  bool SupportsUserPhoneNumber
        //{
        //    get
        //    {
        //        this.ThrowIfDisposed();
        //        return this.Store is IUserPhoneNumberStore<TUser, TKey>;
        //    }
        //}
        ///// <summary>
        /////     Returns true if the store is an IUserClaimStore
        ///// </summary>
        //public  bool SupportsUserClaim
        //{
        //    get
        //    {
        //        this.ThrowIfDisposed();
        //        return this.Store is IUserClaimStore<TUser, TKey>;
        //    }
        //}
        ///// <summary>
        /////     Returns true if the store is an IUserLockoutStore
        ///// </summary>
        //public  bool SupportsUserLockout
        //{
        //    get
        //    {
        //        this.ThrowIfDisposed();
        //        return this.Store is IUserLockoutStore<TUser, TKey>;
        //    }
        //}
        ///// <summary>
        /////     Returns true if the store is an IQueryableUserStore
        ///// </summary>
        //public  bool SupportsQueryableUsers
        //{
        //    get
        //    {
        //        this.ThrowIfDisposed();
        //        return this.Store is IQueryableUserStore<TUser, TKey>;
        //    }
        //}
    }
}
