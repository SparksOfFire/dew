using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Sof.Data
{
    public class DbContextBase : DbContext
    {
        /// <summary>
        /// 可以将给定字符串用作将连接到的数据库的名称或连接字符串来构造一个新的上下文实例。请参见有关这如何用于创建连接的类备注。
        /// </summary>
        /// <param name="nameOrConnectionString">数据库名称或连接字符串。</param>
        public DbContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configure();
        }

        /// <summary>
        /// 围绕现有 ObjectContext 构造一个新的上下文实例。
        /// </summary>
        /// <param name="objectContext">要使用新的上下文包装的现有 ObjectContext。</param>
        /// <param name="dbContextOwnsObjectContext"> 如果设置为 true，则释放 DbContext 时将释放 ObjectContext；否则调用方必须释放该连接。</param>
        public DbContextBase(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {
            Configure();
        }

        protected void Configure()
        {
            Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // 取消表名复数形式的约定
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
