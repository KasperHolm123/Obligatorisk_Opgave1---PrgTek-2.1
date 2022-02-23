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
        private LinkedList<T> _vampiresList = new LinkedList<T>();

        public void Enqueue(T item)
        {
            if (_vampiresList.Count == 0)
            {
                _vampiresList.AddLast(item);
            }
            else
            {
                var current = _vampiresList.First;

                while (current != null && current.Value.CompareTo(item) < 0)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    _vampiresList.AddLast(item);
                }
                else
                {
                    _vampiresList.AddBefore(current, item);
                }
            }
        }

        public T Dequeue()
        {
            if (_vampiresList.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T value = _vampiresList.First.Value;

            _vampiresList.RemoveFirst();

            return value;
        }

        public T Peek()
        {
            if (_vampiresList.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return _vampiresList.First.Value;
        }

        public void Clear()
        {
            _vampiresList.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _vampiresList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _vampiresList.GetEnumerator();
        }
    }
}
