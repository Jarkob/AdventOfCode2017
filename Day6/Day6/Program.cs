using System;
using System.Collections.Generic;

namespace Day6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Part1();
            Part2();
        }


        public static void Part1()
        {
            int[] OldStorage = new int[] { 4, 1, 15, 12, 0, 9, 9, 5, 5, 8, 7, 3, 14, 5, 12, 3 };

            List<int[]> Results = new List<int[]>();
            int Counter = 0;
            bool SeenBefore = false;
            while (!SeenBefore)
            {
                int[] NewStorage = Redistribute(OldStorage);
                Counter++;
                OldStorage = null;
                OldStorage = (int[])NewStorage.Clone();

                foreach (var element in Results)
                {
                    if (CompareArrays(element, NewStorage))
                    {
                        SeenBefore = true;
                        break;
                    }
                }
                Results.Add(NewStorage);
                Print(NewStorage);
                NewStorage = null;
            }

            Console.WriteLine("It took {0} cycles", Counter);
            // 6681
        }


        public static void Part2()
        {
            int[] OldStorage = new int[] { 0, 14, 13, 12, 11, 10, 8, 8, 6, 6, 5, 3, 3, 2, 1, 10 };

            List<int[]> Results = new List<int[]>();
            int Counter = 0;
            bool SeenBefore = false;
            while (!SeenBefore)
            {
                int[] NewStorage = Redistribute(OldStorage);
                Counter++;
                OldStorage = null;
                OldStorage = (int[])NewStorage.Clone();

                foreach (var element in Results)
                {
                    if (CompareArrays(element, NewStorage))
                    {
                        SeenBefore = true;
                        break;
                    }
                }
                Results.Add(NewStorage);
                Print(NewStorage);
                NewStorage = null;
            }

            Console.WriteLine("It took {0} cycles", Counter);
            // 2393 is too high
            // 2392
        }


        private static void Print(int[] array)
        {
            foreach(var element in array) {
                Console.Write(element +", ");
            }
            Console.WriteLine();
        }


        private static bool CompareArrays(int[] array1, int[] array2)
        {
            if(array1.Length == array2.Length) {
                for (int i = 0; i < array1.Length; i++) {
                    if(array1[i] != array2[i]) {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }


        private static int[] Redistribute(int[] storage)
        {
            int[] newStorage = (int[])storage.Clone();
            // Find biggest Elementindex
            int MaxElementIndex = 0;
            for (int i = 1; i < newStorage.Length; i++)
            {
                if (newStorage[i] > newStorage[MaxElementIndex])
                {
                    MaxElementIndex = i;
                }
            }

            int Value = newStorage[MaxElementIndex];
            newStorage[MaxElementIndex] = 0;
            int Index = MaxElementIndex == newStorage.Length - 1 ? 0 : MaxElementIndex + 1;
            while (Value != 0)
            {
                newStorage[Index]++;
                Value--;
                Index = Index == newStorage.Length - 1 ? 0 : Index + 1;
            }
            return newStorage;
        }
    }
}
