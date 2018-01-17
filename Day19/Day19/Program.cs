using System;
using System.IO;

namespace Day19
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //string[] Diagram = File.ReadAllLines("../../Day19.txt"); // Achtung unten eine Leerzeile; Pfad verbessert hehe
            string[] Diagram = new string[]
            {
                "     |          ",
                "     |  +--+    ",
                "     A  |  C    ",
                " F---|----E|--+ ",
                "     |  |  |  D ",
                "     +B-+  +--+ "
            };

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

            int Letters = 0;

            string Command = "";

            // Eigentlich kann man solange fahren, bis man eine Kreuzung sieht,
            // nur dann müssen die möglichen Richtungen gesichtet werden und die Richtung gewechselt werden
            // Es reicht vermutlich aus, wenn ungleich Leerzeichen, aber trotzdem zählen ob mehr als 1
            // Achtung Top down Indizes
            while (true)
            {
                // Diagramm drucken
                PrintDiagram(Diagram, Position);

                // Wenn Buchstabe dann inkrementieren
                if(Char.IsLetter(Diagram[Position[1]][Position[0]]))
                {
                    Letters++;
                }

                // Schrittweise
                Console.WriteLine("Continue?");
                Command = Console.ReadLine();

                if(Command != "")
                {
                    break;
                }


                switch(Direction) {
                    case "down":
                        // Wenn Kreuzung
                        if(Diagram[Position[1]][Position[0]] == '+')
                        {
                            // Alle Routen checken
                            // up
                            if(Diagram[Position[1] - 1][Position[0]] > -1 && Diagram[Position[1] - 1][Position[0]] != ' ')
                            {

                            }

                            // right
                            if(Diagram[Position[1]][Position[0] + 1] < Diagram[Position[1]].Length && Diagram[Position[1]][Position[0] + 1] != ' ')
                            {
                                Position[0]++;
                            }

                            // down
                            if(Diagram[Position[1] + 1][Position[0]] < Diagram.Length && Diagram[Position[1] + 1][Position[0] + 1] != ' ')
                            {
                                Position[1]++;
                            }

                            // left
                            if(Diagram[Position[1]][Position[0] - 1] > -1 && Diagram[Position[1]][Position[0] - 1] != ' ')
                            {
                                Position[0]--;
                            }
                        } else {
                            Position[1]++;
                        }
                        break;
                    case "up":
                        // Wenn Kreuzung
                        if(Diagram[Position[1]][Position[0]] == '+')
                        {
                            // Alle Routen checken
                            // up
                            if(Diagram[Position[1] - 1][Position[0]] > -1 && Diagram[Position[1] - 1][Position[0]] != ' ')
                            {

                            }

                            // right
                            if(Diagram[Position[1]][Position[0] + 1] < Diagram[Position[1]].Length && Diagram[Position[1]][Position[0] + 1] != ' ')
                            {
                                Position[0]++;
                            }

                            // down
                            if(Diagram[Position[1] + 1][Position[0]] < Diagram.Length && Diagram[Position[1] + 1][Position[0] + 1] != ' ')
                            {
                                Position[1]++;
                            }

                            // left
                            if(Diagram[Position[1]][Position[0] - 1] > -1 && Diagram[Position[1]][Position[0] - 1] != ' ')
                            {
                                Position[0]--;
                            }
                        } else {
                            Position[1]--;
                        }
                        break;
                    case "left":
                        // Wenn Kreuzung
                        if(Diagram[Position[1]][Position[0]] == '+')
                        {
                            // Alle Routen checken
                            // up
                            if(Diagram[Position[1] - 1][Position[0]] > -1 && Diagram[Position[1] - 1][Position[0]] != ' ')
                            {

                            }

                            // right
                            if(Diagram[Position[1]][Position[0] + 1] < Diagram[Position[1]].Length && Diagram[Position[1]][Position[0] + 1] != ' ')
                            {
                                Position[0]++;
                            }

                            // down
                            if(Diagram[Position[1] + 1][Position[0]] < Diagram.Length && Diagram[Position[1] + 1][Position[0] + 1] != ' ')
                            {
                                Position[1]++;
                            }

                            // left
                            if(Diagram[Position[1]][Position[0] - 1] > -1 && Diagram[Position[1]][Position[0] - 1] != ' ')
                            {
                                Position[0]--;
                            }
                        } else {
                            Position[0]--;
                        }
                    break;
                    case "right":
                        // Wenn Kreuzung
                        if(Diagram[Position[1]][Position[0]] == '+')
                        {
                            // Alle Routen checken
                            // up
                            if(Diagram[Position[1] - 1][Position[0]] > -1 && Diagram[Position[1] - 1][Position[0]] != ' ')
                            {

                            }

                            // right
                            if(Diagram[Position[1]][Position[0] + 1] < Diagram[Position[1]].Length && Diagram[Position[1]][Position[0] + 1] != ' ')
                            {
                                Position[0]++;
                            }

                            // down
                            if(Diagram[Position[1] + 1][Position[0]] < Diagram.Length && Diagram[Position[1] + 1][Position[0] + 1] != ' ')
                            {
                                Position[1]++;
                            }

                            // left
                            if(Diagram[Position[1]][Position[0] - 1] > -1 && Diagram[Position[1]][Position[0] - 1] != ' ')
                            {
                                Position[0]--;
                            }
                        } else {
                            Position[0]++;
                        }
                        break;
                    default:
                        throw new Exception("Unknown Direction: " + Direction);
                }

                // lieber so
                // Welche Position?
                // lieber doch nicht
            }

            Console.WriteLine("Anzahl Buchstaben: "+ Letters);
        }


        private static void PrintDiagram(string[] Diagram, int[] Position)
        {
            for(int i = 0; i < Diagram.Length; i++)
            {
                for(int j = 0; j < Diagram[i].Length; j++)
                {
                    if(i != Position[1] || j != Position[0])
                    {
                        Console.Write(Diagram[i][j]);
                    } else {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
