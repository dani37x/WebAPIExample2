using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Transactions;
using WebAPIExample2.Models;

namespace WebAPIExample2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> User => Set<User>();
        public DbSet<Part> Part => Set<Part>();
        public DbSet<Order> Order => Set<Order>();
        public DbSet<Service> Service => Set<Service>();
        public DbSet<ServiceOrder> ServiceOrder => Set<ServiceOrder>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ServiceOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ServiceId });
                entity.HasOne(e => e.Order)
                      .WithMany(o => o.ServiceOrders)
                      .HasForeignKey(e => e.OrderId);
                entity.HasOne(e => e.Service)
                      .WithMany(s => s.ServiceOrders)
                      .HasForeignKey(e => e.ServiceId);
            });
        }
    }
}

