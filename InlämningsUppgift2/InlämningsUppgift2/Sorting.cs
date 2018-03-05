using System;
using System.Collections.Generic;
using System.Text;

namespace InlämningsUppgift2
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

        static public void MergeSort<T>(this T[] array, int low, int high) where T : IComparable<T>
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort(array, low, middle);
                MergeSort(array, middle + 1, high);
                Merge(array, low, middle, high);
            }
        }

        static public void Merge<T>(this T[] array, int low, int middle, int high) where T : IComparable<T>
        {
            int left = low;
            int right = middle + 1;
            T[] tmp = new T[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (array[left].CompareTo(array[right]) < 0)
                {
                    tmp[tmpIndex] = array[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = array[right];
                    right = right + 1;
                }
                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = array[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = array[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                array[low + i] = tmp[i];
            }
        }


        public static void QuickSort<T>(this T[] array) where T : IComparable
        {
            array.QuickSort(0, array.Length - 1);
        }
        static void QuickSort<T>(this T[] array, int low, int high) where T : IComparable
        {
            int i = low, j = high;
            // Get the pivot element from the middle of the list
            T pivot = array[low + (high - low) / 2];

            // Divide into two lists
            while (i <= j)
            {
                // If the current value from the left list is smaller than the pivot
                // element then get the next element from the left list
                //while (numbers[i] < pivot)
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }
                // If the current value from the right list is larger than the pivot
                // element then get the next element from the right list
                //while (numbers[j] > pivot)
                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                // If we have found a value in the left list which is larger than
                // the pivot element and if we have found a value in the right list
                // which is smaller than the pivot element then we exchange the
                // values.
                // As we are done we can increase i and j
                if (i <= j)
                {
                    array.SwapElement(i, j);
                    i++;
                    j--;
                }
            }
            if (low < j)
                array.QuickSort(low, j);
            if (i < high)
                array.QuickSort(i, high);
        }
        static void SwapElement<T>(this T[] array, int left, int right)
        {
            T temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }


    }
}
