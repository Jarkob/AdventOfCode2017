using System;
using System.Collections.Generic;
namespace Day7
{
    public class ListElement
    {
        public ListElement(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.Children = new List<string>();
        }

        public ListElement(string name, int weight, List<string> children)
        {
            this.Name = name;
            this.Weight = weight;
            this.Children = new List<string>();
            foreach(var child in children) {
                Children.Add(child);
            }
        }

        public string Name { get; set; }
        public int Weight { get; set; }
        public List<string> Children { get; set; }


        public override string ToString()
        {
            return string.Format("[ListElement: Name={0}, Weight={1}, Children={2}]", Name, Weight, Children.ToString());
        }
    }
}
