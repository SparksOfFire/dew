using Sof.Extensions;
using Sof.Utilites;
using System.Linq;

namespace Sof.IdentityService
{
    internal class IdentityDbContext : Sof.Data.DbContextBase
    {
        static IdentityDbContext()
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<IdentityDbContext>());

            Sof.Data.DatabaseInitializer.Initialize<IdentityDbContext>(db =>
            {
                if (db.Users.FirstOrDefault(u => u.UserName == "admin") == null)
                {
                    var userMgr = new UserManager<Models.User>(new UserStore<Models.User>(db));
                    var result = userMgr.Create(new Models.User() { UserName = "admin", }, "111111");
                    if (result.Errors.Count() > 0)
                   {
                       Common.Logger.Error(result.Errors.Join());
                   }
                }
            });
        }


        public IdentityDbContext()
            : base("DewConnection", throwIfV1Schema: false)
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
