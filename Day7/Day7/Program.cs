using System;
using System.IO;
using System.Collections.Generic;

namespace Day7
{
    class MainClass
    {
        public static List<TreeElement> Tree;

        public static void Main(string[] args)
        {
            Tree = new List<TreeElement>();
            //Part1();
            Part2();
        }


        public static void Part1()
        {
            // Formatieren des Inputs
            string[] Lines = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/Day7/Day7/Day7.txt");

            // Test
            //string[] Lines = new string[] {"pbga (66)",
            //"xhth (57)",
            //"ebii (61)",
            //"havc (66)",
            //"ktlj (57)",
            //"fwft (72) -> ktlj, cntj, xhth",
            //"qoyq (66)",
            //"padx (45) -> pbga, havc, qoyq",
            //"tknk (41) -> ugml, padx, fwft",
            //"jptl (61)",
            //"ugml (68) -> gyxo, ebii, jptl",
            //"gyxo (61)",
            //"cntj (57)"};

            List<string> LowerTree = new List<string>();

            foreach (var Line in Lines)
            {
                if (Line.Contains("->"))
                {
                    LowerTree.Add(Line);
                }
            }

            string[][] FormattedTree = new string[LowerTree.Count][];
            string[] Temp1;
            string[] Temp2;

            for (int i = 0; i < LowerTree.Count; i++)
            {
                FormattedTree[i] = new string[2];
                Temp1 = LowerTree[i].Split('(');
                Temp2 = LowerTree[i].Split(')');
                FormattedTree[i][0] = Temp1[0];
                FormattedTree[i][1] = Temp2[1];
            }


            // Jetzt suchen
            string[] First = GetFirst(FormattedTree);
            Console.WriteLine("HEUREKA: " + First[0]);
            // cqmvs
        }

        public static void Part2()
        {
            string[] Lines = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/Day7/Day7/Day7.txt");

            List<ListElement> ListElements = new List<ListElement>();

            string TempName;
            int TempWeigth;
            string[] TempChildren;

            for (int i = 0; i < Lines.Length; i++)
            {
                TempName = Lines[i].Split(' ')[0].Trim();
                TempWeigth = Convert.ToInt32(Lines[i].Split('(')[1].Split(')')[0]);
                if (Lines[i].Contains("->"))
                {
                    TempChildren = Lines[i].Split('>')[1].Trim().Split(',');
                }
                else
                {
                    TempChildren = new string[0];
                }
                for (int j = 0; j < TempChildren.Length; j++)
                {
                    TempChildren[j] = TempChildren[j].Trim();
                }

                ListElements.Add(new ListElement(TempName, TempWeigth));

                foreach (var element in TempChildren)
                {
                    ListElements[ListElements.Count - 1].Children.Add(element);
                }
            }

            // Jetzt Tree bauen
            //foreach (var element in ListElements)
            //{
            //    Console.WriteLine(element);
            //}

            TreeElement Test = BuildTree(ListElements, FindIndex(ListElements, "cqmvs"));
            Console.WriteLine(Test.Name);
            //Test.PrintTree();

            // Ungleichgewicht ermitteln
            //int[] Cuckoo = new int[2]; // Der Index vom Kind mit dem falschen Gewicht

            //List<int> Temp1 = new List<int>();
            //Temp1.Add(Test.Children[0].Weight);
            //List<int> Temp2 = new List<int>();
            //for (int i = 1; i < Test.Children.Count; i++)
            //{
            //    if(Test.Children[i].Weight == Temp1[0]) {
            //        Temp1.Add(i);
            //    } else {
            //        Temp2.Add(i);
            //    }
            //}

            //Cuckoo[1] = -1;
            //if(Temp1.Count > Temp2.Count) {
            //    Cuckoo[0] = Temp2[0];
            //} else if(Temp1.Count < Temp2.Count) {
            //    Cuckoo[0] = Temp1[0];
            //} else { // Beide müssen geprüft werden
            //    Cuckoo[0] = Temp1[0];
            //    Cuckoo[1] = Temp2[0];
            //}

            //// Weiter prüfen...
            //if(Cuckoo[1] == -1) {
            //    // Check den Tree mit dem Index
            //} else {
            //    // Checke beide Trees mit den Indizes
            //}

            foreach(var child in Test.Children) {
                Console.WriteLine(child.Name +": ∑ = "+ child.GetTotalWeight());
            }


            // Test
            var Ungleich = Test.GetElementByName("vmttcwe");
            Console.WriteLine(Ungleich.Name +": ∑"+ Ungleich.GetTotalWeight() +", normal: "+ Ungleich.Weight);
            foreach(var child in Ungleich.Children) {
                Console.WriteLine(child.Name +": ∑"+ child.GetTotalWeight() +", normal: "+ child.Weight);
            }


            string SchlingelName = Test.FindInequality().Name;
            TreeElement Schlingel = Test.GetElementByName(SchlingelName);

            Console.WriteLine(Schlingel.Name +" ist der Übeltäter");
            Console.WriteLine("Schlingelgewicht: "+ Schlingel.Weight +", ∑: "+ Schlingel.GetTotalWeight());
            Console.WriteLine("Schlingelkinder:");
            foreach(var child in Schlingel.Children) {
                Console.WriteLine(child.Name +": "+ child.Weight +", ∑: "+ child.GetTotalWeight());
            }

            // Irgendwas hier ist unfassbar faul
            // Jedes eleement hat keine Parents oh mein Gott ich dummer Spast ich weiß auch wieso...

            // Trotzdem ist noch was faul, es wird irgendwie nicht der korrekte Branch verfolgt
            // ich logge gleich mal noch ein bisschen
            Test.PrintTree();

            // 8 is wrong
            // 2310
        }


