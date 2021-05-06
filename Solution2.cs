using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Day4
{
    public class Solution2 : ISolution
    {
        public Solution2()
        {
        }

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
            
            int suffixNumber = 0;

            string seed = input + "0";

            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(seed);
            byte[] tmpHash;

            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            while (ByteArrayToString(tmpHash).Substring(0, 6) != "000000")
            {
                suffixNumber++;
                seed = input + suffixNumber.ToString();
                tmpSource = ASCIIEncoding.ASCII.GetBytes(seed);
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            }

            sw.Stop();

            //Console.WriteLine(sw.Elapsed);
            //Console.WriteLine(ByteArrayToString(tmpHash));

            return new Output(suffixNumber, sw.Elapsed);
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
    }
}
