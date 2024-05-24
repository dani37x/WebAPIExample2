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
        public DbSet<Order> Order => Set<Order>();
        public DbSet<Service> Service => Set<Service>();
    }
}
