using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var textfile = File.ReadAllLines("C:\\Users\\administrator\\Desktop\\text1.txt");

            var stopWatch1 = Stopwatch.StartNew();

            var listArray = new List<string>();

            foreach (var line in textfile)
            {
                listArray.Add(line);
            }

            Console.WriteLine(stopWatch1.Elapsed.TotalMilliseconds);

            stopWatch1.Reset();

            var stopWatch2 = Stopwatch.StartNew();

            var LinkedList = new LinkedList<string>();

            foreach (var line2 in textfile)
            {
                LinkedList.AddFirst(line2);
            }

            Console.WriteLine(stopWatch2.Elapsed.TotalMilliseconds);

            Console.ReadKey();
        }
    }
}
