using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Day4
{
    public class Solution1 : ISolution
    {
        public Solution1()
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

            byte[] tmpSource;
            byte[] tmpHash;

            //int oldCountZeros = 0;
            //int newCountZeros = 0;
            //string hashValue;

            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
            tmpSource = ASCIIEncoding.ASCII.GetBytes(seed);
            tmpHash = crypto.ComputeHash(tmpSource);
            string testString = ByteArrayToString(tmpHash).Substring(0, 5);

            while (ByteArrayToString(tmpHash).Substring(0, 5) != "00000")
            {
                suffixNumber++;
                seed = input + suffixNumber.ToString();
                tmpSource = ASCIIEncoding.ASCII.GetBytes(seed);
                tmpHash = crypto.ComputeHash(tmpSource);

                //// try counting the leading zeros to see if its an increasing sequence
                //hashValue = ByteArrayToString(tmpHash);
                //newCountZeros = GetNewCountZeros(hashValue);
                //testZerosPattern(oldCountZeros, newCountZeros, hashValue);

                //oldCountZeros = newCountZeros;
            }

            sw.Stop();

            //Console.WriteLine(sw.Elapsed);
            //Console.WriteLine(ByteArrayToString(tmpHash));

            return new Output(suffixNumber, sw.Elapsed);
        }

        private void testZerosPattern(int oldCountZeros, int newCountZeros, string hashValue)
        {
            if(newCountZeros < oldCountZeros)
            {
                Console.WriteLine($"zeroes declined: {hashValue}");
            }

            if (newCountZeros > oldCountZeros)
            {
                Console.WriteLine($"{suffixNumber}");
            }
        }

        private static int GetNewCountZeros(string tmpHash)
        {
            int tmpCount = 0;
            
            foreach (char Letter in tmpHash)
            {
                if (Letter == '0')
                {
                    tmpCount++;
                }
                else
                {
                    break;
                }
            }

            return tmpCount;
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
