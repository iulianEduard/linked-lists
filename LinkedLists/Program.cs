using System;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            //SingleLinkedListOperations();

            SingleCircularLinkedListOperations();

            Console.ReadKey();
        }

        static void SingleLinkedListOperations()
        {
            var ssl = new SinglyLinkedList(10);

            ssl.Add(11, 2);
            ssl.Add(12, 4);
            ssl.Add(13, 2);

            ssl.Traverse();

            ssl.Search(25);
        }

        static void SingleCircularLinkedListOperations()
        {
            var scl = new SinglyCircularLinkedList(10);

            scl.Traverse();

            scl.Add(11, 1);
            scl.Add(12, 2);
            scl.Add(13, 3);

            scl.Add(14, 2);
            scl.Add(15, 7);

            scl.Traverse();

            scl.Search(15);

            scl.Remove(3);

            scl.Traverse();
        }
    }
}
