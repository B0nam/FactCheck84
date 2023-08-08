using Microsoft.EntityFrameworkCore;

namespace FactCheck84.Models
{
	public class FactCheck84Context : DbContext
	{
		public FactCheck84Context(DbContextOptions<FactCheck84Context> options) : base(options)
		{
		}

        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorStatus> AuthorStatuses { get; set; }
        public DbSet<RedactedWord> RedactedWords { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<TextStatus> TextStatuses { get; set; }
    }
}
