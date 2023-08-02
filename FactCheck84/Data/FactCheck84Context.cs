using Microsoft.EntityFrameworkCore;

namespace FactCheck84.Models
{
	public class FactCheck84Context : DbContext
	{
		public FactCheck84Context(DbContextOptions<FactCheck84Context> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<AccountStatus> AccountStatuses { get; set; }
		public DbSet<CensorChief> CensorChiefs { get; set; }
		public DbSet<CensorChiefRoles> CensorChiefRoles { get; set; }
		public DbSet<RedactedWord> RedactedWords { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().ToTable("Users");
			modelBuilder.Entity<CensorChief>().ToTable("CensorChiefs");
		}
	}
}
