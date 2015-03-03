using Sof.Extensions;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sof.Identity.Core
{
    public class ClaimsIdentityFactory<TKey>
    {
        internal const string IdentityProviderClaimType = "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider";
        internal const string IdentityProviderClaimValue = "ASP.NET Identity";
        internal const string IdentityProviderClaimValueType = "http://www.w3.org/2001/XMLSchema#string";

        /// <summary>
        ///     Claim type used for role claims
        /// </summary>
        public string RoleClaimType { get; set; }

        /// <summary>
        ///     Claim type used for the user name
        /// </summary>
        public string UserNameClaimType { get; set; }

        /// <summary>
        ///     Claim type used for the user id
        /// </summary>
        public string UserIdClaimType { get; set; }

        /// <summary>
        ///     Claim type used for the user security stamp
        /// </summary>
        public string SecurityStampClaimType { get; set; }

        /// <summary>
        ///     Constructor
        /// </summary>
        public ClaimsIdentityFactory()
        {
            this.RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
            this.UserIdClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
            this.UserNameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
            this.SecurityStampClaimType = "AspNet.Identity.SecurityStamp";
        }
        /// <summary>
        ///     Create a ClaimsIdentity from a user
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="user"></param>
        /// <param name="authenticationType"></param>
        /// <returns></returns>
        public virtual ClaimsIdentity CreateAsync(IUser user, string authenticationType)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(authenticationType, this.UserNameClaimType, this.RoleClaimType);
            claimsIdentity.AddClaim(new Claim(this.UserIdClaimType, user.Id.AsString(), "http://www.w3.org/2001/XMLSchema#string"));
            claimsIdentity.AddClaim(new Claim(this.UserNameClaimType, user.UserName, "http://www.w3.org/2001/XMLSchema#string"));
            claimsIdentity.AddClaim(new Claim(IdentityProviderClaimType, IdentityProviderClaimValue, IdentityProviderClaimValueType));
            //var manager = new Services.UserManager();
            //if (manager.SupportsUserSecurityStamp)
            //{
            //    claimsIdentity.AddClaim(new Claim(this.SecurityStampClaimType, await manager.GetSecurityStampAsync(user.Id).WithCurrentCulture<string>()));
            //}
            //if (manager.SupportsUserRole)
            //{
            //    IList<string> list = await manager.GetRolesAsync(user.Id).WithCurrentCulture<IList<string>>();
            //    foreach (string current in list)
            //    {
            //        claimsIdentity.AddClaim(new Claim(this.RoleClaimType, current, IdentityProviderClaimValueType));
            //    }
            //}
            //if (manager.SupportsUserClaim)
            //{
            //    claimsIdentity.AddClaims(await manager.GetClaimsAsync(user.Id).WithCurrentCulture<IList<Claim>>());
            //}
            return claimsIdentity;
        }

    }
}
