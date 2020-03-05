using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pets.Tracker.Shared.Models.Pets;
using Pets.Tracker.Shared.Models.Pets.Animals;
using Pets.Tracker.Shared.Models.Pets.Breeds;
using Pets.Tracker.Shared.Models.Pets.Health.Grooming;
using Pets.Tracker.Shared.Models.Pets.Health.Measurements;
using Pets.Tracker.Shared.Models.Pets.Health.Toilet;
using Pets.Tracker.Shared.Models.Pets.Health.Vet;
using Pets.Tracker.Shared.Models.Pets.Tricks;
using Pets.Tracker.Shared.Models.Users;

namespace Pets.Tracker.Shared.Models.Contexts
{
    public class UsersDbContext : KeyApiAuthorizationDbContext<PetsTrackerUser, IdentityRole, string>
    {
        public virtual DbSet<PetsTrackerUser> PetTrackerUsers { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PetsTrackerUser>().HasMany(u => u.UserPets).WithOne(p => p.Owner).HasForeignKey(p => p.OwnerId);
            builder.Entity<Pet>().HasOne(p => p.Animal).WithMany(a => a.Pets).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Pet>().HasOne(p => p.Breed).WithMany(b => b.Pets).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<Animal>().HasMany(a => a.Breeds).WithOne(b => b.Animal).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<GroomingRecord>().HasOne(g => g.Pet).WithMany(p => p.GroomingRecords);
            builder.Entity<ToiletRecord>().HasOne(t => t.Pet).WithMany(p => p.ToiletRecords);
            builder.Entity<MeasurementsRecord>().HasOne(m => m.Pet).WithMany(p => p.MeasurementRecords);
            builder.Entity<VetVisit>().HasOne(v => v.Pet).WithMany(p => p.VetRecords);
            builder.Entity<TrickRecord>().HasOne(t => t.Trick).WithMany(t => t.TrickRecords);
            builder.Entity<ToiletRecord>().HasOne(t => t.Colour).WithMany(t => t.ToiletRecords);
        }

    }
}
    