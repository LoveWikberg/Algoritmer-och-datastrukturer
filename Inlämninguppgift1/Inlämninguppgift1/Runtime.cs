using FileHandler;
using Inlämninguppgift1.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Inlämninguppgift1
{
    class Runtime
    {
        private readonly FileReader fileReader;
        private readonly FileWriter fileWriter;

        public Runtime(FileReader fileReader, FileWriter fileWriter)
        {
            this.fileReader = fileReader;
            this.fileWriter = fileWriter;
        }

        public void Start()
        {
            int[] numbers = fileReader.ReadFromFileInRootDirectory("Unsorted", "TextFiles")
                .Select(int.Parse).ToArray();
            //numbers.BubbleSort();
            numbers.MergeSort();
            //numbers.QuickSort();
            numbers.Select(n => n.ToString()).ToArray();
            fileWriter.WriteToFileInRootDirectory(numbers.Select(n => n.ToString()).ToArray(), "TextFiles");
        }

        List<int> GetNumbersFromFile(string fileNameWithExtension)
        {
            var filePath = $@"{Directory.GetCurrentDirectory()}\TextFiles\{fileNameWithExtension}";
            return File.ReadAllLines(filePath).Select(int.Parse).ToList();
        }

        void SaveNumbersToFile(int[] numbers, string filename)
        {
            string[] numbersToString = Array.ConvertAll(numbers, n => n.ToString());
            var filePath = $@"{Directory.GetCurrentDirectory()}\TextFiles\{filename}";
            File.WriteAllLines(filePath, numbersToString);
        }
    }
}
