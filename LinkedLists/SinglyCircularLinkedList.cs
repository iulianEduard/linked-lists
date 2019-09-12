using System;

namespace LinkedLists
{
    public class SinglyCircularLinkedList
    {
        private Node _head;
        private Node _tail;

        private int _size;

        public SinglyCircularLinkedList(int defaultValue)
        {
            var node = new Node(defaultValue);

            _head = node;
            _tail = node;
            _tail.Next = _head;

            _size = 1;
        }

        public void Add(int value, int location)
        {
            if(!CheckListExists())
            {
                Console.WriteLine("List does not exist!");
                return;
            }

            var node = new Node(value);

            if(location == 0)
            {
                node.Next = _head;
                _head = node;
                _tail.Next = node;
                _size++;

                Console.WriteLine($"Element added first position: {value}");
                return;
            }

            if (location >= _size)
            {
                _tail.Next = node;
                _tail = node;
                _tail.Next = _head;
                _size++;

                Console.WriteLine($"Element added at the and of the list: {value}");
                return;
            }
            else
            {
                var tempNode = _head;
                int index = 0;

                while (index < location - 1)
                {
                    tempNode = tempNode.Next;
                    index++;
                }

                node.Next = tempNode.Next;
                tempNode.Next = node;
                _size++;
            }
        }

        public void Remove(int location)
        {
            if(!CheckListExists())
            {
                Console.WriteLine("List does not exist");
                return;
            }

            if(location == 0)
            {
                _head = _head.Next;
                _tail.Next = _head;

                _size--;

                if(_size == 0)
                {
                    _tail = null;
                }

                Console.WriteLine("First item removed from list");
                return;
            }

            if(location >= _size)
            {
                var tempNode = _head;
                for(int i = 0; i < _size - 1; i++)
                {
                    tempNode = tempNode.Next;
                }

                if(tempNode == _head)
                {
                    _tail = _head = null;
                    _size--;
                    return;
                }

                tempNode.Next = _head;
                _tail = tempNode;
                _size--;

                Console.WriteLine($"Location: {location} is last on the list or outside");

                return;
            }

            if(location < _size)
            {
                var tempNode = _head;
                for(int i = 0; i < location - 1; i++)
                {
                    tempNode = tempNode.Next;
                }

                tempNode.Next = tempNode.Next.Next;
                _size--;

                Console.WriteLine($"Location {location} is within the list");
            }
        }

        public void Search(int valueToSearch)
        {
            if(!CheckListExists())
            {
                Console.WriteLine("List does not exist!");
                return;
            }

            var tempNode = _head;

            for(int i = 0; i < _size; i++)
            {
                if(tempNode.Data == valueToSearch)
                {
                    Console.WriteLine($"Value: {valueToSearch} found in index: {i}");
                    return;
                }

                tempNode = tempNode.Next;
            }

            Console.WriteLine($"Value: {valueToSearch} not found in list");
        }

        public void Traverse()
        {
            if(!CheckListExists())
            {
                Console.WriteLine("List does not exist!");
                return;
            }

            Console.WriteLine("Traverse list");
            var tempNode = _head;

            for(int i = 0; i < _size; i++)
            {
                var headInfo = tempNode == _head ? "Is head" : "";
                var tailInfo = tempNode == _tail ? "Is tail" : "";
                Console.WriteLine($"Index: {i}, value: {tempNode.Data}. {headInfo} {tailInfo}");

                tempNode = tempNode.Next;
            }
        }

        private bool CheckListExists()
        {
            return _head != null;
        }
    }
}
