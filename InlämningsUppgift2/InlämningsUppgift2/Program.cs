using FileHandler;
using System;

namespace InlämningsUppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            Runtime run = new Runtime(new FileReader(), new FileWriter());
            run.Start();
        }
    }
}
