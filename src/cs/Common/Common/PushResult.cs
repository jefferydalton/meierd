using System;
using System.Collections.Generic;
using System.Text;

namespace MeiredQuotes.Common.CS
{
    public class LoadResult
    {
        private  LoadResult() { }
        public LoadResult(TimeSpan duration, bool result)
        {
            this.Duration = duration;
            this.IsOkay = result;
        }

        public TimeSpan Duration { get; private set; }
        public bool IsOkay { get; private set; }
    }
}
