using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

namespace Sof.Data
{
    public class DatabaseInitializer
    {
        /// <summary>
        /// 数据库初始化
        /// </summary>
        public static void Initialize<TContext>(Action<TContext> callback = null)
            where TContext : DbContext, new()
        {
            var context = new TContext();
            //var initializer = new CreateDatabaseIfNotExists<TContext>();
            //Database.SetInitializer(initializer);

            // 预先生成EF的映射视图
            //using (context)
            //{
                PreMapping(context);
                if (callback != null) callback(context);
            //}
        }

        /// <summary>
        /// 数据库初始化,自动迁移到最新版本
        /// </summary>
        public static void Initialize<TContext, TMigrationsConfiguration>(Action<TContext> callback = null)
            where TContext : DbContext, new()
            where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            IDatabaseInitializer<TContext> initializer;
            var context = new TContext();
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
                PreMapping(context);
                if (callback != null) callback(context);
            }
        }

        private static void PreMapping(DbContext context)
        {
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            mappingCollection.GenerateViews(new List<EdmSchemaError>());
        }
    }
}
