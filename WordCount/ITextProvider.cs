using System.Collections.Generic;

namespace WordCount
{
    public interface ITextProvider
    {
        IEnumerable<string> GetText();
    }
}
