using CarSharing.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarSharing.DataAccess.Context
{
    public partial class CompanyContext : DbContext
    {
        public CompanyContext()
        {
        }

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Rent> Rent { get; set; }
        public virtual DbSet<Car> Car { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
                {
                    entity.Property(m => m.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(m => m.Make).IsRequired();
                    entity.Property(m => m.ModelName).IsRequired();
                    entity.Property(m => m.Price).IsRequired();
                    entity.Property(m => m.Year).IsRequired();
                });
            
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(c => c.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.Address).IsRequired();
            });

            modelBuilder.Entity<Rent>(entity =>
                {
                    entity.Property(s=>s.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(s => s.Location).IsRequired();
                    entity.Property(s => s.Date).IsRequired();
                    entity.HasOne(s => s.Company)
                        .WithMany(c => c.Rent)
                        .HasForeignKey(s => s.CompanyId)
                        .HasConstraintName("FK_Rent_Company");
                    entity.HasOne(s => s.Car)
                        .WithMany(m => m.Rent).HasForeignKey(s=>s.CarId)
                        .HasConstraintName("FK_Rent_Car");
                });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}