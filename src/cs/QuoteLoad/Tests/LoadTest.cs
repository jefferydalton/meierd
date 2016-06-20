using System;
using NUnit.Framework;
using MeiredQuotes.Load.CS.QuoteLoad;
using MeiredQuotes.Common.CS;
using System.Collections.Generic;

namespace MeiredQuotes.Load.CS.Tests
{
    [TestFixture]
    public class LoadTest
    {
        [Test]
        public void PushNullQuotesList()
        {
            Assert.Throws<ArgumentNullException>(() => QuoteLoad.Load.PushQuotes(null));         
        }

        [Test]
        public void PushEmptyQuotesList()
        {
            Assert.Throws<ArgumentException>(() => QuoteLoad.Load.PushQuotes(new List<Quote>()));
        }

        [Test]
        public void PushSingleItemQuoteList()
        {
            var item = new List<Quote>() { new Quote { Author = "Test", Category = "Test", QuoteText = "Test" } };
            var result = QuoteLoad.Load.PushQuotes(item);
            Assert.IsNull(result);
        }

    }
}
