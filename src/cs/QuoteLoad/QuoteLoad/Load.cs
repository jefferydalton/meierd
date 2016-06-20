using MeiredQuotes.Common.CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;

namespace MeiredQuotes.Load.CS.QuoteLoad
{
    public static class Load
    {
        public static PushResult PushQuotes(List<Quote> quotes)
        {
            Ensure.That(quotes).IsNotNull();
            Ensure.That(quotes).HasItems();

            return null;
        }
    }
}
