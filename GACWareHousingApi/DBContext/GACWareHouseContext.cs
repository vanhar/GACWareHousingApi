using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GACWareHousingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GACWareHousingApi.DBContext
{
    public class GACWareHouseContext : DbContext
    {
        public GACWareHouseContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerCode="C000001",
                FirstName="Customer A",
                Address="UAE",
                PhoneNumber="919676000101",
                Email="customerA@gmail.com",
                CompanyCode="GAC",
                CreatedBy="System",
                ModifiedBy="System",
                CreatedOn =DateTime.Now,
                ModifiedOn =DateTime.Now,
                IsDeleted=false
            }, new Customer
            {
                CustomerCode = "C000002",
                FirstName = "Customer B",
                Address = "UAE",
                PhoneNumber = "919676000102",
                Email = "customerB@gmail.com",
                CompanyCode = "GAC",
                CreatedBy = "System",
                ModifiedBy = "System",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsDeleted = false
            });

            modelBuilder.Entity<Manfacturer>().HasData(new Manfacturer
            {
                ManfacturerCode = "M000001",
                FirstName = "Manfacturer A",
                Address = "UAE",
                PhoneNumber = "919676000101",
                Email = "manfacturerA@gmail.com",
                CreatedBy = "System",
                ModifiedBy = "System",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsDeleted = false
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductCode = "P000001",
                ProductName = "Product A",
                UOM = "PC",
                Price = 25.50f,
                Dimensions = "50 X 20 X 100",
                ManfacturerCode= "M000001",
                CreatedBy = "System",
                ModifiedBy = "System",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsDeleted = false
            }, new Product
            {
                ProductCode = "P000002",
                ProductName = "Product B",
                UOM = "PC",
                Price = 30.50f,
                Dimensions = "50 X 20 X 90",
                ManfacturerCode = "M000001",
                CreatedBy = "System",
                ModifiedBy = "System",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsDeleted = false
            }, new Product
            {
                ProductCode = "P000003",
                ProductName = "Product C",
                UOM = "PC",
                Price = 35.50f,
                Dimensions = "50 X 20 X 70",
                ManfacturerCode = "M000001",
                CreatedBy = "System",
                ModifiedBy = "System",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsDeleted = false
            }
            );
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manfacturer> Manfacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
