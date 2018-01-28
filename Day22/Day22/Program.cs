using System;
using System.IO;

namespace Day22
{
    class MainClass
    {
        public static void Main()
        {
            string[] Input = File.ReadAllLines("../../Day22.txt");

            // Test
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
            Test = null;
            Test = new Virus(NewInput, 4 + Half, 4 + Half);

            for (int j = 0; j < 10000000; j++)
            {
                Console.WriteLine(j);
                //Test.Burst1(); // Part1
                Test.Burst2();
            }

            //Test.Print();

            Console.Write("Amount of Infections: " + Test.Infections);
            // 5460
            // 3204753 too high
        }
    }
}
