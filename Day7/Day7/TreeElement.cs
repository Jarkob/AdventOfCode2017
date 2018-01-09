using System;
using System.Collections.Generic;
namespace Day7
{
    public class TreeElement
    {
        public TreeElement(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.Children = new List<TreeElement>();
        }

        public string Name { get; set; }
        public int Weight { get; set; }
        public TreeElement Parent { get; set; }
        public List<TreeElement> Children { get; set; }

        public TreeElement GetRoot()
        {
            if (this.Parent == null)
            {
                return this;
            }
            else
            {
                return this.Parent.GetRoot();
            }
        }

        public void Add(string name, int weight)
        {
            this.Children.Add(new TreeElement(name, weight));
            this.Children[this.Children.Count - 1].Parent = this;
        }

        public int GetTotalWeight()
        {
            int TotalWeight = this.Weight;
            foreach (var child in this.Children)
            {
                TotalWeight += child.GetTotalWeight();
            }
            return TotalWeight;
        }

        public TreeElement FindInequality()
        {
            int Weight = this.Children[0].Weight;
            List<int> Temp1 = new List<int>();
            Temp1.Add(0);
            List<int> Temp2 = new List<int>();

            for (int i = 1; i < this.Children.Count; i++)
            {
                if(this.Children[i].Weight == Weight) {
                    Temp1.Add(i);
                } else {
                    Temp2.Add(i);
                }
            }

            // Wenn alle das gleiche Gewicht haben muss das Elterngewicht zurückgegeben werden
            if(Temp2.Count == 0) {
                return this;
                // oder this.parent
            } else if(Temp1.Count == 1 && Temp2.Count == 1) {
                // Beide müssen geprüft werden, aber woher weiß man, welcher der schwarze Peter ist
                // Insbesondere wenn die Verschachtelung noch weiter geht.

                // Es werden beide Elemente zwischengespeichert und dann das mit dem
                // kleineren Gewicht zurückgegeben, weil das im Baum weiter oben steht hehehe
                var Candidate1 = this.Children[Temp1[0]].FindInequality();
                var Candidate2 = this.Children[Temp2[0]].FindInequality();
                //return Candidate1.Weight > Candidate2.Weight ? Candidate1 : Candidate2; // später
                if(Candidate1.Weight > Candidate2.Weight) {
                    //return Candidate2; // Die Kandidaten können nicht direkt zurückgegeben werden
                    return this.GetRoot().GetElementByName(Candidate2.Name);
                } else if(Candidate1.Weight < Candidate2.Weight) {
                    //return Candidate1; // s.o.
                    return this.GetRoot().GetElementByName(Candidate1.Name);
                } else {
                    throw new Exception("Both weights are equal. This should not be the case.");
                }
            } else if(Temp1.Count > Temp2.Count) {
                return this.Children[Temp2[0]].FindInequality();
            } else if(Temp1.Count < Temp2.Count) {
                return this.Children[Temp1[0]].FindInequality();
            } else {
                throw new Exception("Diese Aufteilung gibt es nicht...");
            }
        }

        public TreeElement GetElementByName(string name)
        {
            if(this.Name == name) {
                return this;
            } else {
                foreach (var child in this.Children)
                {
                    if (child.GetElementByName(name) != null) {
                        return child.GetElementByName(name);
                    }
                }
                return null;
            }
        }

        public void PrintTree()
        {
            var Element = this.GetRoot();
            Element.PrintElement(0);
        }

        public void PrintElement(int level)
        {
            for (int i = 0; i < level; i++) {
                Console.Write("\t");
            }

            Console.WriteLine("|" + this.Name +"(Eigengewicht: "+ this.Weight +", Gesamtgewicht: "+ this.GetTotalWeight() +")|");
            if (this.Children.Count != 0)
            {
                level++;
                foreach (var child in this.Children)
                {
                    child.PrintElement(level);
                }
            }
        }
    }
}
