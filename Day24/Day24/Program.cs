using System;
using System.IO;

namespace Day24
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../Day24.txt");

            Tuple<int, int>[] Components = new Tuple<int, int>[Input.Length];

            int StartIndex = -1;

            for (int i = 0; i < Input.Length; i++)
            {
                Components[i] = new Tuple<int, int>(Convert.ToInt32(Input[i].Split('/')[0]), Convert.ToInt32(Input[i].Split('/')[1]));

                if (Components[i].Item1 == 0)
                {
                    StartIndex = i;
                }
            }

            // Alle möglichen Kombinationen ausprobieren, rekursiv
        }
    }
}
