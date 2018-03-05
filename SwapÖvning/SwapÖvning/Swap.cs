using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwapÖvning
{
    public class Swap
    {
        public void SwapTwoElements<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        //static int GetIndexOfElement<T>(IEnumerable<T> collection, T element)
        //{
        //    for (int i = 0; i < collection.Count(); i++)
        //    {
        //        if (EqualityComparer<T>.Default.Equals(collection.ElementAt(i), element))
        //            return i;
        //    }
        //    throw new Exception("Element does not excist");
        //}

        //static void MakeSwap<T>(this IEnumerable<T> collection, int indexOne, int indexTwo, ref T lhs, ref T rhs)
        //{
        //    T temp = collection.ElementAt(indexOne);
        //    //collection.ElementAt(indexOne) = collection.ElementAt(indexTwo);
        //}
    }
}
