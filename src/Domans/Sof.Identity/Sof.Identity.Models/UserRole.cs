using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Identity.Models
{
    public class UserRole : Data.IEntity
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}
