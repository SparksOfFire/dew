using Sof.Data;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Reflection;

namespace Sof.Dew
{
    internal partial  class DewDbContext : DbContextBase
    {
        public const string ConnectionName = "DewConnection";
        static DewDbContext()
        {
            //Sof.Data.DatabaseInitializer.Initialize<DewContainer, Migrations.Configuration>();
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DewContainer>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DewDbContext, Migrations.Configuration>());
        }

        public DewDbContext() : base(ConnectionName) { }

        public DbSet<Models.Doctor> Doctors { get; set; }
        public DbSet<Models.Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //if (ConfigurationManager.ConnectionStrings[ConnectionName].ProviderName.Contains("Oracle"))
            //{
            //    modelBuilder.Entity<HistoryRow>().ToTable(tableName: "MigrationHistory", schemaName: "");
            //    modelBuilder.HasDefaultSchema("");
            //}

            // Doctor Patient 建立多对多关系
            modelBuilder.Entity<Models.Doctor>().HasMany(d => d.Patients).WithMany(p => p.Doctors).Map(m =>
            {
                m.ToTable("DoctorPatient");
                m.MapLeftKey("DoctorId");
                m.MapRightKey("PatientId");
            });
        }

    }
}
