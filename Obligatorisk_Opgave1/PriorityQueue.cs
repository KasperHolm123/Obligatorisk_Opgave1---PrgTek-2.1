﻿using Obligatorisk_Opgave1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opgave1
{
    public class PriorityQueue<T> : INotifyCollectionChanged, IEnumerable<T> where T : IComparable<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public event NotifyCollectionChangedEventHandler CollectionChanged;

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
            OnCollectionChanged("Add");
        }

        public T Dequeue()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T value = _list.First.Value;

            _list.RemoveFirst();
            OnCollectionChanged("Remove");
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
        private void OnCollectionChanged(string operation)
        {
            if(CollectionChanged != null)
            {
                if (operation == "Add")
                    CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));

                else
                    CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            }
        }
        public void Clear()
        {
            _list.Clear();
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
