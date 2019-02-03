using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> instance = new LinkedList<int>();
            instance.AddFirst(10);
            instance.AddFirst(8);
            instance.AddLast(42);
            foreach (var item in instance)
            {
                Console.WriteLine(item);
            }
        }
    }
}
