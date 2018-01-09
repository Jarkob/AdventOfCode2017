using System;
using System.IO;

namespace Day4
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
            // This is a list of the passphrases
            // How many of them are valid?
            string[] Lines = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/Day4/Day4/Day4.txt");

            int ValidPassphrases = 0;
            foreach (var Line in Lines)
            {
                if (IsPassphraseValid1(Line))
                {
                    ValidPassphrases++;
                }
            }

            Console.WriteLine(ValidPassphrases);
            // 325
        }


        public static void Part2()
        {
            // This is a list of the passphrases
            // How many of them are valid?
            string[] Lines = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/Day4/Day4/Day4.txt");

            int ValidPassphrases = 0;
            foreach (var Line in Lines)
            {
                if (IsPassphraseValid2(Line))
                {
                    ValidPassphrases++;
                }
            }

            Console.WriteLine(ValidPassphrases);
            // 119
        }


        private static bool IsPassphraseValid1(string passphrase)
        {
            string[] Words = passphrase.Split(' ');

            for (int i = 0; i < Words.Length - 1; i++)
            {
                for (int j = i + 1; j < Words.Length; j++)
                {
                    if (Words[i] == Words[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        private static bool IsPassphraseValid2(string passphrase)
        {
            string[] Words = passphrase.Split(' ');

            for (int i = 0; i < Words.Length - 1; i++)
            {
                for (int j = i + 1; j < Words.Length; j++)
                {
                    if (Words[i] == Words[j] || IsAnagram(Words[i], Words[j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        private static bool IsAnagram(string word1, string word2)
        {
            char[] Elements2 = word2.ToCharArray();
            bool Contains;
            foreach(var element in word1) {
                Contains = false;
                for (int i = 0; i < Elements2.Length; i++) {
                    if(element == Elements2[i]) {
                        Contains = true;
                        Elements2[i] = ' ';
                        break;
                    }
                }
                if(!Contains) {
                    return false;
                }
            }

            foreach(var element in Elements2) {
                if(element != ' ') {
                    return false;
                }
            }

            return true;
        }
    }
}
