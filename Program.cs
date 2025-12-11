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
            public Node? jumper;
            public int jumpIndex;
            public Node? next;

            public Node(T val)  {value = val;}

            public static void UpdateJumpers(Node head, int count)
            {
                const float ratio = 0.2f;
                if(head == null) return;
                Node current = head;
                int index = 0;
                while(current.next != null)
                {
                    int remaining = count - index;
                    int jumpLength = (int)(remaining * ratio);
                    if(jumpLength < count*ratio*ratio)
                    {
                        current.jumper = null;
                        current.jumpIndex = -1;
                        current = current.next;
                        index++;
                        continue;
                    }

                    Node? jumpTarget = current.next;
                    for(int j = 0; j < jumpLength; j++)
                    {
                        if(jumpTarget == null) break;
                        jumpTarget = jumpTarget.next;
                    }
                    current.jumper = jumpTarget;
                    current.jumpIndex = index + jumpLength;

                    current = current.next;
                    index++;
                }
            }
            public T GetValue() {  return value; }
        }
        public void Add(T val)
        {
            count++;
            Node newItem = new Node(val);
            if(head == null)
            {
                head = newItem;
            }
            if(last == null)
            {
                last = newItem;
                last.next = null;
            }
            else
            {
                last.next = newItem;
                last = newItem;
            }
            Node.UpdateJumpers(head, count);
        }
        public T Get(int i)
        {
            if(i >= count || i < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Node current = head;
            for(int index = 0; index != i; index++)
            {
                Console.WriteLine(index + " " + i);
                if(current.jumper != null && current.jumpIndex < i)
                {
                    index = current.jumpIndex;
                    current = current.jumper!;
                    continue;
                }
                if(current != null)
                    current = current.next;
            }
            return current.GetValue();
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            UList<int> list = new UList<int>();
            for(int i =0; i < 6000; i++)
            {
                list.Add(i);
            }
            Console.WriteLine(list.Get(5200));
            
        }
    }
}
