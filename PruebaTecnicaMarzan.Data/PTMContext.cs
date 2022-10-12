using Microsoft.EntityFrameworkCore;
using PruebaTecnicaMarzan.Models;
using PruebaTecnicaMarzan.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnicaMarzan.Data
{
    public class PTMContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PTMDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Data Seed
            modelBuilder.Entity<Account>()
                        .HasData
            (
                new Account
                {
                    ID = 1,
                    Nombre = "Marzan",
                    Email = "hmarzan@marzanconsulting.com",
                    Password = "new"
                }
            );
            modelBuilder.Entity<Account>()
                        .HasData
            (
                new Account
                {
                    ID = 2,
                    Nombre = "Guzman",
                    Email = "jrguzman@marzanconsulting.com",
                    Password = "new"
                }
            );
            modelBuilder.Entity<Account>()
                        .HasData
            (
                new Account
                {
                    ID = 3,
                    Nombre = "Herrera",
                    Email = "jherrera@marzanconsulting.com",
                    Password = "new"
                }
            );
            modelBuilder.Entity<Account>()
                        .HasData
            (
                new Account
                {
                    ID = 4,
                    Nombre = "Inoa",
                    Email = "einoa04@gmail.com",
                    Password = "new"
                }
            );
            #endregion
        }
    }
}
