using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon_Saili
{
    internal class Librarian
    {
        static void Main(string[] args)
        {
            List<string> books = new List<string>
            {
               "\"The Canterbury Tales\" by Chaucer",
                "\"Algorithms\" by Sedgewick",
                "\"The C Programming Language\" by Kernighan and Ritchie"

            };

            List<string> sortTitles = SortTitles(books);
            foreach (var title in sortTitles)
            {
                Console.WriteLine(title);
            }
        }

        public static List<string> SortTitles(List<string> bookEntry)
        {
            var bookList = new List<(string Author,string Title)>();
            foreach (var entry in bookEntry)
            {
                var parts = entry.Split(new[] { " by " },StringSplitOptions.None);
                if (parts.Length != 2)
                {
                    continue;
                }
                string title = parts[0].Trim('\"',' ');
                string author = parts[1].Trim();
                string fAuthor = author.Split(new[] {"and"},StringSplitOptions.None)[0];
                bookList.Add((fAuthor.Trim(), title));

            }
            var sortedBooks = bookList.OrderBy(b => b.Author).ThenBy(b => b.Title).Select(b => b.Title).ToList();
             return sortedBooks;
        }
    }
}
