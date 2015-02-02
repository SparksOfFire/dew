using System;
using System.Data.Entity;

namespace Sof.Dew
{
    internal class DewDbContext : DbContext
    {
        static DewDbContext()
        {
            //Sof.Data.DatabaseInitializer.Initialize<DewDbContext>();
        }

        public DewDbContext() : base("name=DefaultConnection") { }

        public DbSet<Models.Doctor> Doctors { get; set; }
        public DbSet<Models.Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            // modelBuilder.HasDefaultSchema(""); //Oracle
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
