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
        public void LoadNullQuotesList()
        {
            Assert.Throws<ArgumentNullException>(() => QuoteLoad.Load.LoadQuotes(QuoteLoad.ConfigureTable.GetTestTableConfiguration(), null));         
        }

        [Test]
        public void LoadEmptyQuotesList()
        {
            Assert.Throws<ArgumentException>(() => QuoteLoad.Load.LoadQuotes(QuoteLoad.ConfigureTable.GetTestTableConfiguration(), new List<Quote>()));
        }

        [Test]
        public void LoadNullCloudTable()
        {
            var item = new List<Quote>() { new Quote { Author = "Test", Category = "Test", QuoteText = "Test" } };
            Assert.Throws<ArgumentNullException>(() => QuoteLoad.Load.LoadQuotes(null, item));
        }


        [Test]
        public void LoadSingleItemQuoteList()
        {
            var item = new List<Quote>() { new Quote { Author = "Test", Category = "Test", QuoteText = "Test" } };
            var result = QuoteLoad.Load.LoadQuotes(QuoteLoad.ConfigureTable.GetTestTableConfiguration(), item);
            Assert.IsNotNull(result, "result is not null");
            Assert.IsTrue(result.IsOkay, "result.IsOkay is true");
            Assert.IsTrue(result.LoadCount == 1, "result.LoadCount is 1");
        }

    }
}
