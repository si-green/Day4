using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Day4
{
    class Solution1v2v3 : ISolution
    {
        public Solution1v2v3()
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

            bool isMatch;
            suffixNumber = 0;

            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();

            for (suffixNumber = 0; suffixNumber < 1000000; suffixNumber += 2)
            {
                isMatch = (ByteArrayToStringFirst3v2(crypto.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input + suffixNumber.ToString()))));

                if (isMatch == true)
                {
                    break;
                }
            }
            sw.Stop();

            return new Output(suffixNumber, sw.Elapsed);
        }

        private static string ByteArrayToStringFirst3(byte[] arrInput)
        {
            int i;
            string sOutput = "";
            for (i = 0; i < 3; i++)
            {
                sOutput += (arrInput[i].ToString("X2"));
            }
            return sOutput;
        }

        private bool ByteArrayToStringFirst3v2(byte[] arrInput)
        {
            int i;
            string output;
            bool isZero = true;

            for (i = 0; i < 3; i++)
            {
                output = (arrInput[i].ToString("X2"));

                if (output != "00")
                {
                    isZero = false;
                }
                if (i == 2 && output.Substring(0, 1) == "0")
                {
                    isZero = true;
                    i = 3;
                }
                if (!isZero)
                {
                    i = 3;
                }
            }
            return isZero;
        }
    }
}
