using System;
using System.Collections.Generic;

namespace Day3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Part1();
            Part2();
        }


        public static void Part1()
        {
            /*
                 * 17  16  15  14  13
                 * 18   5   4   3  12
                 * 19   6   1   2  11
                 * 20   7   8   9  10
                 * 21  22  23---> ...
                 */

            // Dieses enthält int[] im Format {Wert, x, y}
            List<int[]> Schlange = new List<int[]>();
            Schlange.Add(new int[] { 1, 0, 0 });
            int SchlangeWidth = 1;
            int SchlangeHeight = 1;

            string Direction = "right";
            int X = 0;
            int Y = 0;
            string LastDirection = Direction;
            int StepsInLastDirection = 0;

            for (int i = 2; i <= 277678; i++)
            {

                // Neuer Versuch
                switch (Direction)
                {
                    case "right":
                        X++;
                        break;
                    case "up":
                        Y++;
                        break;
                    case "left":
                        X--;
                        break;
                    case "down":
                        Y--;
                        break;
                    default:
                        throw new Exception("Error");
                }

                Schlange.Add(new int[] { i, X, Y });


                // Nach einem bestimmten Intervall muss die Richtung geändert werden
                if (LastDirection == Direction)
                {
                    StepsInLastDirection++;
                }
                else
                {
                    StepsInLastDirection = 0;
                    LastDirection = Direction;
                }

                switch (Direction)
                {
                    case "up":
                    case "down":
                        if (StepsInLastDirection >= SchlangeHeight - 1)
                        {
                            Direction = Direction == "up" ? "left" : "right";
                            SchlangeHeight++;
                        }
                        break;
                    case "right":
                    case "left":
                        if (StepsInLastDirection >= SchlangeWidth - 1)
                        {
                            Direction = Direction == "right" ? "up" : "down";
                            SchlangeWidth++;
                        }
                        break;
                    default:
                        throw new Exception("Help");
                }
            }

            // Schlange ausgeben
            foreach (var element in Schlange)
            {
                Console.WriteLine(element[0] + ", " + element[1] + ", " + element[2]);
            }

            // Interessantes Element ist das Letzte mit dem Wert 277678
            int[] InterestingElement = Schlange[Schlange.Count - 1];

            // Die Distanz zum Ursprung ist |X| + |Y|
            int Distance = Math.Abs(InterestingElement[1]) + Math.Abs(InterestingElement[2]);

            Console.WriteLine(Distance);
            // Du bist ein Gott!
        }


        public static void Part2()
        {
            /*
             * 147  142  133  122   59
             * 304    5    4    2   57
             * 330   10    1    1   54
             * 351   11   23   25   26
             * 362  747  806--->   ...
            */

            // Dieses enthält int[] im Format {Wert, x, y}
            List<int[]> Schlange = new List<int[]>();
            Schlange.Add(new int[] { 1, 0, 0 });
            int SchlangeWidth = 1;
            int SchlangeHeight = 1;

            string Direction = "right";
            int X = 0;
            int Y = 0;
            string LastDirection = Direction;
            int StepsInLastDirection = 0;

            for (int i = 2; Schlange[Schlange.Count - 1][0] <= 277678; i++)
            {
                // Neuer Versuch
                switch (Direction)
                {
                    case "right":
                        X++;
                        break;
                    case "up":
                        Y++;
                        break;
                    case "left":
                        X--;
                        break;
                    case "down":
                        Y--;
                        break;
                    default:
                        throw new Exception("Error");
                }

                // Hier darf nicht einfach nur das Element reingeprügelt werden, sondern es muss der Wert berechnet werden
                int Value = 0;
                foreach(var element in Schlange) {
                    if((element[1] <= X + 1) && (element[1] >= X - 1) && (element[2] <= Y + 1) && (element[2] >= Y - 1)) {
                        Value += element[0];
                    }
                }

                // Jetzt neues Element hinzufügen
                Schlange.Add(new int[] { Value, X, Y });


                // Nach einem bestimmten Intervall muss die Richtung geändert werden
                if (LastDirection == Direction)
                {
                    StepsInLastDirection++;
                }
                else
                {
                    StepsInLastDirection = 0;
                    LastDirection = Direction;
                }

                switch (Direction)
                {
                    case "up":
                    case "down":
                        if (StepsInLastDirection >= SchlangeHeight - 1)
                        {
                            Direction = Direction == "up" ? "left" : "right";
                            SchlangeHeight++;
                        }
                        break;
                    case "right":
                    case "left":
                        if (StepsInLastDirection >= SchlangeWidth - 1)
                        {
                            Direction = Direction == "right" ? "up" : "down";
                            SchlangeWidth++;
                        }
                        break;
                    default:
                        throw new Exception("Help");
                }
            }

            // Schlange ausgeben
            foreach (var element in Schlange)
            {
                Console.WriteLine(element[0] + ", " + element[1] + ", " + element[2]);
            }

            // Jetzt ist das letzte Element interessant
            int[] InterestingElement = Schlange[Schlange.Count - 1];
            Console.WriteLine(InterestingElement[0]);

            // 371450 is too high
            // 279138 is right
            // Du bist immer noch ein Gott!
        }
    }
}
