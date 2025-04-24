using AppPetTrack.CORE.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AppPetTrack.REPO.Context
{
    public class AppPetTrackDbContext : DbContext
    {
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<TrackerDevice> TrackerDevices { get; set; }
        public DbSet<VetAppointment> VetAppointments { get; set; }
        public DbSet<Alert> Alerts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source =.; Initial catalog = PetTrack;integrated security=true;trust server certificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
