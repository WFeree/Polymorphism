namespace Polymorphism
{
    public class UList<T>
    {
        Node head;
        int count = 0;

        class Node
        {
            T value;
            Node? next;
            Node? third;

            public Node(T val, int count)
            {
                this.value = val;
                int n = (int)(count / 3);

            }


            private Node? getRelativeNode(int relN)
            {
                return null;
            }
            public T Get()
            {
                return value;
            }
            public void SetNext(Node? n)
            {
                this.next = n;
            }

        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {

        }
    }
}
