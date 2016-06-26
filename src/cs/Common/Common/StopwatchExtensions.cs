using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MeiredQuotes.Common.CS
{
    public static class StopwatchExtensions
    {
        public static long Time(this Stopwatch sw, Action action)
        {
            sw.Reset();
            sw.Start();
            action();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
