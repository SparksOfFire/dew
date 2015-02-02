using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof.IdentityService
{
    internal class IdentityDbContext : Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<Models.User>
    {
        static IdentityDbContext()
        {
            Sof.Data.DatabaseInitializer.Initialize<IdentityDbContext>(db =>
            {
                if (db.Users.FirstOrDefault(u => u.UserName == "admin") == null)
                {
                    var userMgr = new UserManager<Models.User>(new UserStore<Models.User>(db));
                    var task = userMgr.CreateAsync(new Models.User() { UserName = "admin", }, "111111");
                    //task.Wait();
                    //if (task.Result.Succeeded)
                    //{
                    //}
                }
            });
        }
        public IdentityDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.User>().ToTable("Sys_Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Sys_Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("Sys_UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("Sys_UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("Sys_UserClaims");
        }
        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }
}
