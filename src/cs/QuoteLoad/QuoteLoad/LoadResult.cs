using System;
using System.Collections.Generic;
using System.Text;

namespace MeiredQuotes.Load.CS.QuoteLoad
{
    public class LoadResult
    {
        private  LoadResult() { }
        public LoadResult(long duration, bool result, int loadedRecords)
        {
            this.DurationInMilliseconds = duration;
            this.IsOkay = result;
            this.LoadCount = loadedRecords;
        }

        public int LoadCount { get; private set; }
        public long DurationInMilliseconds { get; private set; }
        public bool IsOkay { get; private set; }
    }
}
