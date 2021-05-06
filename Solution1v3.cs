using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Day4
{
    public class Solution1v3 : ISolution
    {
        public Solution1v3()
        {
            suffixNumber = 0;
        }

        int suffixNumber = 0;

        public List<Output> Solve(string input)
        {
            List<Output> outputList = new List<Output>();

            for (int i = 0; i < 10; i++)
            {
                outputList.Add(FindLowestMatch(input));
            }

            return outputList;
        }

        private Output FindLowestMatch(string input)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string seed;
            byte[] tmpSource;
            byte[] tmpHash;

            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();

            for (suffixNumber = 0; suffixNumber < 1000000; suffixNumber++)
            {
                seed = input + suffixNumber.ToString();
                tmpSource = ASCIIEncoding.ASCII.GetBytes(seed);
                tmpHash = crypto.ComputeHash(tmpSource);

                string testString = ByteArrayToStringFirst3(tmpHash).Substring(0, 5);

                testString += "1";

                int.TryParse(testString, out int testing);

                testing = (-1 * Math.Abs(testing -= 1)) + 1;
                testing = Math.Max(testing, 0);

                suffixNumber += testing * 1000000;
            }

            sw.Stop();

            return new Output(suffixNumber - 1000001, sw.Elapsed);
        }

        private static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

        private static string ByteArrayToStringFirst3(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < 3; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
