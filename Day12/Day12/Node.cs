using System;
using System.Collections.Generic;
namespace Day12
{
    public class Node
    {
        public Node(int index)
        {
            this.Index = index;
            this.FollowingNodes = new List<Node>();
        }

        public int Index { get; private set; }
        public List<Node> FollowingNodes { get; set; }

        public void AddNode(Node newNode)
        {
            this.FollowingNodes.Add(newNode);
            newNode.FollowingNodes.Add(this);
        }

        public Node GetNode(List<Node> SeenNodes, int index)
        {
            foreach(var Node in this.FollowingNodes) {
                if(Node.Index == index) {
                    return Node;
                } else {
                    SeenNodes.Add(Node);
                    if(Node.GetNode(SeenNodes, index) != null) {
                        return Node.GetNode(SeenNodes, index);
                    } else {
                        return null;
                    }
                }
            }

            Console.WriteLine("Node wurde nicht gefunden");
            return null;
        }
    }
}
