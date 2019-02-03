using System;

namespace LinkedList
{
    public class LinkedList<T> : System.Collections.Generic.IEnumerable<T>
    {
        LinkedListNode<T> firstElement;
        LinkedListNode<T> lastElement;
        public int Count { get; private set; }

        public LinkedList() { }

        public void Add(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);
            if (firstElement == null)
            {
                firstElement = node;
                lastElement = node;
            }
            else
            {
                lastElement.LinkToNextNode = node;
                lastElement = node;
            }
            Count++;
        }

        public bool Remove(T value)
        {
            LinkedListNode<T> previousNode = null;
            LinkedListNode<T> currentNode = firstElement;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    if (previousNode != null)
                    {
                        previousNode.LinkToNextNode = currentNode.LinkToNextNode;
                        if (currentNode.LinkToNextNode == null)
                            lastElement = previousNode;
                    }
                    else
                    {
                        firstElement = firstElement.LinkToNextNode;
                        if (firstElement == null)
                            lastElement = null;
                    }
                    Count--;
                    return true;
                }
                previousNode = currentNode;
                currentNode = currentNode.LinkToNextNode;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> currentNode = firstElement;
            while (currentNode != null)
            {
                array[arrayIndex++] = currentNode.Value;
                currentNode = currentNode.LinkToNextNode;
            }
        }

        public bool Conteins(T value)
        {
            LinkedListNode<T> currentNode = firstElement;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                    return true;
                currentNode = currentNode.LinkToNextNode;
            }
            return false;
        }

        public void Clear()
        {
            firstElement = null;
            lastElement = null;
            Count = 0;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> currentNode = firstElement;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.LinkToNextNode;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }
    }
}
