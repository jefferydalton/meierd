using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiredQuotes.Load.CS.QuoteLoad.Entities
{
    public class IDEntity : TableEntity
    {
        public const string KeyValue = "0";

        public IDEntity()
        {
            this.PartitionKey = KeyValue;
            this.RowKey = KeyValue;
        }

        public int Id { get; set; }
    }
}
