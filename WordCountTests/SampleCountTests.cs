using System;
using System.Collections.Generic;
using System.Linq;
using WordCount;
using Xunit;

namespace WordCountTests
{
    public class SampleCountText
    {
        private readonly string sampleString = "Go do that thing that you do so well";

        List<(string, int)> expected = new List<(string, int)>()
        {
            ("Go", 1),
            ("do", 2),
            ("that", 2),
            ("thing", 1),
            ("you", 1),
            ("so", 1),
            ("well", 1)
        };


        private readonly ITextProvider _textProvider;

        public SampleCountText()
        {
            var textMock = new Moq.Mock<ITextProvider>();
            textMock.Setup(_ => _.GetText()).Returns(new string[] { sampleString });
            _textProvider = textMock.Object;
        }

        [Fact]
        public void DictionaryWordCounterGetsCorrectWordCounts()
        {
            var solver = new DictionaryWordCounter(_textProvider);
            Assert.True(solver.GetWords().Intersect(expected).Count() == expected.Count());
        }

        [Fact]
        public void TrieWordCounterGetsCorrectWordCounts()
        {
            var solver = new TrieWordCounter(_textProvider);
            Assert.True(solver.GetWords().Intersect(expected, new TupleIgnoreCaseComparer()).Count() == expected.Count());
        }

        private class TupleIgnoreCaseComparer : IEqualityComparer<(string, int)>
        {

            public bool Equals((string, int) lhs, (string, int) rhs)
            {
                return
                  StringComparer.CurrentCultureIgnoreCase.Equals(lhs.Item1, rhs.Item1)
               && lhs.Item2 == rhs.Item2;
            }


            public int GetHashCode((string, int) tuple)
            {
                return StringComparer.CurrentCultureIgnoreCase.GetHashCode(tuple.Item1)
                     ^ tuple.Item2.GetHashCode();
            }
        }
    }
}
