using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Hackathon_Saili
{
    internal class Program
    {
        //Match the string by converting to lower case
        public static void FrequencyCounter()
        {
            Console.WriteLine("Enter the text");
            string my_string = Console.ReadLine();
         
            // pattern should be match with alphabet a-z and A-Z
            if(!Regex.IsMatch(my_string,"[a-zA-Z]"))
                {
                Console.WriteLine(0);
                return;

            }

            // to count the frequency of each word I will be using a dictionary.
            Dictionary<string, int> freq = new Dictionary<string, int>();

            var words = Regex.Matches(my_string.ToLower(), @"\b[a-zA-Z]+\b").Cast<Match>().Select(m=>m.Value).ToList();

            foreach (var word in words)
            {
       
                if (freq.ContainsKey(word))
                {
                    freq[word]++;
                }
                else
                {

                    freq[word] = 1;
                }

            }
            // according to the frequency I have to sort the dictionary
            var sortingbyfreq = freq.OrderByDescending(x => x.Key).ThenBy(x => x.Value);
            foreach (var item in sortingbyfreq)
            {
                Console.WriteLine($"{item.Value} {item.Key} ");
                

              
                ;
            }
        }
        static void Main(string[] args)
        {
              FrequencyCounter();
            
            
        }
    }
}
