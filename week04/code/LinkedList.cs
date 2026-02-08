using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node? _head;
    private Node? _tail;
    private int _count;

    private class Node
    {
        public T Value;
        public Node? Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public int Count => _count;

    // Insert at head
    public void InsertHead(T value)
    {
        Node newNode = new Node(value);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head = newNode;
        }

        _count++;
    }

    // Insert at tail
    public void InsertTail(T value)
    {
        Node newNode = new Node(value);

        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            _tail = newNode;
        }

        _count++;
    }

    // Remove head
    public void RemoveHead()
    {
        if (_head == null)
            return;

        _head = _head.Next;
        _count--;

        if (_head == null)
            _tail = null;
    }

    // Remove tail
    public void RemoveTail()
    {
        if (_head == null)
            return;

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            Node current = _head;

            while (current.Next != _tail)
            {
                current = current.Next!;
            }

            current.Next = null;
            _tail = current;
        }

        _count--;
    }

    // Remove first matching value
    public void Remove(T value)
    {
        if (_head == null)
            return;

        if (_head.Value!.Equals(value))
        {
            RemoveHead();
            return;
        }

        Node current = _head;

        while (current.Next != null)
        {
            if (current.Next.Value!.Equals(value))
            {
                if (current.Next == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    current.Next = current.Next.Next;
                    _count--;
                }
                return;
            }

            current = current.Next;
        }
    }

    // Replace all matches
    public void Replace(T oldValue, T newValue)
    {
        Node? current = _head;

        while (current != null)
        {
            if (current.Value!.Equals(oldValue))
                current.Value = newValue;

            current = current.Next;
        }
    }

    // Forward iterator
    public IEnumerator<T> GetEnumerator()
    {
        Node? current = _head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Reverse iterator
    public IEnumerable<T> Reverse()
    {
        Stack<T> stack = new Stack<T>();
        Node? current = _head;

        while (current != null)
        {
            stack.Push(current.Value);
            current = current.Next;
        }

        while (stack.Count > 0)
        {
            yield return stack.Pop();
        }
    }
}
