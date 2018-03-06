using System;

namespace Inlämningsuppgift3
{
    class Program
    {
        static void Main(string[] args)
        {
            Runtime run = new Runtime(new Menu());
            run.Start();
        }
    }
}
