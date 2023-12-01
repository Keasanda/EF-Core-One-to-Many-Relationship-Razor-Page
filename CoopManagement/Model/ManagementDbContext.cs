using static CoopManagement.Model.Management;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Linq;
using System.Text;


namespace CoopManagement.Model
{
    public class ManagementDbContext : DbContext
    {



        public ManagementDbContext(DbContextOptions<ManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ManagementDbContext>
        {
            public ManagementDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ManagementDbContext>();
                optionsBuilder.UseSqlServer("Server = Dollar\\SQLEXPRESS01;Database=Contract;Integrated Security=True; Initial Catalog= Management;   trustServerCertificate=true ;Trusted_Connection=True");

                return new ManagementDbContext(optionsBuilder.Options);
            }
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address)
                .WithMany()
                .HasForeignKey(p => p.AddressID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.Address)
                .WithMany()
                .HasForeignKey(c => c.AddressID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Person)
                .WithMany(p => p.Contacts)
                .HasForeignKey(c => c.PersonID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CompanyID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }



    }
}
