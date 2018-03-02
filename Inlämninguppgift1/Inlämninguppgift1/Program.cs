using FileHandler;
using System;

namespace Inlämninguppgift1
{
    class Program
    {
        static void Main(string[] args)
        {
            var runtime = new Runtime(new FileReader(), new FileWriter());
            runtime.Start();
        }
    }
}
