using System;
using System.Collections.Generic;

namespace Day18
{
    public class Queue<T>
    {
        public List<T> List;

        public Queue()
        {
            this.List = new List<T>();
        }

        public void Enqueue(T newElement)
        {
            this.List.Add(newElement);
        }

        public T Dequeue()
        {
            T Tmp = this.List[0];
            this.List.RemoveAt(0);
            return Tmp;
        }
    }
}
