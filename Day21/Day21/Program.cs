﻿using System;
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
            Pattern = ".../.../...";

            // Der Schlüssel ist die Konvertierung
            // Man muss allein aus der Größe die Anzahl an kleineren Vierecken berechnen und dann entsprechend konvertieren

            // Note: 4x4 muss man nicht flippen, es gibt nur maximal 4 Permutationen
            // 3x3 muss geflippt werden, ergo maximal 8 Permutationen

            Console.WriteLine(EnhancePattern(FormattedRules, Pattern));
            PrintPattern(EnhancePattern(FormattedRules, Pattern));
        }


        private static string EnhancePattern(string[][] FormattedRules, string Pattern)
        {
            // Alle Permutationen durchgehen
            if (Pattern.Length == 5)
            {
                // Nur drehen 3 Mal
                for (int i = 0; i < 4; i++)
                {
                    Pattern = RotatePattern(Pattern);

                    // Jetzt mit Mustern vergleichen
                    foreach (var FormattedRule in FormattedRules)
                    {
                        if (Pattern == FormattedRule[0])
                        {
                            return FormattedRule[1];
                        }
                    }
                }
            }
            else if (Pattern.Length == 11)
            {
                // 3 Mal drehen 1 Mal flippen und 3 Mal drehen
                for (int i = 0; i < 4; i++)
                {
                    Pattern = RotatePattern(Pattern);

                    // Jetzt mit Mustern vergleichen
                    foreach (var FormattedRule in FormattedRules)
                    {
                        if (Pattern == FormattedRule[0])
                        {
                            return FormattedRule[1];
                        }
                    }
                }

                // Flippen
                Pattern = FlipPattern(Pattern);

                for (int i = 0; i < 4; i++)
                {
                    Pattern = RotatePattern(Pattern);

                    // Jetzt mit Mustern vergleichen
                    foreach (var FormattedRule in FormattedRules)
                    {
                        if (Pattern == FormattedRule[0])
                        {
                            return FormattedRule[1];
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Unmatching Length");
            }

            throw new Exception("Keine passende Regel gefunden");
        }


        // Immer im Uhrzeigersinn
        private static string RotatePattern(string Pattern)
        {
            if (Pattern.Length == 5)
            {
                return Pattern[3] + "" + Pattern[0] + "/" + Pattern[4] + Pattern[1];
            }
            else if (Pattern.Length == 11)
            {
                return Pattern[8] + "" + Pattern[4] + "" + Pattern[0] + "/" + Pattern[9] + "" + Pattern[5] + "" + Pattern[1] + "/" + Pattern[10] + "" + Pattern[6] + "" + Pattern[2];
            }
            else
            {
                throw new Exception("Unmatching length");
            }
        }


        // Nur für 3 gedacht
        private static string FlipPattern(string Pattern)
        {
            return Pattern[8] + "" + Pattern[9] + "" + Pattern[10] + "/" + Pattern[4] + "" + Pattern[5] + "" + Pattern[6] + "/" + Pattern[0] + "" + Pattern[1] + "" + Pattern[2];
        }


        /// <summary>
        /// Splits a 4x4 pattern into 4 2x2 patterns
        /// </summary>
        /// <returns>An array of 2x2 patterns</returns>
        /// <param name="Pattern">Pattern.</param>
        private static string[] SplitPattern(string Pattern)
        {
            string[] Patterns = new string[4];
            Patterns[0] = Pattern[0] + "" + Pattern[1] + "/" + Pattern[5] + "" + Pattern[6];
            Patterns[1] = Pattern[2] + "" + Pattern[3] + "/" + Pattern[7] + "" + Pattern[8];
            Patterns[2] = Pattern[10] + "" + Pattern[11] + "/" + Pattern[15] + "" + Pattern[16];
            Patterns[3] = Pattern[12] + "" + Pattern[13] + "/" + Pattern[17] + "" + Pattern[18];
            return Patterns;
        }


        /// <summary>
        /// Splits the whole pattern into smaller patterns
        /// </summary>
        /// <returns>The splitted patterns.</returns>
        /// <param name="Patterns">The whole pattern as an array.</param>
        private static string[] SplitPattern(string[] Patterns)
        {
            int Length = 0;
            foreach (var Pattern in Patterns)
            {
                Length += Pattern.Length == 5 ? 2 : 3;
            }
            // Länge von allen und jetzt Rettich ziehen
            Length = (int)Math.Sqrt(Length);

            // Die Patterns müssen irgendwie im Quadrat angeordnet werden
            if (Length % 2 == 0)
            {
                // Irgendwie über alle iterieren mit Länge und Riesendoppelarray erstellen
            }
            else
            {

            }
        }


        private static void PrintPattern(string Pattern)
        {
            foreach (var element in Pattern)
            {
                if (element == '/')
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(element);
                }
            }
            Console.WriteLine();
        }
    }
}
