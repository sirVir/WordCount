using System;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var textProvider = new FileTextProvider("input.txt");
            var dictWordCounter = new DictionaryBackedWordCounter(textProvider);

            foreach (var item in dictWordCounter.GetWords())
            {
                Console.WriteLine($"{item.Item2} : {item.Item1}");
            }

            Console.ReadKey();
        }
    }
}
