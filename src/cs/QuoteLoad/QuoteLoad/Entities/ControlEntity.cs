using MeiredQuotes.Common.CS;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiredQuotes.Load.CS.QuoteLoad.Entities
{
    public class ControlEntity : TableEntity
    {
        public ControlEntity(Quote quote, int id)
        {
            this.PartitionKey = quote.Author.ToSHA256();
            this.RowKey = quote.QuoteText.ToSHA256();
            this.Id = id.ToString("D8");
        }

        public string Id { get; set; }
    }
}
