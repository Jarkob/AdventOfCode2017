﻿using System;
using System.IO;

namespace Day22
{
    class MainClass
    {
        public static void Main()
        {
            string[] Input = File.ReadAllLines("../../Day22.txt");

            // Test
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

            // Es macht Sinn die Grenzen zuerst zu berechnen
            int Half = 301 * Input.Length;
            int End = ((Half * 2) + 1) * Input.Length;
            int HalfEnd = (301 + 1) * Input.Length;

            char[][] NewInput = new char[End][];

            for (int i = Half; i < HalfEnd; i++)
            {
                NewInput[i] = new char[End];

                for (int l = Half; l < HalfEnd; l++)
                {
                    NewInput[i][l] = Input[i - Half][l - Half];
                }
            }

            // Test
            //NewInput = null;
            //NewInput = new char[Input.Length][];
            //for (int i = 0; i < Input.Length; i++) {
            //    NewInput[i] = Input[i].ToCharArray();
            //}

            Virus Test = new Virus(NewInput, 12 + Half, 12 + Half);
            // Test
            //Test = null;
            //Test = new Virus(NewInput, 4 + Half, 4 + Half);

            // measure
            int[] Values0 = new int[1000];
            int[] Values = new int[1000];


            for (int j = 0; j < 24000; j++)
            {
                if (j >= 22000 && j < 23000)
                {
                    Values0[j - 22000] = Test.Infections;
                }
                if (j >= 23000)
                {
                    Values[j - 23000] = Test.Infections;
                }
                Console.WriteLine("Infections after " + j + ": " + Test.Infections);
                //Test.Burst1(); // Part1
                Test.Burst2();
            }

            //Test.Print();
            int Average = Values0[999] - Values0[0];
            Console.WriteLine("change from 22000 to 23000 = " + (Values0[999] - Values0[0]));
            Console.WriteLine("change from 23000 to 24000 = " + (Values[999] - Values[0]));

            // 9976000
            int Result = Test.Infections + (9976000 / 1000 * Average);

            Console.Write("Amount of Infections: " + Result);
            // 5460
            // 3204753 too high
            // 3454 too low
            // 1420046 too low
        }
    }
}
