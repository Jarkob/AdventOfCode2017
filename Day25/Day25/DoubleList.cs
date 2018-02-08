using System;
using System.Collections.Generic;
namespace Day25
{
    public class DoubleList<T>
    {
        public List<T> Positive;
        public List<T> Negative;

        public DoubleList()
        {
            this.Positive = new List<T>();
            this.Negative = new List<T>();
        }


        public T this[int Index]
        {
            get
            {
                if (Index < 0)
                {
                    return Negative[(Index * - 1) - 1];
                }
                else
                {
                    return Positive[Index];
                }
            }
            set
            {
                if (Index < 0)
                {
                    Negative[(Index * - 1) - 1] = value;
                }
                else
                {
                    Positive[Index] = value;
                }
            }
        }

        public void Add(T Item)
        {
            this.Positive.Add(Item);
        }

        public void AddPositive(T Item)
        {
            this.Add(Item);
        }

        public void AddNegative(T Item)
        {
            this.Negative.Add(Item);
        }

        public bool IndexExists(int Index)
        {
            if(Index < 0) {
                return - Index <= this.Negative.Count;
            } else {
                return Index < this.Positive.Count;
            }
        }

        public void Print()
        {
            for (int i = Negative.Count - 1; i > -1; i--)
            {
                Console.Write(Convert.ToBoolean(Negative[i]) ? "1 " : "0 ");
            }

            Console.WriteLine();

            for (int j = 0; j < Positive.Count; j++) {
                Console.Write(Convert.ToBoolean(Positive[j]) ? "1 " : "0 ");
            }
        }
    }
}
