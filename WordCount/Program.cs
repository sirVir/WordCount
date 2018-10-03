using System;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var textProvider = new FileTextProvider("input.txt");
            var wordCounter = new DictionaryWordCounter(textProvider);

            foreach (var item in wordCounter.GetWords())
            {
                Console.WriteLine($"{item.Item2} : {item.Item1}");
            }

            Console.ReadKey();
        }
    }
}
