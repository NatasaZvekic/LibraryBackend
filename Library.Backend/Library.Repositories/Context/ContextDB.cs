using Library.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class ContextDB : DbContext
    {
        private readonly IConfiguration configuration;

        public ContextDB(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<EmployeeDB> Employee { get; set; }
        public DbSet<UserDB> Users { get; set; }
        public DbSet<BookDB> Books { get; set; }
        public DbSet<DelivererDB> DeliveryCompany { get; set; }
        public DbSet<GenreDB> Genre { get; set; }
        public DbSet<AuthorDB> Author { get; set; }
        public DbSet<SupplierDB> Suppliers { get; set; }
        public DbSet<RentalDB> Rentals{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Database"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this is empty method
        }
    }
}
