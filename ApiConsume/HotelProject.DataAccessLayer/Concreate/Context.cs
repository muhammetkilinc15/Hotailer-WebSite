using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concreate
{
	public class Context:IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-4GP61KD\\MSSQLSERVER2022;initial catalog=ApiDb;integrated security=true;TrustServerCertificate=True");
		}
		public DbSet<Room> Rooms { get; set; }	
		public DbSet<Service> Services { get; set; }	
		public DbSet<Staff> Staffs { get; set; }	
		public DbSet<Testimonial> Testimonials { get; set; }	
		public DbSet<Subscribe> Subscribes { get; set; }	

	}
}
