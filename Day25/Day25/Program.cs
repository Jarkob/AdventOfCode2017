using System;
using System.Collections.Generic;

namespace Day25
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int Steps = 12208951;
            char State = 'a';
            DoubleList<bool> Tape = new DoubleList<bool>();
            Tape.Add(false);
            int Position = 0;

            // Test
            //Console.WriteLine(Tape[0]);
            //Console.WriteLine(Tape.IndexExists(1));
            //Console.WriteLine(Tape.IndexExists(-1));

            //Tape.Add(true);
            //Tape.Add(true);
            //Tape.AddNegative(false);
            //Tape.AddNegative(false);
            //Tape.Print();

            Console.Write("Working");
            for (int i = 0; i < Steps; i++)
            {
                if (Steps % 100000 == 0)
                {
                    Console.Write(".");
                }

                // Wenn die Liste zu klein ist muss sie vergrößert werden
                if (!Tape.IndexExists(Position))
                {
                    if (Position > 0)
                    {
                        do
                        {
                            Tape.AddPositive(false);
                        } while (!Tape.IndexExists(Position));
                    }
                    else
                    {
                        do
                        {
                            Tape.AddNegative(false);
                        } while (!Tape.IndexExists(Position));
                    }
                }

                // Ausführen
                switch (State)
                {
                    case 'a':
                        if (Tape[Position])
                        {
                            // write 0; move one to left; continue with e
                            Tape[Position] = false;
                            Position--;
                            State = 'e';
                        }
                        else
                        {
                            Tape[Position] = true;
                            Position++;
                            State = 'b';
                        }
                        break;
                    case 'b':
                        if (Tape[Position])
                        {
                            Tape[Position] = false;
                            Position++;
                            State = 'a';
                        }
                        else
                        {
                            Tape[Position] = true;
                            Position--;
                            State = 'c';
                        }
                        break;
                    case 'c':
                        if (Tape[Position])
                        {
                            Tape[Position] = false;
                            Position++;
                            State = 'c';
                        }
                        else
                        {
                            Tape[Position] = true;
                            Position--;
                            State = 'd';
                        }
                        break;
                    case 'd':
                        if (Tape[Position])
                        {
                            Tape[Position] = false;
                            Position--;
                            State = 'f';
                        }
                        else
                        {
                            Tape[Position] = true;
                            Position--;
                            State = 'e';
                        }
                        break;
                    case 'e':
                        if (Tape[Position])
                        {
                            Tape[Position] = true;
                            Position--;
                            State = 'c';
                        }
                        else
                        {
                            Tape[Position] = true;
                            Position--;
                            State = 'a';
                        }
                        break;
                    case 'f':
                        if (Tape[Position])
                        {
                            Tape[Position] = true;
                            Position++;
                            State = 'a';
                        }
                        else
                        {
                            Tape[Position] = true;
                            Position--;
                            State = 'e';
                        }
                        break;
                    default:
                        throw new Exception("Unknown state: " + State);
                }
            }

            Console.WriteLine();

            Console.WriteLine("Calculating Checksum");
            int Sum = GetChecksum(Tape);

            Console.WriteLine("Checksum: " + Sum);
            // 4387
        }


        public static int GetChecksum(DoubleList<bool> Tape)
        {
            int Sum = 0;

            for (int i = 0; i < Tape.Negative.Count; i++)
            {
                if (Tape.Negative[i])
                {
                    Sum++;
                }
            }

            for (int j = 0; j < Tape.Positive.Count; j++)
            {
                if (Tape.Positive[j])
                {
                    Sum++;
                }
            }

            return Sum;
        }
    }
}
