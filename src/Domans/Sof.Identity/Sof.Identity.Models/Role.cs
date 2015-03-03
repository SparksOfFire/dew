using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.Identity.Models
{
    public class Role : Core.IRole, Data.IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserRole> Users { get; set; }
    }
}
