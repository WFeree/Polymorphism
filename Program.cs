using static System.Net.Mime.MediaTypeNames;

namespace Polymorphism
{
    public class UList<T>
    {
        Node? head;
        int count = 0;
        Node? last;

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
            public T Get()
            {
                return value;
            }
            public void SetNext(Node? n)
            {
                this.next = n;
            }
            public int getThirdN() {  return thirdN; }
            public Node? getThird() {  return third; }
            public T GetValue() { return value; }
        }
        public void Add(T val)
        {
            Node n = new Node(val, count, head);
            if (last != null)
            {
                last.SetNext(n);
            }
            last = n;
        }
        public T Get(int i)
        {

            if(i >= count || count<0 || head == null ) 
            {
                throw new IndexOutOfRangeException("");
            }
            Node current = head;
            for(int _i = 0 ; _i < count; i++)
            {
                if(current.getThird() != null && current.getThirdN() <= i)
                {
                    _i = current.getThirdN();
                    current = current.getThird();
                }
                if (_i == i) return current.GetValue();
            }
            throw new IndexOutOfRangeException();
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {

        }
    }
}
