using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> instance = new LinkedList<int>();
            instance.Add(10);
            instance.Add(20);
            instance.Add(35);
            instance.Add(12);
            foreach (var item in instance)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            instance.Remove(35);
            foreach (var item in instance)
            {
                Console.WriteLine(item);
            }
            if (instance.Conteins(12))
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
            instance.Clear();
            foreach (var item in instance)
            {
                Console.WriteLine(item);
            }
        }
    }
}
