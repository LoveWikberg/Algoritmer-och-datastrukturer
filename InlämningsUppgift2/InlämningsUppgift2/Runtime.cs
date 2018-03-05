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
            double[] doubles = fileReader.ReadFromFileInRootDirectory("UnsortedDoubles", "TextFiles")
                .Select(double.Parse).ToArray();
            char[] chars = fileReader.ReadFromFileInRootDirectory("UnsortedChars", "TextFiles")
                .Select(c => char.Parse(c)).ToArray();
            string[] strings = fileReader.ReadFromFileInRootDirectory("UnsortedStrings", "TextFiles");

            #region numbers
            //numbers.BubbleSort();
            //numbers.MergeSort(0, numbers.Length - 1);
            numbers.QuickSort();
            #endregion

            #region doubles
            //doubles.BubbleSort();
            //doubles.MergeSort(0, doubles.Length - 1);
            //doubles.QuickSort();
            #endregion

            #region chars
            //chars.BubbleSort();
            //chars.MergeSort(0, chars.Length - 1);
            chars.QuickSort();
            #endregion

            #region strings
            //strings.BubbleSort();
            //strings.MergeSort(0, strings.Length - 1);
            //strings.QuickSort();
            #endregion

            string intFilename = string.Format("{0:yyyy-MM-dd--H-mm-ss}_SortedIntegers",
            DateTime.Now);
            string doubleFilename = string.Format("{0:yyyy-MM-dd--H-mm-ss}_SortedDoubles",
            DateTime.Now);
            string charFilename = string.Format("{0:yyyy-MM-dd--H-mm-ss}_SortedChars",
            DateTime.Now);
            string stringFilename = string.Format("{0:yyyy-MM-dd--H-mm-ss}_SortedStrings",
            DateTime.Now);
            fileWriter.WriteToFileInRootDirectory(numbers.Select(n => n.ToString()).ToArray(), "TextFiles", intFilename);
            fileWriter.WriteToFileInRootDirectory(doubles.Select(n => n.ToString()).ToArray(), "TextFiles", doubleFilename);
            fileWriter.WriteToFileInRootDirectory(chars.Select(n => n.ToString()).ToArray(), "TextFiles", charFilename);
            fileWriter.WriteToFileInRootDirectory(strings, "TextFiles", stringFilename);
        }
    }
}
