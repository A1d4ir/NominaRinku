using Microsoft.EntityFrameworkCore;
using NominaRinku.Domain;
using NominaRinku.Domain.Common;

namespace NominaRinku.Infrastructure.Persistence
{
    public class NominaRinkuDbContext: DbContext
    {
        public NominaRinkuDbContext(DbContextOptions<NominaRinkuDbContext> options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .HasMany(m => m.Sueldos)
                .WithOne(m => m.Empleado)
                .HasForeignKey(m => m.EmpleadoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Empleado>? Empleados { get; set; }

        public DbSet<Sueldo>? Sueldos { get; set;}
    }
}
