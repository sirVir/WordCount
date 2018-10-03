using System.Collections.Generic;
using System.Linq;

namespace WordCount
{
    public class TrieWordCounter : IWordCounter
    {
        private readonly ITextProvider _textProvider;

        public TrieWordCounter(ITextProvider textProvider)
        {
            _textProvider = textProvider;
        }

        public IEnumerable<(string, int)> GetWords()
        {
            var trie = new Trie();

            foreach (string s in _textProvider.GetText()
                       .SelectMany(x => x.Split()))
            {
                // transform each word into lowercase alphabetical words so trie can process them easily
                char[] tokenized = s.ToLower().ToCharArray().Where(x => char.IsLetter(x)).ToArray();
                if (tokenized.Length > 0)
                    trie.Insert(tokenized);
            }

            return trie.Traverse();
        }
    }
}