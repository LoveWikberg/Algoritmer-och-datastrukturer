using FileHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InlämningsUppgift2
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
            int[] numbers = fileReader.ReadFromFileInRootDirectory("UnsortedNumbers", "TextFiles")
                .Select(int.Parse).ToArray();
            //numbers.BubbleSort();
            //numbers.MergeSort();
            //numbers.QuickSort();
            numbers.Select(n => n.ToString()).ToArray();
            fileWriter.WriteToFileInRootDirectory(numbers.Select(n => n.ToString()).ToArray(), "TextFiles");
        }

    }
}
