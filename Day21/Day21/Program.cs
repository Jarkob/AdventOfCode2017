using System;
using System.IO;
using System.Collections.Generic;

namespace Day21
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Rules = File.ReadAllLines("../../Day21.txt");

            string[][] FormattedRules = new string[Rules.Length][];

            for (int i = 0; i < Rules.Length; i++)
            {
                FormattedRules[i] = Rules[i].Split('>');
                FormattedRules[i][0] = FormattedRules[i][0].Replace(" =", "");
                FormattedRules[i][1] = FormattedRules[i][1].Replace(" ", "");
            }


            string Pattern = ".#./..#/###";

            // Der Schlüssel ist die Konvertierung
            // Man muss allein aus der Größe die Anzahl an kleineren Vierecken berechnen und dann entsprechend konvertieren

            if (Pattern.Replace("/", "").Length % 2 == 0)
            {

            }
            else if (Pattern.Replace("/", "").Length % 3 == 0)
            {

            }
            else
            {
                throw new Exception("We have a problem");
            }
        }


        public static void RemoveSlashes(ref string Pattern)
        {
            Pattern.Replace("/", "");
        }
    }
}
