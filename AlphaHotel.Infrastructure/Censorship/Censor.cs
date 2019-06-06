using AlphaHotel.Infrastructure.ReaderProvider;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AlphaHotel.Infrastructure.Censorship
{
    public class Censor : ICensor
    {
        private const string path = @"..\AlphaHotel\obsceneWords.txt";
        private readonly IFileReader fileReader;

        public Censor(IFileReader fileReader)
        {
            this.fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
        }

        public string CensorText(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            string censoredText = text;

            var CensoredWords = new List<string>(this.fileReader.ReadAll(path));

            foreach (string censoredWord in CensoredWords)
            {
                string regularExpression = ToRegexPattern(censoredWord);

                censoredText = Regex.Replace(censoredText, regularExpression, StarCensoredMatch,
                  RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            }

            return censoredText;
        }

        private static string StarCensoredMatch(Match m)
        {
            string word = m.Captures[0].Value;

            return new string('*', word.Length);
        }

        private string ToRegexPattern(string wildcardSearch)
        {
            string regexPattern = Regex.Escape(wildcardSearch);

            regexPattern = regexPattern.Replace(@"\*", ".*?");
            regexPattern = regexPattern.Replace(@"\?", ".");

            if (regexPattern.StartsWith(".*?"))
            {
                regexPattern = regexPattern.Substring(3);
                regexPattern = @"(^\b)*?" + regexPattern;
            }

            regexPattern = @"\b" + regexPattern + @"\b";

            return regexPattern;
        }
    }
}
