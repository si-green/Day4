using System;
using System.Collections.Generic;
using System.Text;

namespace Day4
{
    public class Output
    {
        public int LowestMatch { get; set; }

        public TimeSpan TimeTaken { get; set; }

        public Output(int lowestMatch, TimeSpan timeTaken)
        {
            LowestMatch = lowestMatch;
            TimeTaken = timeTaken;
        }
    }
}
