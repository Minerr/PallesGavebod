using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PallesGavebodWebApp.Models
{
	public class MainDbContext : DbContext
	{
		public DbSet<Gift> Gifts { get; set; }

		public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
		{

		}

		// Fluent API
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Fluent API vs Data annotations: 
			// https://docs.microsoft.com/en-us/ef/core/modeling/

			modelBuilder.Entity<Gift>()
				.HasKey(g => g.GiftNumber);

			modelBuilder.Entity<Gift>()
				.Property(g => g.CreationDate)
				.HasColumnType("datetime2");

			modelBuilder.Entity<Gift>()
				.Property(g => g.Title)
				.IsRequired()
				.HasMaxLength(100);

			modelBuilder.Entity<Gift>()
				.Property(g => g.Description)
				.IsRequired();
		}
	}
}
