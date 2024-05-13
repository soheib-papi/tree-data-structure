namespace tree_data_structure;

public class Tree
{
    private class Node
    {
        public int Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public Node(int value)
        {
            this.Value = value;
        }

        public override String ToString()
        {
            return "Node=" + Value;
        }
    }

    private Node root;

    public void Insert(int value)
    {
        var node = new Node(value);

        if (root == null)
        {
            root = node;
            return;
        }

        var current = root;
        while (true)
        {
            if (value < current.Value)
            {
                if (current.LeftChild == null)
                {
                    current.LeftChild = node;
                    break;
                }
                current = current.LeftChild;
            }
            else
            {
                if (current.RightChild == null)
                {
                    current.RightChild = node;
                    break;
                }
                current = current.RightChild;
            }
        }
    }

    public bool Find(int value)
    {
        var current = root;
        while (current != null)
        {
            if (value < current.Value)
                current = current.LeftChild;
            else if (value > current.Value)
                current = current.RightChild;
            else
                return true;
        }
        return false; //Not found
    }

    private void TraversePreOrderRecursive(Node root)
    {
        if (root == null)
            return;

        Console.WriteLine(root.Value);
        TraversePreOrderRecursive(root.LeftChild);
        TraversePreOrderRecursive(root.RightChild);
    }

    public void TraversePreOrderRecursive()
    {
        TraversePreOrderRecursive(root);
    }


    private void TraversePostOrderRecursive(Node root)
    {
        if (root == null)
            return;

        TraversePostOrderRecursive(root.LeftChild);
        TraversePostOrderRecursive(root.RightChild);
        Console.WriteLine(root.Value);
    }

    public void TraversePostOrderRecursive()
    {
        TraversePostOrderRecursive(root);
    }

    private void TraverseInOrderRecursive(Node root)
    {
        if (root == null)
            return;

        TraverseInOrderRecursive(root.LeftChild);
        Console.WriteLine(root.Value);
        TraverseInOrderRecursive(root.RightChild);
    }

    public void TraverseInOrderRecursive()
    {
        TraverseInOrderRecursive(root);
    }

    private void TraversePreOrderIterative(Node root)
    {
        if (root == null)
            return;

        Stack<Node> stack = new Stack<Node>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            Node node = stack.Pop();
            Console.WriteLine(node.Value);

            // Push right child before left child so that left child is processed first
            if (node.RightChild != null)
                stack.Push(node.RightChild);
            if (node.LeftChild != null)
                stack.Push(node.LeftChild);
        }
    }

}
