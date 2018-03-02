using System;
using System.Collections.Generic;
using System.Text;

namespace InlämningsUppgift2
{
    static class Sorting
    {
        public static void BubbleSort<T>(this T[] numbers) where T : IComparable
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int sort = 0; sort < numbers.Length - 1; sort++)
                {
                    if (numbers[sort].CompareTo(numbers[sort + 1]) > 0)
                    {
                        T temp = numbers[sort];
                        numbers[sort] = numbers[sort + 1];
                        numbers[sort + 1] = temp;
                    }
                }
            }
        }

        public static void MergeSort<T>(this T[] numbers) where T : IComparable
        {
            if (numbers.Length < 2)
                return;

            int step = 1;
            int startL, startR;

            while (step < numbers.Length)
            {
                startL = 0;
                startR = step;
                while (startR + step <= numbers.Length)
                {
                    numbers.Merge(startL, startL + step, startR, startR + step);
                    startL = startR + step;
                    startR = startL + step;
                }
                if (startR < numbers.Length)
                {
                    numbers.Merge(startL, startL + step, startR, numbers.Length);
                }
                step *= 2;
            }
        }

        // Merge to already sorted blocks
        private static void Merge<T>(this T[] numbers, int startL, int stopL,
            int startR, int stopR) where T : IComparable
        {
            // Additional arrays needed for merging
            T[] right = new T[stopR - startR + 1];
            T[] left = new T[stopL - startL + 1];

            // Copy the elements to the additional arrays
            for (int i = 0, k = startR; i < (right.Length - 1); i++, k++)
            {
                right[i] = numbers[k];
            }
            for (int i = 0, k = startL; i < (left.Length - 1); i++, k++)
            {
                left[i] = numbers[k];
            }

            // Sentinel values
            //right[right.Length - 1] =  int.MaxValue;
            //left[left.Length - 1] = int.MaxValue;

            // Merge the two sorted arrays into the initial one
            for (int k = startL, m = 0, n = 0; k < stopR; k++)
            {
                //if (left[m] <= right[n])
                if (left[m].CompareTo(right[n]) <= 1)
                {
                    numbers[k] = left[m];
                    m++;
                }
                else
                {
                    numbers[k] = right[n];
                    n++;
                }
            }
        }


        public static void QuickSort<T>(this T[] numbers) where T : IComparable
        {
            numbers.QuickSort(0, numbers.Length - 1);
        }
        static void QuickSort<T>(this T[] numbers, int low, int high) where T : IComparable
        {
            int i = low, j = high;
            // Get the pivot element from the middle of the list
            T pivot = numbers[low + (high - low) / 2];

            // Divide into two lists
            while (i <= j)
            {
                // If the current value from the left list is smaller than the pivot
                // element then get the next element from the left list
                //while (numbers[i] < pivot)
                while (numbers[i].CompareTo(pivot) < 0)
                {
                    i++;
                }
                // If the current value from the right list is larger than the pivot
                // element then get the next element from the right list
                //while (numbers[j] > pivot)
                while (numbers[j].CompareTo(pivot) > 0)
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
                    numbers.SwapElement(i, j);
                    i++;
                    j--;
                }
            }
            if (low < j)
                numbers.QuickSort(low, j);
            if (i < high)
                numbers.QuickSort(i, high);
        }
        static void SwapElement<T>(this T[] numbers, int left, int right)
        {
            T temp = numbers[left];
            numbers[left] = numbers[right];
            numbers[right] = temp;
        }


    }
}
