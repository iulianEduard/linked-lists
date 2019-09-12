namespace LinkedLists
{
    internal class Node
    {
        private int data;
        private Node next = null;

        internal Node Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }

        internal int Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public Node(int d)
        {
            data = d;
        }
    }
}
