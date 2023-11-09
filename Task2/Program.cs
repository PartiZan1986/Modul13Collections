using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            string path = @"C:\Users\administrator\Desktop\text1.txt";

            using (var sr = new StreamReader(path))
            {
                var text = sr.ReadToEnd().ToLower();

                text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

                string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var result = words.GroupBy(x => x)
                    .Where(x => x.Count() > 1)
                    .Select(x => new { Word = x.Key, Frequency = x.Count() });

                foreach (var item in result)
                {
                    if (item.Frequency > 1)
                    {
                        dictionary.Add(item.Word, item.Frequency);
                    }
                }

                var word = result.OrderByDescending(x => x.Frequency).Take(10).ToList();
                foreach (var item in word)
                {
                    Console.WriteLine(item);
                }
            }

            var orderedWords = dictionary.OrderByDescending(n => n.Value).Take(10).ToList();

            foreach (var item in orderedWords)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
