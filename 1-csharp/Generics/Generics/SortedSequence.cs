using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    // behaves like a List<T> but keep itself sorted

    // you declare a class's type parameter with <(name)> right after the class name
    // after the "where" come type constraints
    //    e.g. class, struct, any specific type
    class SortedSequence<T> : IEnumerable<T> where T : class, new()
    {
        List<T> _list = new List<T>();

        // let's say for no reason
        // this class always starts out with one element in it
        // which will be when you get from calling the default ctor on Tasdfasfd
        public SortedSequence()
        {
            Add(new T());
        }

        public void Add(T item)
        {
            _list.Add(item);
            _list.Sort();
        }

        // so that we implement IEnumerable<T>
        // and we can use this class in a foreach now.
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_list).GetEnumerator();
        }

        // implement indexer operator []
        public T this[int i]
        {
            get => _list[i];
            set => _list[i] = value;
            // (using expression body syntax so it's shorter to write)
        }
    }
}
