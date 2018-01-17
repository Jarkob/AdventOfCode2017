using System;
using System.IO;

namespace Day19
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Diagram = File.ReadAllLines("../../Day19.txt"); // Achtung unten eine Leerzeile; Pfad verbessert hehe
            //Diagram = new string[]
            //{
            //    "     |          ",
            //    "     |  +--+    ",
            //    "     A  |  C    ",
            //    " F---|----E|--+ ",
            //    "     |  |  |  D ",
            //    "     +B-+  +--+ "
            //};

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

            string Letters = "";

            int Steps = 0;

            string Command = "";

            // Achtung Top down Indizes

            // Wenn irgendein Index aus dem Feld rausgeht, terminiert das Programm
            while (Position[0] > -1 && Position[0] < Diagram[0].Length
                   && Position[1] > -1 && Position[1] < Diagram.Length
                   && Diagram[Position[1]][Position[0]] != ' ')
            {
                // Diagramm drucken
                //PrintDiagram(Diagram, Position);

                // Steps erhöhen
                Steps++;

                // Wenn Buchstabe dann inkrementieren
                if (Char.IsLetter(Diagram[Position[1]][Position[0]]))
                {
                    Letters += Diagram[Position[1]][Position[0]];

                    // Von Buchstabe zu Buchstabe
                    //PrintDiagram(Diagram, Position);

                    //Console.WriteLine("Gefundener Buchstabe: "+ Diagram[Position[1]][Position[0]]);
                    //Console.WriteLine("Continue?");
                    //Command = Console.ReadLine();

                    //if(Command != "")
                    //{
                    //    break;
                    //}
                }

                // Schrittweise
                //Console.WriteLine("Continue?");
                //Command = Console.ReadLine();

                //if(Command != "")
                //{
                //    break;
                //}


                switch (Direction)
                {
                    case "down":
                        // Wenn Kreuzung
                        if (Diagram[Position[1]][Position[0]] == '+')
                        {
                            if (Position[0] + 1 < Diagram[Position[1]].Length && Diagram[Position[1]][Position[0] + 1] != ' ')
                            {
                                Position[0]++;
                                Direction = "right";
                                break;
                            }
                            else if (Position[0] - 1 > -1 && Diagram[Position[1]][Position[0] - 1] != ' ')
                            {
                                Position[0]--;
                                Direction = "left";
                                break;
                            } else {
                                throw new Exception("Keine Richtung gefunden");
                            }
                        }
                        else
                        {
                            Position[1]++;
                        }
                        break;
                    case "up":
                        // Wenn Kreuzung
                        if (Diagram[Position[1]][Position[0]] == '+')
                        {
                            if (Position[0] + 1 < Diagram[Position[1]].Length && Diagram[Position[1]][Position[0] + 1] != ' ')
                            {
                                Position[0]++;
                                Direction = "right";
                                break;
                            }
                            else if (Position[0] - 1 > -1 && Diagram[Position[1]][Position[0] - 1] != ' ')
                            {
                                Position[0]--;
                                Direction = "left";
                                break;
                            } else {
                                throw new Exception("Keine Richtung gefunden");
                            }
                        }
                        else
                        {
                            Position[1]--;
                        }
                        break;
                    case "left":
                        // Wenn Kreuzung
                        if (Diagram[Position[1]][Position[0]] == '+')
                        {
                            if (Position[1] - 1 > -1 && Diagram[Position[1] - 1][Position[0]] != ' ')
                            {
                                Position[1]--;
                                Direction = "up";
                                break;
                            }
                            else if (Position[1] + 1 < Diagram.Length && Diagram[Position[1] + 1][Position[0]] != ' ')
                            {
                                Position[1]++;
                                Direction = "down";
                                break;
                            } else {
                                throw new Exception("Keine Richtung gefunden");
                            }
                        }
                        else
                        {
                            Position[0]--;
                        }
                        break;
                    case "right":
                        // Wenn Kreuzung
                        if (Diagram[Position[1]][Position[0]] == '+')
                        {
                            // Alle Routen checken
                            // up
                            if (Position[1] - 1 > -1 && Diagram[Position[1] - 1][Position[0]] != ' ')
                            {
                                Position[1]--;
                                Direction = "up";
                                break;
                            } else if (Position[1] + 1 < Diagram.Length && Diagram[Position[1] + 1][Position[0]] != ' ')
                            {
                                Position[1]++;
                                Direction = "down";
                                break;
                            } else {
                                throw new Exception("Keine Richtung gefunden");
                            }

                            // right
                            //if(Position[0] + 1 < Diagram[Position[1]].Length && Diagram[Position[1]][Position[0] + 1] != ' ')
                            //{
                            //    Position[0]++;
                            //    Direction = "right";
                            //    break;
                            //}

                            // left
                            //if(Diagram[Position[1]][Position[0] - 1] > -1 && Diagram[Position[1]][Position[0] - 1] != ' ')
                            //{
                            //    Position[0]--;
                            //}
                        }
                        else
                        {
                            Position[0]++;
                        }
                        break;
                    default:
                        throw new Exception("Unknown Direction: " + Direction);
                }
            }

            Console.WriteLine("Endposition: " + Position[0] + ", " + Position[1]);
            Console.WriteLine("Buchstaben: " + Letters);
            // GINOWKYXH

            Console.WriteLine("Anzahl Schritte: "+ Steps);
            // 16636
        }


        private static void PrintDiagram(string[] Diagram, int[] Position)
        {
            for (int i = 0; i < Diagram.Length; i++)
            {
                for (int j = 0; j < Diagram[i].Length; j++)
                {
                    if (i != Position[1] || j != Position[0])
                    {
                        Console.Write(Diagram[i][j]);
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
