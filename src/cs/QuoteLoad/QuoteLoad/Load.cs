using MeiredQuotes.Common.CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.WindowsAzure.Storage.Table;
using System.Diagnostics;
using MeiredQuotes.Load.CS.QuoteLoad.Entities;

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
                        InsertQuote(table, quote);
                        recordsLoaded += 1;
                    }
                };
            }
            );
            return new LoadResult(duration, true, recordsLoaded);
        }

        private static TableResult InsertQuote(CloudTable table, Quote quote)
        {
            var id = GetNextId(table);

            var quoteEntity = new QuoteEntity(quote, id);
            var quoteOperation = TableOperation.InsertOrReplace(quoteEntity);
            var result = table.Execute(quoteOperation);

            var controlEntity = new ControlEntity(quote, id);
            var controlOperation = TableOperation.InsertOrReplace(controlEntity);
            return table.Execute(controlOperation);

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

        private static bool DoesQuoteExist(CloudTable table, Quote quote)
        {
            var result = table.Execute(TableOperation.Retrieve(quote.Author.ToSHA256(),
                                                               quote.QuoteText.ToSHA256()));
            return (result.Result != null);
        }
    }
}
