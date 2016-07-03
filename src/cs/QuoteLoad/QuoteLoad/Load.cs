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

            int recordsLoaded = 0;

            var duration = new Stopwatch().Time(() =>
            {
                foreach (var quote in quotes)
                {
                    if (!DoesQuoteExist(table, quote))
                    {
                        var id = GetNextId(table);
                        var tableQuote = new QuoteEntity(quote);
                        var operation = TableOperation.InsertOrReplace(tableQuote);
                        var result = table.Execute(operation);
                        recordsLoaded += 1;
                    }
                };
            }
            );
            return new LoadResult(duration, true, recordsLoaded);
        }

        private static int GetNextId(CloudTable table)
        {
            IDEntity idEntity;
            var result = table.Execute(TableOperation.Retrieve<IDEntity>(IDEntity.KeyValue, IDEntity.KeyValue));
            if (result.Result != null)
            {
                idEntity = (IDEntity)result.Result;
                idEntity.Id += 1;
            }
            else
            {
                idEntity = new IDEntity();
                idEntity.Id = 1;
            }

            table.Execute(TableOperation.InsertOrReplace(idEntity));
            return idEntity.Id;
        }

        public static bool DoesQuoteExist(CloudTable table, Quote quote)
        {
            var result = table.Execute(TableOperation.Retrieve(quote.Author.ToSHA256(),
                                                               quote.QuoteText.ToSHA256()));
            return (result.Result != null);
        }
    }
}
