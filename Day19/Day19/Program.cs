using System;
using System.IO;

namespace Day19
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Diagram = File.ReadAllLines("../../Day19.txt"); // Achtung unten eine Leerzeile; Pfad verbessert hehe

            // Start ermitteln
            int Start = -1;

            for (int i = 0; i < Diagram[0].Length; i++)
            {
                if (Diagram[0][i] == '|')
                {
                    Start = i;
                    break;
                }
            }

            // Erstmal bis zum ersten Buchstaben
            int[] Position = new int[] { Start, 0 }; // x/y
            string Direction = "down";

            while (true)
            {
                switch(Direction) {
                    case "down":
                        break;
                    case "up":
                        break;
                    case "left":
                        break;
                    case "right":
                        break;
                    default:
                        throw new Exception("Unknown Direction: " + Direction);
                }

                // oder so
                // Welche Position?
                // to be continued...
            }
        }
    }
}