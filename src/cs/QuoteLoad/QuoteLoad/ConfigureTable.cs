using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;

namespace MeiredQuotes.Load.CS.QuoteLoad
{
    public class ConfigureTable
    {
        public static CloudTable GetDefaultTableConfiguration()
        {
            return GetTableConfiguration("quotes");
        }

        public static CloudTable GetTestTableConfiguration()
        {
            return GetTableConfiguration("quotesTest");
        }

        private static CloudTable GetTableConfiguration(string tableName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);
            table.CreateIfNotExists();
            return table;
        }
    }
}
