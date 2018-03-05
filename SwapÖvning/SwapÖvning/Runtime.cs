using System;
using System.Collections.Generic;
using System.Text;

namespace SwapÖvning
{
    class Runtime
    {
        public void Start()
        {
            Swap swap = new Swap();
            string[] array = new string[] { "hej", "jag", "gillar", "svamp"};
            swap.SwapTwoElements(ref array[0], ref array[3]);
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            //string stringone = "hej";
            //string stringtwo = "då";
            //swap.SwapTwoElements(ref stringone, ref stringtwo);
            //Console.WriteLine(stringone);
            //Console.WriteLine(stringtwo);
        }
    }
}
