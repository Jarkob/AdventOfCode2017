using System;
using System.IO;
using System.Collections.Generic;

namespace Day12
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Input formatieren
            string[] List = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/Day12/Day12/Day12.txt");

            int[][] FormattedList = new int[List.Length][];
            for (int i = 0; i < List.Length; i++)
            {
                //string FirstPart = List[i].Split(' ')[0];
                //int FirstNumber = Convert.ToInt32(FirstPart);

                string SecondPart = List[i].Split('>')[1];
                string[] SecondParts = SecondPart.Split(',');

                FormattedList[i] = new int[SecondParts.Length]; // nicht + 1
                //FormattedList[i][0] = FirstNumber;

                for (int j = 0; j < SecondParts.Length; j++)
                {
                    FormattedList[i][j] = Convert.ToInt32(SecondParts[j].Trim()); // nicht + 1
                }
            }


            // Nodes have to be created
            foreach(var element in FormattedList) {
                foreach(var elt in element) {
                    Console.Write(elt +", ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Amount: "+ GetAmount(0, FormattedList));
            // 145
            // That was easier than I tried to

            // Obviously die Liste muss resetted werden
            SeenElements.Clear();
            int NumberOfGroups = 0;

            for (int i = 0; i < FormattedList.Length; i++) {
                if(!SeenElements.Contains(i)) {
                    Console.WriteLine(GetAmount(i, FormattedList));
                    NumberOfGroups++;
                } else {
                    Console.WriteLine("Bereits enthalten");
                }
            }

            Console.WriteLine("Anzahl Gruppen: "+ NumberOfGroups);
            // 206 is too low
            // 207
        }


        public static List<int> SeenElements = new List<int>();


        public static int GetAmount(int index, int[][] FormattedList)
        {
            // Element in die Gesehenen aufnehmen
            SeenElements.Add(index);


            List<int> UnseenNeighbours = new List<int>();

            foreach(var element in FormattedList[index]) {
                if(!SeenElements.Contains(element)) {
                    UnseenNeighbours.Add(element);
                }
            }


            int Amount = 1;
            if(UnseenNeighbours.Count != 0) {
                foreach(var element in UnseenNeighbours) {
                    Amount += GetAmount(element, FormattedList);
                }
            }
            return Amount;
        }
    }
}
