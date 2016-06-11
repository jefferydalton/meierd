using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class ExtractTest
    {
        [Test]
        public void PullQuotesReturnsListQuotes()
        {
            var quotes = QuoteExtract.Extract.PullQuotes(@"http://sourcesofinsight.com/inspirational-quotes/");
            Assert.IsNotNull(quotes);
        }

        [Test]
        public void PullQuotesReturnsQuoteInAchievementCategory()
        {
            var quotes = QuoteExtract.Extract.PullQuotes(@"http://sourcesofinsight.com/inspirational-quotes/");
            Assert.AreNotEqual(quotes.Where(x => x.Category == "Achievement").Count(), 0);
        }


        [Test]
        public void PullQuotesThrowsArgumentExceptionErrorBecauseNullArgument()
        {
            Assert.Throws<ArgumentException>(() => QuoteExtract.Extract.PullQuotes(null));   
        }

        [Test]
        public void PullQuotesThrowsArgumentExceptionErrorBecauseEmptyArgument()
        {
            Assert.Throws<ArgumentException>(() => QuoteExtract.Extract.PullQuotes(String.Empty));
        }

        [Test]
        public void PullQuotesThrowsArgumentExceptionErrorBecauseEmpty2Argument()
        {
            Assert.Throws<ArgumentException>(() => QuoteExtract.Extract.PullQuotes(""));
        }

        [Test]
        public void PullQuotesThrowsArgumentExceptionErrorBecauseInvalidUrlArgument()
        {
            Assert.Throws<UriFormatException>(() => QuoteExtract.Extract.PullQuotes("test"));
        }

    }
}
