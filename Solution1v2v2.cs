using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Day4
{
    class Solution1v2v2 : ISolution
    {
        public Solution1v2v2()
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

            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();

            for (suffixNumber = 0; suffixNumber < 1000000; suffixNumber += 2)
            {
                if (ByteArrayToStringFirst3(crypto.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input + suffixNumber.ToString()))).Substring(0, 5) == "00000")
                {
                    suffixNumber += 1000000;
                }

                if (ByteArrayToStringFirst3(crypto.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input + (suffixNumber++).ToString()))).Substring(0, 5) == "00000")
                {
                    suffixNumber += 1000000;
                }
            }
            sw.Stop();

            return new Output(suffixNumber -= 1000000, sw.Elapsed);
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
