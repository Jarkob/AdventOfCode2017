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

            // Test
            Input = null;
            Input = new string[] { "0/2", "2/2", "2/3", "3/4", "3/5", "0/1", "10/1", "9/10" };

            Tuple<int, int>[] Components = new Tuple<int, int>[Input.Length];

            for (int i = 0; i < Input.Length; i++)
            {
                Components[i] = new Tuple<int, int>(Convert.ToInt32(Input[i].Split('/')[0]), Convert.ToInt32(Input[i].Split('/')[1]));
            }

            // Jetzt gehts los
            int Result = FindMaxLength(new List<Tuple<int, int>>(Components));
            Console.WriteLine("Result: " + Result);
        }


        // Es gibt mehrere Anfangsmöglichkeiten
        private static int FindMaxLength(List<Tuple<int, int>> ComponentList)
        {
            List<int> StartIndices = new List<int>();
            for (int i = 0; i < ComponentList.Count; i++)
            {
                if (ComponentList[i].Item1 == 0)
                {
                    StartIndices.Add(i);
                }
            }

            int Max = -1;

            for (int j = 0; j < StartIndices.Count; j++)
            {
                List<Tuple<int, int>> Bridge = new List<Tuple<int, int>>();
                Bridge.Add(ComponentList[StartIndices[j]]);
                List<Tuple<int, int>> RemainingComponents = new List<Tuple<int, int>>(ComponentList);
                RemainingComponents.RemoveAt(StartIndices[j]);

                if(FindMaxLength(Bridge, RemainingComponents, GetStrength(Bridge)) > Max) {
                    Max = FindMaxLength(Bridge, RemainingComponents, GetStrength(Bridge));
                }
            }

            return Max;
        }

        private static int FindMaxLength(List<Tuple<int, int>> Bridge, List<Tuple<int, int>> ComponentList, int MaxLength)
        {
            Console.WriteLine("Aufruf von findmaxlength");
            int Ports = Bridge[Bridge.Count - 1].Item2;

            // Erstmal mögliche Kombinationen raussuchen
            List<Tuple<int, int>> PossibleFollowers = new List<Tuple<int, int>>();
            for (int i = 0; i < ComponentList.Count; i++)
            {
                if (ComponentList[i].Item1 == Ports)
                {
                    PossibleFollowers.Add(new Tuple<int, int>(ComponentList[i].Item1, ComponentList[i].Item2));
                } else if(ComponentList[i].Item2 == Ports) {
                    PossibleFollowers.Add(new Tuple<int, int>(ComponentList[i].Item2, ComponentList[i].Item1));

                    // in Remainingcomponents muss das ding auch umgedreht werden
                    ComponentList[i] = new Tuple<int, int>(ComponentList[i].Item2, ComponentList[i].Item1);
                }
            }
            // PossibleFollowers sind jetzt alle Elemente die auf Ports folgen könnten
            Console.WriteLine("Possiblefollowers wurden identifiziert");

            // Wenn es PossibleFollower gibt müssen diese weiter geprüft werden
            if (PossibleFollowers.Count > 0)
            {
                for (int i = 0; i < PossibleFollowers.Count; i++)
                {
                    List<Tuple<int, int>> TestBridge = new List<Tuple<int, int>>(Bridge);
                    TestBridge.Add(PossibleFollowers[i]);

                    List<Tuple<int, int>> RemainingComponents = new List<Tuple<int, int>>(ComponentList);
                    // Removen
                    for (int j = 0; j < RemainingComponents.Count; j++)
                    {
                        if (RemainingComponents[j].Item1 == PossibleFollowers[i].Item1 && RemainingComponents[j].Item2 == PossibleFollowers[i].Item2)
                        {
                            RemainingComponents.RemoveAt(j);
                            break;
                        }
                    }

                    if (FindMaxLength(TestBridge, RemainingComponents, MaxLength) > MaxLength)
                    {
                        MaxLength = FindMaxLength(TestBridge, RemainingComponents, MaxLength);
                    }
                }

                return MaxLength;
            }
            else
            {
                //PrintBridge(Bridge);
                return GetStrength(Bridge) > MaxLength ? GetStrength(Bridge) : MaxLength;
            }
        }



        private static int GetStrength(List<Tuple<int, int>> Bridge)
        {
            return GetStrength(Bridge, 0);
        }

        private static int GetStrength(List<Tuple<int, int>> Bridge, int Index)
        {
            if (Index == Bridge.Count - 1)
            {
                return Bridge[Index].Item1 + Bridge[Index].Item2;
            }
            else
            {
                return Bridge[Index].Item1 + Bridge[Index].Item2 + GetStrength(Bridge, Index + 1);
            }
        }


        private static void PrintBridge(List<Tuple<int, int>> Bridge)
        {
            Console.Write("Bridge: ");
            for (int i = 0; i < Bridge.Count; i++)
            {
                if (i + 1 % 10 == 0)
                {
                    Console.WriteLine();
                }

                Console.Write(Bridge[i].Item1 + "/" + Bridge[i].Item2 + "--");
            }
            Console.WriteLine();
        }
    }
}
