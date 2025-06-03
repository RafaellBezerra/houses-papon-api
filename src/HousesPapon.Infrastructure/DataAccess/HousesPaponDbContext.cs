using HousesPapon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HousesPapon.Infrastructure.DataAccess
{
    internal class HousesPaponDbContext : DbContext
    {
        public HousesPaponDbContext(DbContextOptions options) : base(options) { }

        public DbSet<House> Houses { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>()
                .HasOne(x => x.Tenant)
                .WithOne(x => x.House)
                .HasForeignKey<Tenant>(x => x.HouseId);

            modelBuilder.Entity<Contract>()
                .HasOne(x => x.Tenant)
                .WithMany()
                .HasForeignKey(x => x.TenantId);

            modelBuilder.Entity<Contract>()
                .HasOne(x => x.House)
                .WithMany()
                .HasForeignKey(x => x.HouseId);

            modelBuilder.Entity<Payment>()
                .HasOne(x => x.House)
                .WithMany()
                .HasForeignKey(x => x.HouseId);
            
            modelBuilder.Entity<Payment>()
                .HasOne(x => x.Tenant)
                .WithMany()
                .HasForeignKey(x => x.TenantId);

            modelBuilder.Entity<Image>()
                .HasOne(x => x.House)
                .WithMany()
                .HasForeignKey(x => x.HouseId);
        }
    }
}
