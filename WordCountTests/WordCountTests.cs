using System.Collections.Generic;
using System.Linq;
using WordCount;
using Xunit;

namespace WordCountTests
{
    public class WordCountTests
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

        public WordCountTests()
        {
            var textMock = new Moq.Mock<ITextProvider>();
            textMock.Setup(_ => _.GetText()).Returns(new string[] { sampleString });
            _textProvider = textMock.Object;
        }

        [Fact]
        public void GetsCorrectWordCounts()
        {
            var solver = new DictionaryBackedWordCounter(_textProvider);
            Assert.True(solver.GetWords().Intersect(expected).Count() == expected.Count());
        }
    }
}
