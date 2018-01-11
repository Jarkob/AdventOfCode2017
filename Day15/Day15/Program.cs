using System;

namespace Day15
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Part1()
            Part2();
        }


        public static void Part1()
        {
            int MatchingPairs = 0;

            // Generator A starts with 512
            // Generator B starts with 191

            long A = 512;
            long B = 191;

            string Abin;
            string Bbin;

            // Test
            //A = 65;
            //B = 8921;

            for (long i = 0; i < 40000000; i++)
            {
                A *= 16807;
                B *= 48271;

                A %= 2147483647;
                B %= 2147483647;

                //Console.WriteLine("{0,10} | {1,10}", A, B);

                Abin = Convert.ToString(Convert.ToInt64(A), 2);
                Bbin = Convert.ToString(Convert.ToInt64(B), 2);

                Abin = Abin.PadLeft(32, '0');
                Bbin = Bbin.PadLeft(32, '0');

                // Prüfen ob die letzten 16 bits übereinstimmen
                bool AreEqual = true;
                for (int j = 16; j < 32; j++)
                {
                    if (Abin[j] != Bbin[j])
                    {
                        AreEqual = false;
                        break;
                    }
                }

                if (AreEqual)
                {
                    MatchingPairs++;
                }
            }

            Console.WriteLine(MatchingPairs);
            // 567
        }


        public static void Part2()
        {
            int MatchingPairs = 0;

            long A = 512;
            long B = 191;

            string Abin;
            string Bbin;

            // Test
            //A = 65;
            //B = 8921;

            for (long i = 0; i < 5000000; i++)
            {
                do
                {
                    A *= 16807;
                    A %= 2147483647;
                } while (A % 4 != 0);

                do
                {
                    B *= 48271;
                    B %= 2147483647;
                } while (B % 8 != 0);

                Abin = Convert.ToString(Convert.ToInt64(A), 2);
                Bbin = Convert.ToString(Convert.ToInt64(B), 2);

                Abin = Abin.PadLeft(32, '0');
                Bbin = Bbin.PadLeft(32, '0');

                //Console.WriteLine(Abin);
                //Console.WriteLine(Bbin);
                //Console.WriteLine();

                // Prüfen ob die letzten 16 bits übereinstimmen
                bool AreEqual = true;
                for (int j = 16; j < 32; j++)
                {
                    if (Abin[j] != Bbin[j])
                    {
                        AreEqual = false;
                        break;
                    }
                }

                if (AreEqual)
                {
                    MatchingPairs++;
                }
            }

            Console.WriteLine("Matching Pairs: "+ MatchingPairs);
            // 323
        }
    }
}
