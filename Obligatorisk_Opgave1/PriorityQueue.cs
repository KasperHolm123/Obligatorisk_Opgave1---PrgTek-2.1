using Obligatorisk_Opgave1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opgave1
{
    public class PriorityQueue<T> : INotifyCollectionChanged, IPriorityQueue<T>, IEnumerable<T> where T : IComparable<T>, IPrioritizable
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;


        public LinkedList<T> _list = new LinkedList<T>();
        public int Count => throw new NotImplementedException();


        public void Enqueue(T item)
        {
            _list.AddLast(item);
            OnCollectionChanged();
        }

        public void Enqueue(T item, int p)
        {
            if (_list.Count == 0)
                _list.AddLast(item);
            else
            {
                var current = _list.First;
                while (current != null && current.Value.Priority < p)
                    current = current.Next;

                if (current == null)
                    _list.AddLast(item);
                else
                    _list.AddBefore(current, item);
            }
            OnCollectionChanged();
        }

        public T Dequeue()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("The queue is empty");

            T value = _list.First.Value;

            _list.RemoveFirst();
            OnCollectionChanged();
            return value;
        }

        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("The queue is empty");

            return _list.First.Value;
        }
        public void Clear()
        {
            _list.Clear();
        }
        public T[] ToArray()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        private void OnCollectionChanged()
        {
            if(CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
