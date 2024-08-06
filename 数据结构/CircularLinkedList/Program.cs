namespace CircularLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList<int> linkedList = new CircularLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLinkedNode(i);
            }
            linkedList.PrintLinkedList(5);
            linkedList.PrintLinkedList();
        }
    }

    public class CircularLinkedList<T>
    {
        private int _count;

        private CircularLinkedListNode<T>? _head;
        private CircularLinkedListNode<T>? _tail;

        public void AddLinkedNode(T value)
        {
            if (_head == null)
            {
                _head = new CircularLinkedListNode<T>() { Value = value };
                _tail = _head;
                _tail.Next = _head;
                _count++;
            }
            else
            {
                CircularLinkedListNode<T> tempNode = _tail;
                _tail.Next = new CircularLinkedListNode<T>() { Value = value };
                _tail.Next.Next = _head;
                _tail = _tail.Next;
                _count++;
            }
        }

        public void PrintLinkedList(int count = -1)
        {
            CircularLinkedListNode<T> tempNode = _head;
            if (count <= 0)
            {
                count = _count;
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(tempNode.Value);
                tempNode = tempNode.Next;
            }
        }

    }

    public class CircularLinkedListNode<T>
    {
        public T? Value { get; set; }
        public CircularLinkedListNode<T>? Next { get; set; }
    }
}
