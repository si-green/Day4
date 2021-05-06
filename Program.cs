using System;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            //0000045C5E2B3911EB937D9D8C574F09
            //Part1 answer = 346386

            //00000094434E1914548B3A1AF245FB27
            //Part2 answer = 9958218

            //Data.input = "iwrupvqb";
            Data.input = "bgvyzdsv";

            ISolution solution1 = new Solution1();

            DisplayAnswers.DisplayAnswer("1", solution1.Solve(Data.input));

            ISolution solution1v2 = new Solution1v2();

            DisplayAnswers.DisplayAnswer("1v2", solution1v2.Solve(Data.input));

            ISolution solution1v2v2 = new Solution1v2v2();

            DisplayAnswers.DisplayAnswer("1v2v2", solution1v2v2.Solve(Data.input));

            ISolution solution1v2v3 = new Solution1v2v3();

            DisplayAnswers.DisplayAnswer("1v2v3", solution1v2v3.Solve(Data.input));

            ISolution solution1v3 = new Solution1v3();

            DisplayAnswers.DisplayAnswer("1v3", solution1v3.Solve(Data.input));

            //ISolution solution2 = new Solution2();

            //DisplayAnswers.DisplayAnswer("2", solution2.Solve(Data.input));

            //ISolution solution2v2 = new Solution2v2();

            //DisplayAnswers.DisplayAnswer("2v2", solution2v2.Solve(Data.input));

            Console.ReadLine();
        }
    }
}
