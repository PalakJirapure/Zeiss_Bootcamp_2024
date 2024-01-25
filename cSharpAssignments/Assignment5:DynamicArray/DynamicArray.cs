using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArrayAssignment
{
    public class DynamicArray<T> : IDynamicArray<T>
    {
        private T[] array;
        private int count;

        public DynamicArray(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.");
            }

            array = new T[capacity];
            count = 0;
        }

        public void Add(int index, T item)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            // Check if the array needs to be resized
            ResizeArrayIfNeeded();

            // Shift elements to make space for the new item
            for (int i = count - 1; i >= index; i--)
            {
                array[i + 1] = array[i];
            }

            // Insert the new item at the specified index
            array[index] = item;
            count++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }

                return array[index];
            }
        }

        public int Count
        {
            get { return count; }
        }

        private void ResizeArrayIfNeeded()
        {
            if (count == array.Length)
            {
                T[] newArray = new T[array.Length * 2];
                Array.Copy(array, newArray, array.Length);
                array = newArray;
            }
        }
    }

}
