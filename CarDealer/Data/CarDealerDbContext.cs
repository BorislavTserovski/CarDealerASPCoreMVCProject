using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarDealer.Models;
using CarDealer.Data.Models;

namespace CarDealer.Data
{
    public class CarDealerDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }


        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PartCars>()
                .HasKey(cp => new { cp.CarId, cp.PartId });

            builder.Entity<PartCars>()
                .HasOne(cp => cp.Car)
                .WithMany(c => c.Parts)
                .HasForeignKey(cp => cp.CarId);

            builder.Entity<PartCars>()
                .HasOne(cp => cp.Part)
                .WithMany(p=>p.Cars)
                .HasForeignKey(cp => cp.PartId);
        
            builder.Entity<Part>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Parts)
                .HasForeignKey(p => p.SupplierId);

            builder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

            builder.Entity<Sale>()
                .HasOne(s => s.Car)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CarId);

            base.OnModelCreating(builder);
           
        }
    }
}
