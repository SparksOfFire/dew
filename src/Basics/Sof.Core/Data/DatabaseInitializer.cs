using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Reflection;

namespace Sof.Data
{
    public class DatabaseInitializer
    {
        /// <summary>
        /// 数据库初始化,自动迁移到最新版本
        /// </summary>
        public static void Initialize<TContext, TMigrationsConfiguration>(TContext context, Action callback)
            where TContext : global::System.Data.Entity.DbContext
            where TMigrationsConfiguration : global::System.Data.Entity.Migrations.DbMigrationsConfiguration<TContext>, new()
        {
            IDatabaseInitializer<TContext> initializer;
            if (!context.Database.Exists())
            {
                initializer = new CreateDatabaseIfNotExists<TContext>();
            }
            else
            {
                initializer = new MigrateDatabaseToLatestVersion<TContext, TMigrationsConfiguration>();
            }
            Database.SetInitializer(initializer);

            // 预先生成EF的映射视图
            using (context)
            {
                var objectContext = ((IObjectContextAdapter)context).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
                if (callback != null) callback();
            }
        }

    }
}
