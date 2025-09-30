using System;
using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelProject.DataAccessLayer.Concreate
{
	public class Context : IdentityDbContext<AppUser,AppRole,int>
	{
        public Context()
        {

        }
        //public Context(DbContextOptions<Context> options) : base (options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet <Room> Rooms { get; set; }
        public DbSet <Service> Services { get; set; }
        public DbSet <Staff> Staffs { get; set; }
        public DbSet <Subscribe> Subscribes { get; set; }
        public DbSet <Testimonial> Testimonials { get; set; }
    }
}

