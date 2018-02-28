using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsCodeAlong
{
    public class MyGenericArray<T>
    {
        private T[] array;
        public int length;
        public MyGenericArray(int size)
        {
            array = new T[size];
            length = size;
        }

        public void SetItem(int index, T value)
        {
            array[index] = value;
        }

        public T GetItem(int index)
        {
            return array[index];
        }

    }
}
