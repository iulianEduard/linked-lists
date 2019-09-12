using System;

namespace LinkedLists
{
    public class SinglyLinkedList
    {
        private Node _head;
        private Node _tail;
        private int _size;

        public SinglyLinkedList(int value)
        {
            _head = new Node(value)
            {
                Next = null
            };

            _tail = _head;
            _size = 1;
        }

        public void Traverse()
        {
            Node current = _head;
            Console.WriteLine("Traverse linked list:");

            if (current == null)
            {
                Console.WriteLine("No nodes to display!");
            }
            else
            {
                while (current != null)
                {
                    Console.WriteLine($"Node has value: {current.Data}");

                    if (current == _head)
                    {
                        Console.WriteLine("Node is head");
                    }

                    if (current == _tail)
                    {
                        Console.WriteLine("Node is tail");
                    }

                    current = current.Next;
                }

                Console.WriteLine($"Linked list has size: {_size}");
            }

            Console.WriteLine("");
        }

        public void Add(int value, int location)
        {
            var node = new Node(value);

            if (!LinkedListExists())
            {
                Console.WriteLine("Linked list does not exist!");
                return;
            }

            if (location == 0)
            {
                // Insert in first position
                _head.Next = node;
                _head = node;
            }
            else if (location >= _size)
            {
                // Insert last
                node.Next = null;
                _tail.Next = node;
                _tail = node;
            }
            else
            {
                // Insert at specified location
                var tempNode = _head;
                int index = 0;

                while (index < location - 1)
                {
                    tempNode = tempNode.Next;
                    index++;
                }

                var nextNode = tempNode.Next;
                tempNode.Next = node;
                node.Next = nextNode;
            }

            Console.WriteLine($"Node with value: {value} was added to list");
            Console.WriteLine("");

            _size++;
        }

        public void Remove(int location)
        {
            Console.WriteLine($"Remove node from list: {location}");

            if (!LinkedListExists())
            {
                Console.WriteLine("Linked list does not exit");
                return;
            }

            if (location == 0)
            {
                Console.WriteLine("Remove first element");

                var nextNode = _head.Next;
                _head = null;

                _head = nextNode;
                _size--;

                if (_size == 0)
                {
                    Console.WriteLine("Remove tail");
                    _tail = null;
                }
            }

            if (location >= _size)
            {
                Console.WriteLine("Location equals to last position or outside of list");
                var tempNode = _head.Next;

                for (int i = 0; i < _size - 1; i++)
                {
                    tempNode = tempNode.Next;
                }

                if (tempNode == _head.Next)
                {
                    Console.WriteLine("The only element in the list");
                    _head = _tail = null;
                    _size--;
                }

                tempNode.Next = null;
                _tail = tempNode;
                _size--;
            }
            else
            {
                Console.WriteLine("Location inside the list");
                var tempNode = _head;

                for (int i = 0; i < location - 1; i++)
                {
                    tempNode = tempNode.Next;
                }

                tempNode.Next = tempNode.Next.Next;
                _size--;
            }

            Console.WriteLine("");
        }

        public void Delete()
        {
            Console.WriteLine("Deleting list");
            _head = null;
            _tail = null;
        }

        public void Search(int valueToSearch)
        {
            if (!LinkedListExists())
            {
                Console.WriteLine("List does not exit!");
                return;
            }

            var nodeWithValue = _head;

            for (int i = 0; i <= _size - 1; i++)
            {
                if (nodeWithValue != null && nodeWithValue.Data == valueToSearch)
                {
                    Console.WriteLine($"Item found in position: {i}");
                    return;
                }

                nodeWithValue = nodeWithValue.Next;
            }

            Console.WriteLine($"{valueToSearch} was not found in list!");
        }

        private bool LinkedListExists()
        {
            return _head != null;
        }
    }
}
