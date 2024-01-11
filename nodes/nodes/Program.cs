using System;

namespace nodes
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Node first = new Node(0);

            Node second = new Node(1, first);
            first.AddChild(second);

            Node third = new Node(2, first);
            first.AddChild(third);

            Node fourth = new Node(3, first);
            first.AddChild(fourth);


            Node last = new Node(4, second);
            second.AddChild(last);
        }
    }
}
