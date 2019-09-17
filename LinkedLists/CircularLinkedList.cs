using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists
{
    public class CircularLinkedList
    {
        private DoubleNode _head;
        private DoubleNode _tail;

        private int _size;

        public CircularLinkedList(int value)
        {
            var node = new DoubleNode(value)
            {
                Next = null,
                Previous = null
            };

            _head = node;
            _tail = node;

            _size = 1;
        }

        public void Traverse()
        {
            if (!CheckIfListExists())
            {
                Console.WriteLine("List does not exist!");
                return;
            }

            var tempNode = _head;
            Console.WriteLine("");
            Console.WriteLine("*** Traverse circular list ***");

            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine($"Node at position: {i}. Has value: {tempNode.Value}");
                Console.WriteLine("Properties");

                var headDetails = tempNode == _head ? "Is head" : "Is not head";
                Console.WriteLine($"--> {headDetails}");

                var tailDetails = tempNode == _tail ? "Is tail" : "Is not tail";
                Console.WriteLine($"--> {tailDetails}");

                var previousDetails = tempNode.Previous != null ? $"Previous is {tempNode.Previous.Value}" : "Does not have previous";
                Console.WriteLine($"--> {previousDetails}");

                var nextDetails = tempNode.Next != null ? $"Next is {tempNode.Next.Value}" : "Does not have next";
                Console.WriteLine($"--> {nextDetails}");

                tempNode = tempNode.Next;
            }

            Console.WriteLine("");
            Console.WriteLine("*** EOL ***");
        }

        public void Add(int value, int location)
        {
            var node = new DoubleNode(value);

            if (location == 0) // Insert first on the list
            {
                node.Next = _head;
                node.Previous = null;

                _head.Previous = node;
                _head = node;

                _size++;
                return;
            }

            if (location >= _size) // Insert last on the list
            {
                node.Next = null;
                node.Previous = _tail;

                _tail.Next = node;
                _tail = node;

                _size++;
                return;
            }

            var tempNode = _head;
            int index = 0;

            while (index < location - 1)
            {
                tempNode = tempNode.Next;
                index++;
            }

            node.Previous = tempNode;
            node.Next = tempNode.Next;

            tempNode.Next = node;
            node.Next.Previous = node;
            _size++;
        }

        public void RemoveValue(int value)
        {
            var tempNode = _head;

            Console.WriteLine("*** Remove item by value ***");

            for (int i = 0; i < _size; i++)
            {
                if (tempNode.Value != value)
                {
                    tempNode = tempNode.Next;
                    continue;
                }

                Console.WriteLine($"Value: {value} found!");
                Console.WriteLine("Details:");

                bool isHead = tempNode == _head;
                var headDetails = isHead ? "Is head" : "Is not head";
                Console.WriteLine($"--> {headDetails}");

                if (isHead)
                {
                    _head = tempNode.Next;

                    if (_size > 1)
                    {
                        _head.Previous = null;
                        _head.Next = tempNode.Next.Next;

                        tempNode = null;
                        _size--;
                    }

                    Console.WriteLine("--> Item removed: was first!");

                    return;
                }

                bool isTail = tempNode == _tail;
                var tailDetails = isTail ? "Is tail" : "Is not tail";
                Console.WriteLine($"--> {tailDetails}");

                if (isTail)
                {
                    _tail = tempNode.Previous;

                    _tail.Next = null;
                    _tail.Previous = tempNode.Previous.Previous;

                    tempNode = null;
                    _size--;

                    Console.WriteLine("--> Item removed: was last");
                    return;
                }

                Console.WriteLine("--> Inside the list");

                if(tempNode.Previous == _head)
                {
                    _head.Next = tempNode.Next;
                    tempNode.Next.Previous = _tail;

                    tempNode = null;
                    _size--;

                    return;
                }

                if(tempNode.Next == _tail)
                {
                    _tail.Previous = tempNode.Previous;
                    tempNode.Previous.Next = _tail;

                    tempNode = null;
                    _size--;

                    return;
                }

                return;
            }
        }

        public void RemoveLocation(int location)
        {
            if(!CheckIfListExists())
            {
                Console.WriteLine("List doest not exist!");
                return;
            }

            Console.WriteLine("*** Remove item by location ***");

            var tempNode = _head;

            if(location == 0) //first item
            {
                tempNode.Next = null;
                tempNode.Next = tempNode.Next.Next;

                _head = tempNode;
                _size--;
            }

            if(location >= _size) //last item or outside of the list
            {
                tempNode.Next = null;
                tempNode.Previous = tempNode.Previous.Previous;

                _tail = tempNode;
                _size--;
            }

            if(location < _size) //inside the linked list
            {
                var index = 0;
                while(index < location - 1)
                {
                    tempNode = tempNode.Next;
                    index++;
                }

                tempNode.Next = tempNode.Next.Next;
                tempNode.Next.Previous = tempNode;

                _size--;
            }
        }

        public void Delete()
        {
            if (!CheckIfListExists())
            {
                Console.WriteLine("List doest not exist!");
                return;
            }

            Console.WriteLine("*** Delete linked list ***");

            var tempNode = _head;

            for(int i = 0; i < _size; i++)
            {
                tempNode.Previous = null;
                tempNode = tempNode.Next;
            }

            _head = null;
            _tail = null;
        }

        private bool CheckIfListExists()
        {
            return _head != null;
        }
    }
}
