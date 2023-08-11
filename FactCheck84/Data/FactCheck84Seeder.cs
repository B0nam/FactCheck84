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

            Author georgeOrwell = new Author(1, 1, "George Orwell", "27B, Old Compton Street, London, England");
            Author aldousHuxley = new Author(2, 2, "Aldous Huxley", "17 Savage Road, Los Angeles, California, USA");
            Author margaretAtwood = new Author(3, 2, "Margaret Atwood", "42 Gilead Lane, Toronto, Canada");
            Author aynRand = new Author(4, 1, "Ayn Rand", "101 Fountainhead Avenue, New York, USA");

            AuthorStatus authorActive = new AuthorStatus(1, "Active");
            AuthorStatus authorRedacted = new AuthorStatus(2, "Redacted");

            TextStatus textPublic = new TextStatus(1, "Public");
            TextStatus textOfficial = new TextStatus(2, "Official");
            TextStatus textConfidential = new TextStatus(3, "Confidential");
            TextStatus textRestrict = new TextStatus(4, "Restrict");

            Text templateText = new Text(1, "The Surveillance Society",
                "Exploring the implications of constant surveillance in a dystopian world.",
                "In the year 1984, society has become a surveillance state where every move of its citizens is closely monitored by the ruling Party. Citizens are subjected to constant surveillance through telescreens in their homes and public spaces, and even their thoughts are policed. The Party uses its language, Newspeak, to control and manipulate the minds of the people. Winston Smith, a Party member, becomes disillusioned with the oppressive regime and starts rebelling against it. As he secretly pens down his thoughts, he finds solace in his forbidden love with Julia. However, their actions are dangerous and could lead to severe consequences. The novel serves as a warning about the dangers of unchecked government power and the erosion of individual freedoms.",
                1, 4);

            RedactedWord templateWord01 = new RedactedWord(1, "surveillance", "[--REDACTED---]", true);
            RedactedWord templateWord02 = new RedactedWord(2, "government", "[--REDACTED---]", true);
            RedactedWord templateWord03 = new RedactedWord(3, "control", "[--REDACTED---]", true);
            RedactedWord templateWord04 = new RedactedWord(4, "oppression", "[--REDACTED---]", true);

            // Add the created instances to the context and save changes
            _context.AuthorStatuses.AddRange(authorActive, authorRedacted);
            _context.TextStatuses.AddRange(textPublic, textOfficial, textConfidential, textRestrict);
            _context.Authors.AddRange(georgeOrwell, aldousHuxley, margaretAtwood, aynRand);
            _context.Texts.Add(templateText);
            _context.RedactedWords.AddRange(templateWord01, templateWord02, templateWord03, templateWord04);

            // Save changes to the database
            _context.SaveChanges();
        }
    }
}
