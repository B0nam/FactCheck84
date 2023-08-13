using FactCheck84.Models;
using System.Text.RegularExpressions;

namespace FactCheck84.Services
{
    public class CensorshipService
    {
        private readonly FactCheck84Context _context;

        public CensorshipService(FactCheck84Context context)
        {
            _context = context;
        }

        public string ApplyCensorship(string textContent)
        {
            if (string.IsNullOrWhiteSpace(textContent))
            {
                return textContent;
            }

            List<RedactedWord> redactedWords = _context.RedactedWords.ToList();
            foreach (var word in redactedWords)
            {
                textContent = CensorWord(textContent, word.Word, word.NewWord);
            }

            return textContent;
        }

        public void GeneralCensorship()
        {
            List<RedactedWord> redactedWords = _context.RedactedWords.ToList();
            List<Text> texts = _context.Texts.ToList();

            if (redactedWords.Count == 0 || texts.Count == 0)
            {
                return;
            }

            foreach (var text in texts)
            {
                string rawText = text.Content;
                string censoredText = rawText;

                foreach (var word in redactedWords)
                {
                    censoredText = ApplyCensorship(censoredText); // Aplicar censura a cada palavra proibida
                }

                text.CensoredContent = censoredText;
            }

            _context.SaveChanges(); // Salvar as alterações após a censura
        }

        private string CensorWord(string textContent, string wordToCensor, string replacement)
        {
            string pattern = @"\b" + wordToCensor + @"\b";
            return Regex.Replace(textContent, pattern, replacement, RegexOptions.IgnoreCase);
        }


    }
}