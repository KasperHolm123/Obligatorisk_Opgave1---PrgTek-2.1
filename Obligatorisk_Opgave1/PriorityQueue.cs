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
    public class PriorityQueue<T> : INotifyCollectionChanged, IPriorityQueue<T>, IEnumerable<T>  where T : IPrioritizable
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public LinkedList<T> _list = new LinkedList<T>(); // Linkedlist that contains all objects
        public int Count => _list.Count;

        public void Enqueue(T item)
        {
            _list.AddLast(item);
            OnCollectionChanged();
        }

        public void Enqueue(T item, int p)
        {
            if (_list.Count == 0) // If the queue is empty, AddLast() the item.
                _list.AddLast(item);
            else
            {
                var current = _list.First; // current item.
                while (current != null && current.Value.Priority > p) // Check the current item's proprity against the new item
                    current = current.Next; // Go to the next item if current item has a higher priority than the new item.

                if (current == null) // If we ended up at the last item (null), add the new item to the end of the queue
                    _list.AddLast(item);
                else // Otherwise add it before the current item.
                    _list.AddBefore(current, item);
            }
            OnCollectionChanged();
        }

        public T Dequeue()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Køen er tom");

            T value = _list.First.Value;

            _list.RemoveFirst(); // Remove the first item in the queue.
            OnCollectionChanged();
            return value; // Return the first item in the queue.
        }

        public void Remove(T item)
        {
            _list.Remove(item);
            OnCollectionChanged();
        }
        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Køen er tom");

            return _list.First.Value;
        }

        public void Clear()
        {
            _list.Clear();
            OnCollectionChanged();
        }

        public T[] ToArray()
        {
            return _list.ToArray();
        }

        int IPriorityQueue<T>.Count => throw new NotImplementedException();

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        private void OnCollectionChanged() // Raises the NotifyCollectionChanged event to update the view.
        {
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        T[] IPriorityQueue<T>.ToArray()
        {
            return _list.ToArray();
        }
    }
}
