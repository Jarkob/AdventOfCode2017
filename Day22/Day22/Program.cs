using System;
using System.IO;

namespace Day22
{
    class MainClass
    {
        public static void Main()
        {
            string[] Input = File.ReadAllLines("../../Day22.txt");

            //Input = null;

            //Input = new string[]
            //{
            //".........",
            //".........",
            //".........",
            //".....#...",
            //"...#.....",
            //".........",
            //".........",
            //"........."
            //};

            // Try to increase Grid by factor 3

            string[] NewInput = new string[Input.Length * 303];

            // erst leere Reihen
            for (int i = 0; i < Input.Length * 151; i++)
            {
                NewInput[i] = "";
                for (int j = 0; j < Input.Length * 303; j++)
                {
                    NewInput[i] += ".";
                }
            }

            // einfügen
            for (int i = Input.Length * 151; i < Input.Length * 152; i++)
            {
                NewInput[i] = "";
                for (int j = 0; j < Input.Length * 151; j++)
                {
                    NewInput[i] += ".";
                }

                NewInput[i] += Input[i - (Input.Length * 151)];

                for (int k = 0; k < Input.Length * 151; k++)
                {
                    NewInput[i] += ".";
                }
            }

            // mehr leere Reihen
            for (int i = Input.Length * 152; i < Input.Length * 303; i++)
            {
                NewInput[i] = "";
                for (int j = 0; j < Input.Length * 303; j++)
                {
                    NewInput[i] += ".";
                }
            }


            char[][] Grid = new char[NewInput.Length][];

            for (int i = 0; i < Grid.Length; i++)
            {
                Grid[i] = NewInput[i].ToCharArray();
            }

            Virus Test = new Virus(Grid, 12 + (Input.Length * 151), 12 + (Input.Length * 151));

            for (int j = 0; j < 10000; j++)
            {
                Test.Burst();
            }

            //Test.Print();

            Console.Write("Amount of Infections: " + Test.Infections);
            // 5460
        }
    }
}
