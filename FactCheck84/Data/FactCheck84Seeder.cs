using FactCheck84.Models;

namespace FactCheck84.Data
{
    public class FactCheck84Seeder
    {
        private FactCheck84Context _context;

        public FactCheck84Seeder(FactCheck84Context context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.AuthorStatuses.Any() || _context.TextStatuses.Any())
            {
                return;
            }

            AuthorStatus authorActive = new AuthorStatus(1, "Active");
            AuthorStatus authorRedacted = new AuthorStatus(2, "Redacted");

            TextStatus textPublic = new TextStatus(1, "Public");
            TextStatus textOfficial = new TextStatus(2, "Official");
            TextStatus textConfidential = new TextStatus(3, "Confidential");
            TextStatus textRestrict = new TextStatus(4, "Restrict");
        }
    }
}
