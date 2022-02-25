using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opgave1
{
    public interface IPriorityQueue<T> :IEnumerable<T>
    {
        void Enqueue(T elem);
        void Enqueue(T elem, int p);
        T Dequeue();
        void Remove(T elem);
        T Peek();
        void Clear();
        int Count { get; }
        T[] ToArray();
    }
}
