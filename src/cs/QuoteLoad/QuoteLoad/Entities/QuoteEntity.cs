using MeiredQuotes.Common.CS;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiredQuotes.Load.CS.QuoteLoad.Entities
{
    public class QuoteEntity : TableEntity
    {
        public QuoteEntity(Quote quote, int id)
        {
            this.PartitionKey = "1";
            this.RowKey = id.ToString("D8");

            this.Category = quote.Category;
            this.Author = quote.Author;
            this.QuoteText = quote.QuoteText;

        }

        public QuoteEntity() { }

        public string Category { get; set; }
        public string QuoteText { get; set; }
        public string Author { get; set; }
        
    
        public Quote ToQuote()
        {
            return new Quote { Author = this.Author, Category = this.Category, QuoteText = this.QuoteText };
        }
    }
}
