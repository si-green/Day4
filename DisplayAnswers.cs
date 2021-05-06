using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day4
{
    public static class DisplayAnswers
    {
        public static void DisplayAnswer(List<Output> output)
        {
            Console.WriteLine($"Answer = {output[1].LowestMatch}");
            Console.WriteLine("");
        }

        public static void DisplayAnswer(string part, List<Output> output)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Part{part} answer = {output[i].LowestMatch}");
            }

            decimal totalSeconds = output.Sum(item => item.TimeTaken.Seconds);
            decimal totalMilliseconds = output.Sum(item => item.TimeTaken.Milliseconds);
            decimal totalTime = (totalSeconds + totalMilliseconds/1000)/10;

            Console.WriteLine($"Part{part} average time taken = {totalTime}");
            Console.WriteLine("");
        }
    }
}
