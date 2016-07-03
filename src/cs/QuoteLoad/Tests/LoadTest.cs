using System;
using NUnit.Framework;
using MeiredQuotes.Load.CS.QuoteLoad;
using MeiredQuotes.Common.CS;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace MeiredQuotes.Load.CS.Tests
{
    [TestFixture]
    public class LoadTest
    {
        private CloudTable tableConfiguration;

        [TestFixtureSetUp]
        public void Initialize()
        {
            tableConfiguration = QuoteLoad.ConfigureTable.GetTableConfiguration(QuoteLoad.ConfigureTable.GetTableName());
        }

        [TestFixtureTearDown]
        public void Terminate()
        {
            tableConfiguration.DeleteIfExists();
        }

        [Test]
        public void LoadNullQuotesList()
        {
            Assert.Throws<ArgumentNullException>(() => QuoteLoad.Load.LoadQuotes(tableConfiguration, null));         
        }

        [Test]
        public void LoadEmptyQuotesList()
        {
            Assert.Throws<ArgumentException>(() => QuoteLoad.Load.LoadQuotes(tableConfiguration, new List<Quote>()));
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
            var result = QuoteLoad.Load.LoadQuotes(tableConfiguration, item);
            Assert.IsNotNull(result, "result is not null");
            Assert.IsTrue(result.IsOkay, "result.IsOkay is true");
            Assert.IsTrue(result.LoadCount == 1, "result.LoadCount is 1");
        }

    }
}
