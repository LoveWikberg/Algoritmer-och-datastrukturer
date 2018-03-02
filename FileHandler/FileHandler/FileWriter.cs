using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileHandler
{
    public class FileWriter
    {
        public void WriteToFileInRootDirectory(string[] content)
        {
            string fileName = string.Format("{0:yyyy-MM-dd--H-mm-ss}.txt",
            DateTime.Now);
            string rootDirectory = Directory.GetCurrentDirectory();
            string fullPath = $"{rootDirectory}\\{fileName}";
            File.WriteAllLines(fullPath, content);
        }
        public void WriteToFileInRootDirectory(string[] content, string pathInRootDirectory)
        {
            string fileName = string.Format("{0:yyyy-MM-dd--H-mm-ss}.txt",
            DateTime.Now);
            string rootDirectory = Directory.GetCurrentDirectory();
            string fullPath = $"{rootDirectory}\\{pathInRootDirectory}\\{fileName}";
            File.WriteAllLines(fullPath, content);
        }

        public void WriteToFileInRootDirectory(string[] content, string pathInRootDirectory, string fileNameWithoutExtension)
        {
            fileNameWithoutExtension = $"{fileNameWithoutExtension}.txt";
            string rootDirectory = Directory.GetCurrentDirectory();
            string fullPath = $"{rootDirectory}\\{pathInRootDirectory}\\{fileNameWithoutExtension}";
            File.WriteAllLines(fullPath, content);
        }

    }
}
