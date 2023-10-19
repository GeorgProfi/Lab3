namespace LabsShareLibrary
{

    public class Lab2
    {
        public class Node
        {
            public int Value { get; set; }
            public List<Node> Children { get; set; }

            public Node(int value)
            {
                Value = value;
                Children = new List<Node>();
            }
        }

        public class Tree
        {
            public Node Root { get; set; }

            public Tree()
            {
                Root = null;
            }

            public void Insert(int value)
            {
                Node newNode = new Node(value);

                if (Root == null)
                {
                    Root = newNode;
                }
                else
                {
                    Queue<Node> queue = new Queue<Node>();
                    queue.Enqueue(Root);

                    while (queue.Count > 0)
                    {
                        Node currentNode = queue.Dequeue();

                        if (currentNode.Children.Count < 2)
                        {
                            currentNode.Children.Add(newNode);
                            break;
                        }
                        else
                        {
                            foreach (Node child in currentNode.Children)
                            {
                                queue.Enqueue(child);
                            }
                        }
                    }
                }
            }

            public bool Search(int value)
            {
                if (Root == null)
                {
                    return false;
                }

                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(Root);

                while (queue.Count > 0)
                {
                    Node currentNode = queue.Dequeue();

                    if (currentNode.Value == value)
                    {
                        return true;
                    }

                    foreach (Node child in currentNode.Children)
                    {
                        queue.Enqueue(child);
                    }
                }

                return false;
            }
        }
    }
}