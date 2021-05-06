using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day4
{
    public static class DataFileReader
    {
        /// <summary>
        /// Reads a list of records from a text file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<string> ReadArrayDataFile(string filePath)
        {
            var lines = System.IO.File.ReadAllLines(filePath).ToList();

            return lines;
        }
        public static string ReadStringDataFile(string filePath)
        {
            string text;
            using (var streamReader = new StreamReader(filePath, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }

            return text;
        }

    }
}
