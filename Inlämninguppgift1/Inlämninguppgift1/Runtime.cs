using Inlämninguppgift1.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Inlämninguppgift1
{
    class Runtime
    {
        public void Start()
        {
            List<int> numbers = GetNumbersFromFile("Unsorted.txt");
            //numbers.BubbleSort();
            numbers.MergeSort();
            //numbers.QuickSort();
            string fileName = string.Format("{0:yyyy-MM-dd--H-mm-ss}",
            DateTime.Now);

            SaveNumbersToFile(numbers.ToArray(), fileName);
        }

        List<int> GetNumbersFromFile(string fileNameWithExtension)
        {
            var filePath = $@"{Directory.GetCurrentDirectory()}\TextFiles\{fileNameWithExtension}";
            return File.ReadAllLines(filePath).Select(int.Parse).ToList();
            //List<int> numbers = Array.ConvertAll(File.ReadAllLines(filePath), int.Parse);
        }

        void SaveNumbersToFile(int[] numbers, string filename)
        {
            string[] numbersToString = Array.ConvertAll(numbers, n => n.ToString());
            var filePath = $@"{Directory.GetCurrentDirectory()}\TextFiles\{filename}";
            File.WriteAllLines(filePath, numbersToString);
        }
    }
}
