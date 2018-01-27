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

            // Es macht Sinn die Grenzen zuerst zu berechnen
            int Half = 151 * Input.Length;
            int End = ((Half * 2) + 1) * Input.Length;
            int HalfEnd = (Half + 1) * Input.Length;
            //int Limit;

            char[][] NewInput = new char[End][];

            // erst leere Reihen
            for (int i = 0; i < Half; i++)
            {
                NewInput[i] = new char[End];
                //for (int j = 0; j < End; j++)
                //{
                //    NewInput[i] += ".";
                //}
            }

            // einfügen
            for (int i = Half; i < HalfEnd; i++)
            {
                NewInput[i] = new char[End];
                for (int j = 0; j < Half; j++)
                {
                    NewInput[i][j] = '.';
                }

                //NewInput[i] += Input[i - Half];
                // Hier ist ein Problem
                for (int l = Half; l < Half + Input.Length; l++)
                {
                    NewInput[i][l] = Input[i - Half][l - Half];
                }

                for (int k = 0; k < Half; k++)
                {
                    NewInput[i][k] = '.';
                }
            }

            // mehr leere Reihen
            for (int i = HalfEnd; i < End; i++)
            {
                NewInput[i] = new char[End];
                //for (int j = 0; j < End; j++)
                //{
                //    NewInput[i] += ".";
                //}
            }


            //char[][] Grid = new char[NewInput.Length][];

            //for (int i = 0; i < Grid.Length; i++)
            //{
            //    Grid[i] = NewInput[i].ToCharArray();
            //}

            Virus Test = new Virus(NewInput, 12 + Half, 12 + Half);

            for (int j = 0; j < 10000; j++)
            {
                Console.WriteLine(j);
                Test.Burst();
            }

            //Test.Print();

            Console.Write("Amount of Infections: " + Test.Infections);
            // 5460
        }
    }
}
