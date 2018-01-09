using System;
using System.IO;

namespace Day2
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
            string[] Rows = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/Day2/Day2/Day2.txt");
            string[][] Spreadsheet = new string[Rows.Length][];

            for (int i = 0; i < Rows.Length; i++)
            {
                string[] Columns = Rows[i].Split('\t');
                Spreadsheet[i] = Columns;
            }

            int[] Sums = new int[Rows.Length];
            for (int k = 0; k < Spreadsheet.Length; k++)
            {
                // Get biggest and smallest value in row
                int MaxValue = Convert.ToInt32(Spreadsheet[k][0]);
                int MinValue = MaxValue;
                int CellValue;
                for (int i = 1; i < Spreadsheet[k].Length; i++)
                {
                    CellValue = Convert.ToInt32(Spreadsheet[k][i]);
                    if (CellValue > MaxValue)
                    {
                        MaxValue = CellValue;
                    }
                    if (CellValue < MinValue)
                    {
                        MinValue = CellValue;
                    }
                }

                // Set element in Sums as difference
                Sums[k] = MaxValue - MinValue;
            }

            int Sum = 0;
            foreach (var element in Sums)
            {
                Sum += element;
            }

            Console.WriteLine(Sum);
        }


        public static void Part2()
        {
            string[] Rows = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/Day2/Day2/Day2.txt");
            string[][] Spreadsheet = new string[Rows.Length][];

            for (int i = 0; i < Rows.Length; i++)
            {
                string[] Columns = Rows[i].Split('\t');
                Spreadsheet[i] = Columns;
            }

            int[] Results = new int[Rows.Length];
            for (int k = 0; k < Spreadsheet.Length; k++)
            {
                int FirstNumber;
                int SecondNumber;
                for (int i = 0; i < Spreadsheet[k].Length - 1; i++) {
                    FirstNumber = Convert.ToInt32(Spreadsheet[k][i]);
                    for (int j = i + 1; j < Spreadsheet[k].Length; j++) {
                        SecondNumber = Convert.ToInt32(Spreadsheet[k][j]);

                        if(FirstNumber % SecondNumber == 0) {
                            Results[k] = FirstNumber / SecondNumber;
                            break;
                        } else if(SecondNumber % FirstNumber == 0) {
                            Results[k] = SecondNumber / FirstNumber;
                            break;
                        }
                    }
                }
            }

            int Sum = 0;
            foreach (var element in Results)
            {
                Sum += element;
            }

            Console.WriteLine(Sum);
        }


        private static void PrintSpreadsheet(string[][] spreadsheet)
        {
            foreach (var row in spreadsheet)
            {
                foreach (var element in row)
                {
                    Console.Write(element + "; ");
                }
                Console.WriteLine();
            }
        }
    }
}
