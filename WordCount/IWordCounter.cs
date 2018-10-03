using System.Collections.Generic;

namespace WordCount
{
    public interface IWordCounter
    {
        IEnumerable<(string, int)> GetWords();
    }
}
