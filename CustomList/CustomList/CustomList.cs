using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    internal class CustomList<T>
    {

        T[] _items;
        public int Capacity;
        public T this[int index]
        {
            get { return _items[index]; }
        }

        public int Count;
        public CustomList()
        {
            Capacity = 4;
            _items = new T[Capacity];
            Count = 0;
        }
        public void Add(T item)
        {
            if (Count == Capacity)
            {
                Capacity *= 2; 
                Array.Resize(ref _items, Capacity);
            }
            _items[Count] = item;
            Count++;
        }
        public T Find(Predicate<T> method)
        {
            foreach (T item in _items)
            {
                if (method(item))
                {
                    return item;
                }
            }
            return default(T);
        }

        public CustomList<T> FindAll(Predicate<T> method)
        {
            CustomList<T> list = new CustomList<T>();
            foreach(T item in _items)
            {
                if (method(item))
                {
                    list.Add(item);

                }
            }
            return list;
        }


        public void ForEach(Action<T> action)
        {
            foreach(T a in _items)
            {
                action(a);
            }
        }
        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

    }
}
