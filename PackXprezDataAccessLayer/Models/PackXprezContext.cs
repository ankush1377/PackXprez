using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace PackXprezDataAccessLayer.Models
{
    public partial class PackXprezContext : DbContext
    {
        public PackXprezContext()
        {
        }

        public PackXprezContext(DbContextOptions<PackXprezContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BranchOfficer> BranchOfficer { get; set; }
      
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<ServiceAvailable> ServiceAvailable { get; set; }
        public virtual DbSet<Shipment> Shipment { get; set; }
        public virtual DbSet<TimeSlot> TimeSlot { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json");

            var config = builder.Build();
            var connectionString = config.GetConnectionString("PackXprezConnectionString");


            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
      
    }
}
