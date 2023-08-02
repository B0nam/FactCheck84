using Microsoft.EntityFrameworkCore;

namespace FactCheck84.Models
{
	public class FactCheck84Context : DbContext
	{
		public FactCheck84Context(DbContextOptions<FactCheck84Context> options) : base(options)
		{
		}
		public DbSet<User> User { get; set; }
		public DbSet<CensorChief> CensorChief { get; set; }
	}
}
