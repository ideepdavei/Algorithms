using System;

namespace DoublyLinkedList
{
    public class LinkedListNode<T>
    {
        public T Value { get; internal set; }
        public LinkedListNode<T> LinkToNextNode { get; internal set; }
        public LinkedListNode<T> LinkToPreviousNode { get; internal set; }
        public LinkedListNode() { }
        public LinkedListNode(T value) { this.Value = value; }
    }
}
