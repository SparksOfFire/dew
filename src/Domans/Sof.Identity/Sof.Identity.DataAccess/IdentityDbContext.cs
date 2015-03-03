using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;

namespace Sof.Identity.DataAccess
{
    internal partial class IdentityDbContext : Sof.Data.DbContextBase
    {
        public IdentityDbContext()
            : base("name=DefaultConnection")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Identity.Models.User> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Identity.Models.UserRole> UserRoles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Identity.Models.UserLogin> UserLogins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Identity.Models.UserClaim> UserClaims { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Identity.Models.Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var userConfiguration = modelBuilder.Entity<Models.User>().ToTable("SysUser");
            userConfiguration.HasMany<Models.UserRole>(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            userConfiguration.HasMany<Models.UserClaim>(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            userConfiguration.HasMany<Models.UserLogin>(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
            userConfiguration.Property(u => u.UserName).IsRequired().HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex")
            {
                IsUnique = true
            }));

            modelBuilder.Entity<Models.UserRole>().HasKey(r => new
            {
                r.UserId,
                r.RoleId
            }).ToTable("SysUserRole");

            modelBuilder.Entity<Models.UserLogin>().HasKey(l => new
            {
                l.LoginProvider,
                l.ProviderKey,
                l.UserId
            }).ToTable("SysUserLogin");

            modelBuilder.Entity<Models.UserClaim>().ToTable("SysUserClaim");

            var roleConfiguration = modelBuilder.Entity<Models.Role>().ToTable("SysRole");
            roleConfiguration.HasMany<Models.UserRole>(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
            roleConfiguration.Property(r => r.Name).IsRequired().HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("RoleNameIndex")
            {
                IsUnique = true
            }));
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (entityEntry != null && entityEntry.State == EntityState.Added)
            {
                var list = new List<DbValidationError>();
                var user = entityEntry.Entity as Models.User;
                if (user != null)
                {
                    if (this.Users.Any(u => string.Equals(u.UserName, user.UserName)))
                    {
                        list.Add(new DbValidationError("User", string.Format(CultureInfo.CurrentCulture, "重复的用户名", new object[]
						{
							user.UserName
						})));
                    }
                }
                else
                {
                    var role = entityEntry.Entity as Models.Role;
                    if (role != null && this.Roles.Any(r => string.Equals(r.Name, role.Name)))
                    {
                        list.Add(new DbValidationError("Role", string.Format(CultureInfo.CurrentCulture, "角色名称已经存在", new object[]
						{
							role.Name
						})));
                    }
                }
                if (list.Any<DbValidationError>())
                {
                    return new DbEntityValidationResult(entityEntry, list);
                }
            }
            return base.ValidateEntity(entityEntry, items);
        }

    }
}
