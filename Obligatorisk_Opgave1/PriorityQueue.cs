using Obligatorisk_Opgave1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opgave1
{
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        public LinkedList<T> _list = new LinkedList<T>();

        public void Enqueue(T item)
        {
            if (_list.Count == 0)
            {
                _list.AddLast(item);
            }
            else
            {
                var current = _list.First;

                while (current != null && current.Value.CompareTo(item) < 0)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    _list.AddLast(item);
                }
                else
                {
                    _list.AddBefore(current, item);
                }
            }
        }

        public T Dequeue()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T value = _list.First.Value;

            _list.RemoveFirst();

            return value;
        }

        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return _list.First.Value;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public IEnumerable VampireList
        {
            get { return _list; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
