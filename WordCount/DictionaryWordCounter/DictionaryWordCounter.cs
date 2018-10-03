using System.Collections.Generic;
using System.Linq;

namespace WordCount
{
    public class DictionaryWordCounter : IWordCounter
    {
        private readonly ITextProvider _textProvider;

        public DictionaryWordCounter(ITextProvider textProvider)
        {
            _textProvider = textProvider;
        }

        public IEnumerable<(string, int)> GetWords()
        {
            return _textProvider.GetText()
                       .SelectMany(x => x.Split())
                       .Where(x => x != string.Empty)
                       .GroupBy(x => x)
                       .ToDictionary(x => x.Key, x => x.Count())
                       .Select(x => (x.Key, x.Value));
        }
    }
}