using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon2.AppCode
{
    public class Word_dict
    {
        private static Dictionary<string, string> words = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"sequel","Subsquent event" },
            {"cease","stop" },
            {"admire","praise" },
            {"fun","" }
        };

        public static bool WordExists(string word)
        {
            return words.ContainsKey(word);
        }

        public static string GetTranslate(string word)
        {
            //ternary operator
            return words.ContainsKey(word) ? words[word] : null;
        }

        public static void updateTranslation (string word,string translation)
        {
            if (words.ContainsKey(word))
            {
                words[word] = translation;
            }
        }

        public static Dictionary<string, string> getWords() {
            return words;
        }

    }
}
