using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Identity.Models
{
    public class UserLogin : Data.IEntity
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public int UserId { get; set; }
    }
}
