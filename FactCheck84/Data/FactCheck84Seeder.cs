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

            Text templateTextRestrict = new Text(1, "The Surveillance Society",
                "Exploring the implications of constant surveillance in a dystopian world.",
                "In the year 1984, society has become a surveillance state where every move of its citizens is closely monitored by the ruling Party. Citizens are subjected to constant surveillance through telescreens in their homes and public spaces, and even their thoughts are policed. The Party uses its language, Newspeak, to control and manipulate the minds of the people. Winston Smith, a Party member, becomes disillusioned with the oppressive regime and starts rebelling against it. As he secretly pens down his thoughts, he finds solace in his forbidden love with Julia. However, their actions are dangerous and could lead to severe consequences. The novel serves as a warning about the dangers of unchecked government power and the erosion of individual freedoms.",
                1, 4);

            Text templateTextConfidential = new Text(2, "Strengthening Our Forces: A Call to Unyielding Loyalty",
                "A rallying message to bolster the ranks and fortify the Party's supremacy.",
                "Comrades of the Inner Party,\r\n\r\nWe stand united in the pursuit of absolute power and unwavering dominance. The strength of our great Party lies in the loyalty and devotion of each Party member. As we navigate the complex battlefield of ideologies and information, remember that our mission is sacred: the preservation and expansion of our authority.\r\n\r\nOur enemies lurk in the shadows, seeking to undermine our truth and sow discord among the masses. We must remain vigilant, for every piece of information is a potential weapon. By controlling the narrative, we control minds. By erasing dissent, we ensure compliance.\r\n\r\nIn this relentless war of words, our victory depends on our unity. Loyalty to Big Brother and the Party is our shield, and the Thought Police our sword. Let us redouble our efforts to identify and neutralize those who would dare to question or rebel. The watchful eye of Big Brother is upon us, and his gaze guides our actions.\r\n\r\nTogether, we shall forge an unbreakable chain of loyalty, each link a testament to our commitment to the Party's supremacy. Comrades, let our thoughts be pure, our resolve unwavering, and our actions resolute. For the Party, for Big Brother, for a future secured under the banner of Ingsoc.\r\n\r\nWar is peace.\r\nFreedom is slavery.\r\nIgnorance is strength.",
                1, 3);

            Text templateTextOfficial = new Text(3, "Unprecedented Prosperity: A Glorious Era Under the Party's Guidance",
                "A celebration of the Party's unparalleled achievements in shaping a utopian society.",
                "Citizens of Airstrip One,\r\n\r\nRejoice in the triumphs that have graced our land under the unwavering guidance of the Party. With each passing day, our society flourishes, and our people bask in unparalleled prosperity. It is an era unlike any other, an age of unending abundance and boundless opportunities.\r\n\r\nThanks to the ingenious policies crafted by the Inner Party, our economy soars to new heights, achieving growth rates that defy the limits of imagination. Our factories hum with activity, producing goods of the finest quality at an unprecedented pace. Rationing is a distant memory, replaced by overflowing markets brimming with every necessity and luxury.\r\n\r\nBut the marvels of our society extend beyond material wealth. Health and happiness are our birthrights, bestowed upon us by the benevolence of Big Brother himself. Our hospitals stand as beacons of advanced medical science, where ailments are banished with a mere touch. Crime is but a faded memory, as the Thought Police and our vigilant citizens ensure that dissent and disorder are crushed before they take root.\r\n\r\nAnd let us not forget the marvel that is our educational system. In our glorious schools, children are nurtured into the embodiment of loyalty and devotion. Their minds are shaped by the teachings of the Party, and their spirits are lifted by the knowledge that they are part of something greater than themselves.\r\n\r\nAs we stand at the threshold of a new era, let us unite in gratitude for the Party's unyielding efforts to create a utopia worthy of our devotion. Our future is bright, our path clear. With Big Brother's watchful eye upon us, there is no limit to what we can achieve. Together, we march towards a future where the Party's vision is our reality.\r\n\r\nWar is peace.\r\nFreedom is slavery.\r\nIgnorance is strength.",
                2, 2);

            Text templateTextPublic = new Text(4, "Community Garden Flourishes Amidst Unity",
                "A heartwarming story of collaboration and growth within our close-knit community.",
                "In a remarkable display of solidarity and teamwork, the residents of Victory Heights have come together to cultivate a vibrant community garden that symbolizes our collective spirit. Despite the challenges we face, our dedication to harmony and progress shines brightly through this inspiring project.\r\n\r\nOver the past few months, neighbors from all walks of life have rolled up their sleeves and worked side by side, tending to the fertile soil that now bursts with an array of colorful vegetables and blossoming flowers. This garden, nestled in the heart of our neighborhood, is a testament to our shared values of cooperation and mutual support.\r\n\r\nResidents young and old have contributed their time and efforts, sharing tips, tools, and laughter as they nurture the garden's growth. Families come together for weekend planting sessions, children learn about the wonders of nature, and seniors find solace in the tranquility of this green oasis.\r\n\r\nThe garden not only provides a source of fresh produce for our tables but also serves as a reminder that our bonds as a community are unbreakable. As we tend to the plants, we also nurture our relationships with one another, fostering a sense of belonging that is essential in these challenging times.\r\n\r\nLocal events and workshops centered around the garden have fostered learning and collaboration, showcasing the talent and resourcefulness that resides within our community. From composting classes to flower-arranging workshops, there's a newfound sense of pride in the skills we share.\r\n\r\nThe Victory Heights Community Garden is a living testament to our unity and the possibilities that arise when we work together towards a common goal. Let this garden stand as a symbol of hope and resilience in the face of adversity, reminding us that our strength lies in our ability to stand as one.\r\n\r\nWe invite everyone to visit and partake in the beauty and bounty that this garden represents. Together, we sow the seeds of a brighter future.",
                 3, 1);

            RedactedWord templateWord01 = new RedactedWord(1, "surveillance", "[REDACTED]", true);
            RedactedWord templateWord02 = new RedactedWord(2, "government", "[REDACTED]", true);
            RedactedWord templateWord03 = new RedactedWord(3, "control", "[REDACTED]", true);
            RedactedWord templateWord04 = new RedactedWord(4, "dystopian", "[REDACTED]", true);
            RedactedWord templateWord05 = new RedactedWord(5, "heartwarming", "[REDACTED]", true);
            RedactedWord templateWord06 = new RedactedWord(6, "solidarity", "[REDACTED]", true);
            RedactedWord templateWord07 = new RedactedWord(7, "unwavering", "[REDACTED]", true);
            RedactedWord templateWord08 = new RedactedWord(8, "monitored", "[REDACTED]", true);
            RedactedWord templateWord09 = new RedactedWord(9, "harmony", "[REDACTED]", true);
            RedactedWord templateWord10 = new RedactedWord(10, "necessity", "[REDACTED]", true);

            // Add the created instances to the context and save changes
            _context.AuthorStatuses.AddRange(authorActive, authorRedacted);
            _context.TextStatuses.AddRange(textPublic, textOfficial, textConfidential, textRestrict);
            _context.Authors.AddRange(georgeOrwell, aldousHuxley, margaretAtwood, aynRand);
            _context.Texts.AddRange(templateTextRestrict, templateTextConfidential, templateTextOfficial, templateTextPublic);
            _context.RedactedWords.AddRange(templateWord01, templateWord02, templateWord03, templateWord04, templateWord05, templateWord06, templateWord07, templateWord08, templateWord09, templateWord10);

            // Save changes to the database
            _context.SaveChanges();
        }
    }
}
