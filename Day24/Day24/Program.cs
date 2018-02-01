using System;
using System.IO;
using System.Collections.Generic;

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
            // Möglicherweise macht es Sinn die Komponenten als Liste zu behandeln...

            List<Tuple<int, int>> Bridge = new List<Tuple<int, int>>();
            Bridge.Add(Components[StartIndex]);

            Console.WriteLine(GetStrength(Bridge));

            // Jetzt alle Kombinationen
            List<Tuple<int, int>> ComponentList = new List<Tuple<int, int>>(Components);
            // vielleicht lieber doch nicht


            int Index = 0;
            int Ports = Bridge[Index].Item2;

            Tuple<int, int>[] RestComponents = new Tuple<int, int>[Components.Length - 1];
            for (int i = 0; i < Components.Length; i++)
            {
                if(i != StartIndex) {
                    RestComponents[i] = Components[i]; // Funktioniert so nicht...
                }
            }

            for (int i = 0; i < Components.Length; i++)
            {
                if(Components[i].Item1 == Ports)
                {
                    
                }
            }
        }


        private static int GetStrength(List<Tuple<int, int>> Bridge)
        {
            return GetStrength(Bridge, 0);
        }

        private static int GetStrength(List<Tuple<int, int>> Bridge, int Index)
        {
            if(Index == Bridge.Count - 1)
            {
                return Bridge[Index].Item1 + Bridge[Index].Item2;
            } else {
                return Bridge[Index].Item1 + Bridge[Index].Item2 + GetStrength(Bridge, Index + 1);
            }
        }
    }
}
