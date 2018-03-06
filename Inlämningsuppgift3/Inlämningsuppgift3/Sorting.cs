using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift3
{
    static class Sorting
    {
        public static void BubbleSort<T>(this T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {
                    if (array[sort].CompareTo(array[sort + 1]) > 0)
                    {
                        T temp = array[sort];
                        array[sort] = array[sort + 1];
                        array[sort + 1] = temp;
                    }
                }
            }
        }

        public static void BubbleSort<T, TKey>(this T[] array, Func<T, TKey> selector) where TKey : IComparable<TKey>
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {
                    //if (array[sort].CompareTo(array[sort + 1]) > 0)
                    if (selector(array[sort]).CompareTo(selector(array[sort + 1])) > 0)
                    //if (selector(array[sort]) > selector(array[sort + 1]))
                    {
                        T temp = array[sort];
                        array[sort] = array[sort + 1];
                        array[sort + 1] = temp;
                    }
                }
            }
        }

        public static void QuickSort<T, TKey>(this T[] array, Func<T, TKey> selector) where TKey : IComparable<TKey>
        {
            array.QuickSort(0, array.Length - 1, selector);
        }
        static void QuickSort<T, TKey>(this T[] array, int low, int high, Func<T, TKey> selector) where TKey : IComparable<TKey>
        {
            int i = low, j = high;
            TKey pivot = selector(array[low + (high - low) / 2]);

            while (i <= j)
            {
                //while (array[i].CompareTo(pivot) < 0)
                while (selector(array[i]).CompareTo(pivot) < 0)
                {
                    i++;
                }
                //while (array[j].CompareTo(pivot) > 0)
                while (selector(array[j]).CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    array.SwapElement(i, j);
                    i++;
                    j--;
                }
            }
            if (low < j)
                array.QuickSort(low, j, selector);
            if (i < high)
                array.QuickSort(i, high, selector);
        }
        static void SwapElement<T>(this T[] array, int left, int right)
        {
            T temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }

        public static void Shuffle<T>(this T[] list)
        {
            Random rng = new Random();
            int n = list.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                list.SwapElement(k, n);
            }
        }
    }
}
