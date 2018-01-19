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

            // Note: 4x4 muss man nicht flippen, es gibt nur maximal 4 Permutationen
            // 3x3 muss geflippt werden, ergo maximal 8 Permutationen

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


        private static void EnhancePattern(ref string Pattern)
        {

        }


        // Immer im Uhrzeigersinn
        private static string RotatePattern(string Pattern)
        {
            if (Pattern.Length == 5)
            {
		        return Pattern[3] +""+ Pattern[0] +"/"+ Pattern[4] + Pattern[1];
            }
            else if (Pattern.Length == 11)
            {
                return Pattern[8] +""+ Pattern[4] +""+ Pattern[0] +"/"+ Pattern[9] +""+ Pattern[5] +""+ Pattern[1] +"/"+ Pattern[10] +""+ Pattern[6] +""+ Pattern[2];
            }
            else
            {
                throw new Exception("Unmatching length");
            }
        }


        // Nur für 3 gedacht
        private static void FlipPattern(ref string Pattern)
        {

        }
    }
}
