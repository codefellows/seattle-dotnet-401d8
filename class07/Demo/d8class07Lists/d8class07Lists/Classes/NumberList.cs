using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace d8class07Lists.Classes
{
    class NumberList<T> : IEnumerable<T>
    {
        // Set a declared Size
        T[] items = new T[5];
        // set the amount currently in the list
        int count; 

        public void Add(T item)
        {
            if(count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }

            items[count++] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        // Magic don't touch.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
