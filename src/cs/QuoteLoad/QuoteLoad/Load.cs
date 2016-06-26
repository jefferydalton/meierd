using MeiredQuotes.Common.CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.WindowsAzure.Storage.Table;
using System.Diagnostics;

namespace MeiredQuotes.Load.CS.QuoteLoad
{
    public static class Load
    {
        public static LoadResult LoadQuotes(CloudTable table, List<Quote> quotes)
        {
            Ensure.That(quotes).IsNotNull();
            Ensure.That(quotes).HasItems();
            Ensure.That(table).IsNotNull();

            var duration = new Stopwatch().Time(() => Console.Write("foo"));
            return new LoadResult(duration, true, 0);
        }
    }
}
