using MeiredQuotes.Common.CS;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiredQuotes.Load.CS.QuoteLoad
{
    public class QuoteEntity : TableEntity
    {
        public QuoteEntity(Quote quote)
        {
            this.PartitionKey = quote.Author;
            this.RowKey = quote.QuoteText.ToSHA256();

            this.Category = quote.Category;
            this.QuoteText = quote.QuoteText;

        }

        public QuoteEntity() { }

        public string Category { get; set; }
        public string QuoteText { get; set; }
        
    
        public Quote ToQuote()
        {
            return new Quote { Author = this.PartitionKey, Category = this.Category, QuoteText = this.QuoteText };
        }
    }
}
