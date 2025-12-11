namespace Polymorphism
{
    public class UList<T>
    {
        Node? head;
        int count = 0;

        class Node
        {
            T value;
            Node? next;
            Node? third;
            int thirdN;

            public Node(T val, int count, Node? head)
            {
                this.value = val;
                int n = (int)(count / 3);
                UpdateThirds(head, n, count);
            }

            private void UpdateThirds(Node? head, int relN, int count)
            {
                if (head == null) return;
                Node? current = head;
                for (int i = 0; i < count && current != null; i++)
                {
                    Node? n = current.next;
                    for (int j = 0; j < relN; j++)
                    {
                        if (n == null) break;
                        n = n.next;
                    }
                    current.third = n;
                    current.setThirdN(i + relN);
                    current = current.next;
                }
            }
            private void setThirdN(int n)
            {
                this.thirdN = n;
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
