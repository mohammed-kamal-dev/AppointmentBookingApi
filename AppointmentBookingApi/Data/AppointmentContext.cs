using AppointmentBookingApi.Entities;
using AppointmentBookingApi.Service;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentBookingApi.Data
{
    public class AppointmentContext :DbContext
    {
        private readonly IDateTimeService _dateTime;

        public AppointmentContext(DbContextOptions<AppointmentContext> options, IDateTimeService dateTime) : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors  { get; set; }
        public DbSet<Schedule> Schedules  { get; set; }
        public DbSet<Period> Periods  { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTime.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTime.NowUtc;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasMany(c => c.Appointments)
                .WithOne(e => e.Doctor);

            modelBuilder.Entity<Doctor>()
                .HasMany(c => c.Schedules)
                .WithOne(e => e.Doctor);

            base.OnModelCreating(modelBuilder);

        }
    }
}
