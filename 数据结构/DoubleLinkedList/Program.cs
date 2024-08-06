namespace DoubleLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList<int> linkedList = new DoubleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLinkedNode(i);
            }
            linkedList.PrintLinkedListHeadToTail();
            linkedList.PrintLinkedListTailToHead();
        }
    }

    public class DoubleLinkedList<T>
    {
        private DoubleLinkedListNode<T>? _head;
        private DoubleLinkedListNode<T>? _tail;
        public void AddLinkedNode(T value)
        {
            if (_head == null)
            {
                _head = new DoubleLinkedListNode<T> { Value = value, Previous = null };
                _tail = _head;
            }
            else
            {
                DoubleLinkedListNode<T>? tempNode = _head;
                while (tempNode != null)
                {
                    if (tempNode.Next == null)
                    {
                        tempNode.Next = new DoubleLinkedListNode<T> { Value = value };
                        tempNode.Next.Previous = tempNode;
                        _tail = tempNode.Next;
                        break;
                    }
                    else
                    {
                        tempNode = tempNode.Next;
                    }
                }
            }
        }

        public void PrintLinkedListHeadToTail()
        {
            DoubleLinkedListNode<T>? tempNode = _head;
            while (tempNode != null)
            {
                Console.WriteLine(tempNode.Value);
                tempNode = tempNode.Next;
            }
        }

        public void PrintLinkedListTailToHead()
        {
            DoubleLinkedListNode<T>? tempNode = _tail;
            while (tempNode != null)
            {
                Console.WriteLine(tempNode.Value);
                tempNode = tempNode.Previous;
            }
        }
    }

    public class DoubleLinkedListNode<T>
    {
        public T? Value { get; set; }
        public DoubleLinkedListNode<T>? Next { get; set; }
        public DoubleLinkedListNode<T>? Previous { get; set; }
    }
}
