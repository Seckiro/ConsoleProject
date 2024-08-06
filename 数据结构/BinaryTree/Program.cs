namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.CreateBinaryTree(ints);
            binaryTree.TraverseTreeNode();
            Console.WriteLine("--------------------------");
            binaryTree.SortBinaryTree(ints);
            binaryTree.TraverseTreeNode();
        }
    }

    public class BinaryTree<T>
    {
        private BinaryTreeNode<T>? _root;

        public void CreateBinaryTree(T[] values)
        {
            _root = CreatTreeChildNode(values);
        }

        public void TraverseTreeNode()
        {
            TraverseTreeNode(_root);
        }

        public void SortBinaryTree(T[] values)
        {
            _root = new BinaryTreeNode<T>() { Value = values[0] };
            for (int i = 1; i < values.Length; i++)
            {
                CreatTreeSortChildNode(_root, values[i]);
            }
        }

        private void CreatTreeSortChildNode(BinaryTreeNode<T> node, T value)
        {
            if (string.Compare(node.Value.ToString(), value.ToString()) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>() { Value = value };
                }
                else
                {
                    CreatTreeSortChildNode(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>() { Value = value };
                }
                else
                {
                    CreatTreeSortChildNode(node.Right, value);
                }
            }
        }


        private BinaryTreeNode<T> CreatTreeChildNode(T[] values, int index = 0)
        {
            BinaryTreeNode<T> binaryTreeNode = new BinaryTreeNode<T>() { Value = values[index] };

            if (2 * index + 1 < values.Length)
            {
                binaryTreeNode.Left = CreatTreeChildNode(values, 2 * index + 1);
                binaryTreeNode.Left.Parent = binaryTreeNode;
            }
            else
            {
                binaryTreeNode.Left = null;
            }

            if (2 * index + 2 < values.Length)
            {
                binaryTreeNode.Right = CreatTreeChildNode(values, 2 * index + 2);
                binaryTreeNode.Right.Parent = binaryTreeNode;
            }
            else
            {
                binaryTreeNode.Right = null;
            }
            return binaryTreeNode;
        }

        private void TraverseTreeNode(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                TraverseTreeNode(node.Left);
                Console.WriteLine(node.Value);
                TraverseTreeNode(node.Right);
            }
        }

        private BinaryTreeNode<T> tempNode;
        private void TraverseTreeThreadNode(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                TraverseTreeThreadNode(node.Left);
                if (node.Left == null)
                {
                    node.LeftThread = tempNode;
                }
                if (node.Right == null)
                {
                    node.RightThread = tempNode;
                }
                tempNode = node;
                TraverseTreeThreadNode(node.Right);
            }
        }
    }

    public class BinaryTreeNode<T>
    {
        public T? Value { get; set; }

        public BinaryTreeNode<T>? Parent { get; set; }
        public BinaryTreeNode<T>? Left { get; set; }
        public BinaryTreeNode<T>? Right { get; set; }

        public BinaryTreeNode<T>? LeftThread { get; set; }
        public BinaryTreeNode<T>? RightThread { get; set; }

        public bool IsLeaf => Left == null && Right == null;
    }
}
