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
        public ControlEntity(string authorHash, string quoteTextHash)
        {
            this.PartitionKey = authorHash;
            this.RowKey = quoteTextHash;
        }
    }
}
