using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämninguppgift1.Extensions
{
    static class SortExtensions
    {
        public static void BubbleSort(this int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int sort = 0; sort < numbers.Length - 1; sort++)
                {
                    if (numbers[sort] > numbers[sort + 1])
                    {
                        int temp = numbers[sort];
                        numbers[sort] = numbers[sort + 1];
                        numbers[sort + 1] = temp;
                    }
                }
            }
        }
        static void BubbleAnimate(int[] numbers, int sort)
        {
            System.Threading.Thread.Sleep(400);
            Console.Clear();
            foreach (var number in numbers)
            {
                if (number == numbers[sort])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(number + ", ");
                    Console.ResetColor();
                }
                else
                    Console.Write(number + ", ");
            }
        }

        public static void MergeSort(this int[] numbers)
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
        private static void Merge(this int[] numbers, int startL, int stopL,
            int startR, int stopR)
        {
            // Additional arrays needed for merging
            int[] right = new int[stopR - startR + 1];
            int[] left = new int[stopL - startL + 1];

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
            right[right.Length - 1] = int.MaxValue;
            left[left.Length - 1] = int.MaxValue;

            // Merge the two sorted arrays into the initial one
            for (int k = startL, m = 0, n = 0; k < stopR; k++)
            {
                if (left[m] <= right[n])
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


        public static void QuickSort(this int[] numbers)
        {
            numbers.QuickSort(0, numbers.Length - 1);
        }
        static void QuickSort(this int[] numbers, int low, int high)
        {
            int i = low, j = high;
            // Get the pivot element from the middle of the list
            int pivot = numbers[low + (high - low) / 2];

            // Divide into two lists
            while (i <= j)
            {
                // If the current value from the left list is smaller than the pivot
                // element then get the next element from the left list
                while (numbers[i] < pivot)
                {
                    i++;
                }
                // If the current value from the right list is larger than the pivot
                // element then get the next element from the right list
                while (numbers[j] > pivot)
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
        static void SwapElement(this int[] numbers, int left, int right)
        {
            int temp = numbers[left];
            numbers[left] = numbers[right];
            numbers[right] = temp;
        }
    }
}
