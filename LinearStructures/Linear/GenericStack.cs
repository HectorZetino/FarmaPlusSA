using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasLineales.Linear
{
    class GenericStack<T>
    {
        T[] _items = null;
        int _currentIndex = 0;

        public GenericStack() : this(100) { }

        public GenericStack(int capacity)
        {
            _items = new T[capacity];
        }

        public GenericStack(T[] items, int currentIndex)
        {
            _items = items;
            _currentIndex = currentIndex;
        }

        public void push(T item)
        {
            if (_currentIndex >= _items.Length) { throw new StackOverflowException(); }

            _items[_currentIndex] = item;

            _currentIndex++;
        }

        public T pop()
        {

            if (_currentIndex <= 0) { throw new Exception(); }

            _currentIndex--;

            Console.WriteLine("current index: {0}", _currentIndex);

            return _items[_currentIndex];
        }

    }
}