        private static TreeElement BuildTree(List<ListElement> listElements, int index)
        {
            TreeElement TestElement = new TreeElement(listElements[index].Name, listElements[index].Weight);

            // Die Childindizes sammeln um alle anzuhängen
            List<int> ChildIndices = new List<int>();
            foreach (var child in listElements[index].Children)
            {
                ChildIndices.Add(FindIndex(listElements, child));
            }

            foreach (var childIndex in ChildIndices)
            {
                TestElement.Add(listElements[childIndex].Name, listElements[childIndex].Weight);
            }

            foreach (var child in TestElement.Children)
            {
                AddChildren(listElements, child);
            }

            return TestElement;
        }


        public static void AddChildren(List<ListElement> listElements, TreeElement parent)
        {
            int Index = FindIndex(listElements, parent.Name);

            // Die Childindizes sammeln um alle anzuhängen
            List<int> ChildIndices = new List<int>();
            foreach (var listElement in listElements[Index].Children)
            {
                ChildIndices.Add(FindIndex(listElements, listElement));
            }

            foreach (var childIndex in ChildIndices)
            {
                parent.Add(listElements[childIndex].Name, listElements[childIndex].Weight);
            }

            foreach (var child in parent.Children)
            {
                AddChildren(listElements, child);
            }
        }


        private static int FindIndex(List<ListElement> listElements, string name)
        {
            // Find the first element cqmvs
            int FirstIndex = -1;
            for (int i = 0; i < listElements.Count; i++)
            {
                if (listElements[i].Name == name)
                {
                    FirstIndex = i;
                    break;
                }
            }
            return FirstIndex;
        }


        private static string[] GetFirst(string[][] formattedTree)
        {
            bool IsFirst;
            for (int i = 0; i < formattedTree.Length - 1; i++)
            {
                IsFirst = true;
                for (int j = 0; j < i; j++)
                {
                    if (formattedTree[j][1].Contains(formattedTree[i][0].Trim()))
                    {
                        IsFirst = false;
                        break;
                    }
                }
                for (int k = i + 1; k < formattedTree.Length; k++)
                {
                    if (formattedTree[k][1].Contains(formattedTree[i][0].Trim()))
                    {
                        IsFirst = false;
                        break;
                    }
                }

                if (IsFirst)
                {
                    return formattedTree[i];
                }
            }
            return null;
        }


        private static void PrintFormattedTree(string[][] formattedTree)
        {
            foreach (var element in formattedTree)
            {
                foreach (var ele in element)
                {
                    Console.Write(ele + ";");
                }
                Console.WriteLine();
            }
        }
    }
}
