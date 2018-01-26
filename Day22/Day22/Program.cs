using System;
using System.IO;

namespace Day22
{
    class MainClass
    {
        public static void Main()
        {
            string[] Input = File.ReadAllLines("../../Day22.txt");

            Input = null;

            Input = new string[]
            {
            ".........",
            ".........",
            ".........",
            ".....#...",
            "...#.....",
            ".........",
            ".........",
            "........."
            };

            // Try to increase Grid by factor 3

            string[] NewInput = new string[Input.Length * 3];

            // erst leere Reihen
            for (int i = 0; i < Input.Length; i++)
            {
                NewInput[i] = "";
                for (int j = 0; j < Input.Length * 3; j++)
                {
                    NewInput[i] += ".";
                }
            }

            // einfügen
            for (int i = Input.Length; i < Input.Length * 2; i++)
            {
                NewInput[i] = "";
                for (int j = 0; j < Input.Length; j++)
                {
                    NewInput[i] += ".";
                }

                NewInput[i] += Input[i - Input.Length];

                for (int k = 0; k < Input.Length; k++)
                {
                    NewInput[i] += ".";
                }
            }

            // mehr leere Reihen
            for (int i = Input.Length * 2; i < Input.Length * 3; i++)
            {
                NewInput[i] = "";
                for (int j = 0; j < Input.Length * 3; j++)
                {
                    NewInput[i] += ".";
                }
            }


            char[][] Grid = new char[NewInput.Length][];

            for (int i = 0; i < Grid.Length; i++)
            {
                Grid[i] = NewInput[i].ToCharArray();
            }

            Virus Test = new Virus(Grid, 4 + Input.Length, 4 + Input.Length);

            for (int j = 0; j < 10000; j++)
            {
                Test.Burst();
            }

            Test.Print();

            Console.Write("Amount of Infections: " + Test.Infections);
        }
    }
}
