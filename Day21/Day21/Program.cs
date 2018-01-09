using System;
using System.Collections.Generic;

namespace Day21
{
    // Unfinished
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string Pattern = ".#./..#/###";


            Pattern = Pattern.Replace("/", "");

            if(Pattern.Length % 2 == 0) {
                
            } else if(Pattern.Length % 3 == 0) {
                
            } else {
                throw new Exception("We have a problem");
            }
        }


        public static void RemoveSlashes(ref string Pattern)
        {
            Pattern.Replace("/", "");
        }


        public static string Increase(string Pattern)
        {
            if (Pattern == "../.#") {
                Pattern = "##./#../...";
            }

            if(Pattern == ".#./..#/###") {
                Pattern = "#..#/..../..../#..#";
            }
        }
    }
}
