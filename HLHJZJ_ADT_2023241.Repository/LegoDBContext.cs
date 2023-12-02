using System;
using HLHJZJ_ADT_2023241.Models;
using Microsoft.EntityFrameworkCore;

namespace HLHJZJ_ADT_2023241.Repository
{
	public class LegoDBContext : DbContext
	{
        public virtual DbSet<Topic> Topics { get; set; }

		public LegoDBContext()
		{
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseInMemoryDatabase("Lego");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Topic Topic1 = new Topic() { Id = 1, Name = "Minions" };
            Topic Topic2 = new Topic() { Id = 2, Name = "Marvel" };
            Topic Topic3 = new Topic() { Id = 3, Name = "Avatar" };
            Topic Topic4 = new Topic() { Id = 4, Name = "Harry Potter" };

            modelBuilder.Entity<Topic>().HasData(Topic1, Topic2, Topic3, Topic4);
        }

        

    }
}

