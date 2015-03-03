using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Identity.Models
{
    public class UserClaim : UserClaim<long>
    {
    }
    public class UserClaim<TUserKey> : Data.IEntity
    {
        public int Id { get; set; }
        public TUserKey UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
