using System;
using System.Collections.Generic;
using System.Text;

namespace InlämningsUppgift2
{
    class Sorting
    {
        public void BubbleSort<T>(T[] numbers) where T : IComparable
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
    }
}
