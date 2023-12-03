using System;
using System.Reflection.Emit;
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

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(Product => Product.Topic)
                    .WithMany(Topic => Topic.Products)
                    .HasForeignKey(Product => Product.Topic_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasMany(Topic => Topic.Products)
                    .WithOne(Product => Product.Topic)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            Topic Topic1 = new Topic() { Id = 1, Name = "Minions" };
            Topic Topic2 = new Topic() { Id = 2, Name = "Marvel" };
            Topic Topic3 = new Topic() { Id = 3, Name = "Avatar" };
            Topic Topic4 = new Topic() { Id = 4, Name = "Harry Potter" };

            Product product1 = new Product() { Id = 1, VendorCode = "ghbdtn112", Cost = 44, Topic_id = 1 };
            Product product2 = new Product() { Id = 2, VendorCode = "hlh223gjk", Cost = 30, Topic_id = 2 };
            Product product3 = new Product() { Id = 3, VendorCode = "abcdef222", Cost = 12, Topic_id = 3 };
            Product product4 = new Product() { Id = 4, VendorCode = "ghijklnm0", Cost = 15, Topic_id = 4 };

            modelBuilder.Entity<Topic>().HasData(Topic1, Topic2, Topic3, Topic4);
            modelBuilder.Entity<Product>().HasData(product1, product2, product3, product4);


        }



        

    }
}

