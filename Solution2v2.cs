using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Day4
{
    public class Solution2v2 : ISolution
    {
        public Solution2v2()
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

            suffixNumber = 0;

            string seed = input + "0";

            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(seed);
            byte[] tmpHash;

            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();

            tmpSource = ASCIIEncoding.ASCII.GetBytes(seed);
            tmpHash = crypto.ComputeHash(tmpSource);

            for (int i = 0; i < 10000000; i++)
            {
                seed = input + i.ToString();
                tmpSource = ASCIIEncoding.ASCII.GetBytes(seed);
                tmpHash = crypto.ComputeHash(tmpSource);

                if (ByteArrayToString(tmpHash).Substring(0, 5) == "000000")
                {
                    suffixNumber = i;
                    break;
                }
            }

            sw.Stop();
            //Console.WriteLine();
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
