using System;

namespace DoublyLinkedList
{
    public class LinkedList<T> : System.Collections.Generic.IEnumerable<T>
    {
        LinkedListNode<T> firstElement;
        LinkedListNode<T> lastElement;
        public bool IsReadOnly { get => false; }
        public int Count { get; private set; }

        public LinkedList() { }

        public void AddFirst(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);
            LinkedListNode<T> temp = firstElement;

            firstElement = node;
            firstElement.LinkToNextNode = temp;

            if (Count == 0)
                lastElement = firstElement;
            else
                temp.LinkToPreviousNode = firstElement;

            Count++;
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);

            if (Count == 0)
                firstElement = node;
            else
            {
                lastElement.LinkToNextNode = node;
                node.LinkToPreviousNode = lastElement;
            }
            lastElement = node;
            Count++;
        }

        private void RemoveFirst()
        {
            if (Count != 0)
            {
                firstElement = firstElement.LinkToNextNode;
                Count--;

                if (Count == 0)
                    lastElement = null;
                else
                    firstElement.LinkToPreviousNode = null;
            }
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
                        else
                            currentNode.LinkToNextNode.LinkToPreviousNode = previousNode;

                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }  
                    return true;
                }
                previousNode = currentNode;
                currentNode = currentNode.LinkToNextNode;
            }
            return false;
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    firstElement = null;
                    lastElement = null;
                }
                else
                {
                    lastElement.LinkToPreviousNode.LinkToNextNode = null;
                    lastElement = lastElement.LinkToPreviousNode;
                }
                Count--;
            }
        }

        public bool Conteins(T value)
        {
            LinkedListNode<T> currentNode = firstElement;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }
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

        public void Clear()
        {
            firstElement = null;
            lastElement = null;
            Count = 0;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> currenteNode = firstElement;
            while (currenteNode != null)
            {
                yield return currenteNode.Value;
                currenteNode = currenteNode.LinkToNextNode;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }
    }
}
