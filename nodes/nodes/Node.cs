using System.Collections.Generic;
namespace nodes
{
    public class Node
    {
        public int Index { get; }
        public Node Parent { get; }
        public List<Node> Children { get; }

        public Node(int index, Node parent = null)
        {
            Index = index;
            Parent = parent;
            Children = new List<Node>();
        }

        public void AddChild(Node child)
        {
            Children.Add(child);
        }
    }
}

