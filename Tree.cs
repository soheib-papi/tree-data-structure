namespace tree_data_structure;

public class Tree
{
    private class Node
    {
        public int value { get; set; }
        public Node leftChild { get; set; }
        public Node rightChild { get; set; }

        public Node(int value)
        {
            this.value = value;
        }
        
        public override String ToString()
        {
            return "Node=" + value;
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
            if (value < current.value)
            {
                if (current.leftChild == null)
                {
                    current.leftChild = node;
                    break;
                }
                current = current.leftChild;
            }
            else
            {
                if (current.rightChild == null)
                {
                    current.rightChild = node;
                    break;
                }
                current = current.rightChild;
            }
        }
    }

    public bool Find(int value)
    {
        var current = root;
        while (current != null)
        {
            if (value < current.value)
                current = current.leftChild;
            else if (value > current.value)
                current = current.rightChild;
            else
                return true;
        }
        return false; //Not found
    }
}
