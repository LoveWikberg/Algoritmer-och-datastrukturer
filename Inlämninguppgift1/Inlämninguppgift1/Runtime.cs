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
            numbers.BubbleSort();
            //numbers.MergeSort();
            //numbers.QuickSort();
            fileWriter.WriteToFileInRootDirectory(numbers.Select(n => n.ToString()).ToArray(), "TextFiles");
        }
    }
}
