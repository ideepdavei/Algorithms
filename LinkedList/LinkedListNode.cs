using System;

namespace LinkedList
{
    public class LinkedListNode<T>
    {
        public T Value { get; internal set; }
        public LinkedListNode<T> LinkToNextNode { get; internal set; }

        public LinkedListNode() { }
        public LinkedListNode(T value)
        {
            this.Value = value;
        }
    }
}
