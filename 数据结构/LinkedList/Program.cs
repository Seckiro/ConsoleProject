namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLinkedNode(i);
            }
            linkedList.ReverseLinkedList();
            linkedList.PrintLinkedList();
        }

        public class LinkedList<T>
        {
            private LinkedListNode<T>? _head;

            public void AddLinkedNode(T value)
            {
                if (_head == null)
                {
                    _head = new LinkedListNode<T> { Value = value };
                }
                else
                {
                    LinkedListNode<T> tempNode = _head;
                    while (tempNode != null)
                    {
                        if (tempNode.Next == null)
                        {
                            tempNode.Next = new LinkedListNode<T> { Value = value };
                            break;
                        }
                        else
                        {
                            tempNode = tempNode.Next;
                        }
                    }
                }
            }

            public void PrintLinkedList()
            {
                LinkedListNode<T>? tempNode = _head;
                while (tempNode != null)
                {
                    Console.WriteLine(tempNode.Value);
                    tempNode = tempNode.Next;
                }
            }

            public void ReverseLinkedList()
            {
                _head = ReverseNode(_head);
            }

            public LinkedListNode<T> ReverseNode(LinkedListNode<T> head)
            {
                LinkedListNode<T> phead = head;
                LinkedListNode<T> qhead = head.Next;
                while (qhead != null)
                {
                    phead.Next = qhead.Next;
                    qhead.Next = head;
                    head = qhead;
                    qhead = phead.Next;
                }
                return head;
            }
        }
        public class LinkedListNode<T>
        {
            public T? Value { get; set; }
            public LinkedListNode<T>? Next { get; set; }
        }
    }

}
