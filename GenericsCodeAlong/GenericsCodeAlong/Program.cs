using System;

namespace GenericsCodeAlong
{
    class Program
    {
        static void Main(string[] args)
        {
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);

            for (int i = 0; i < 5; i++)
            {
                intArray.SetItem(i, i * 5);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(intArray.GetItem(i) + " ");
            }

            MyGenericArray<char> charArray = new MyGenericArray<char>(5);

            for (int i = 0; i < 5; i++)
            {
                charArray.SetItem(i, (char)(i + 97));
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(charArray.GetItem(i) + " ");
            }

            Console.WriteLine("Length: " + charArray.length);
        }
    }
}
