using System;
using System.Collections.Generic;

public class BinarySearchTree
{
    private class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    private Node _root;
    private int _count;

    private Node Root => _root;
    public int Count => _count;

    public void Add(int value)
    {
        if (_root == null)
        {
            _root = new Node(value);
        }
        else
        {
            AddTo(_root, value);
        }
        _count++;
    }

    private void AddTo(Node node, int value)
    {
        if (value < node.Value)
        {

            if (node.Left == null)
            {
                node.Left = new Node(value);
            }
            else
            {
                AddTo(node.Left, value);
            }
        }
        else
        {

            if (node.Right == null)
            {
                node.Right = new Node(value);
            }
            else
            {
                AddTo(node.Right, value);
            }
        }
    }


    public bool Contains(int value)
    {
        return Find(_root, value) != null;
    }

    private Node Find(Node node, int value)
    {
        if (node == null) return null;

        if (value == node.Value)
            return node;

        if (value < node.Value)
            return Find(node.Left, value);

        return Find(node.Right, value);
    }


    public void Clear()
    {
        _root = null;
        _count = 0;
    }


    public int[] ToArray()
    {
        var result = new List<int>();
        TraverseInOrder(_root, result);
        return result.ToArray();
    }

    private void TraverseInOrder(Node node, List<int> result)
    {
        if (node == null) return;

        TraverseInOrder(node.Left, result);
        result.Add(node.Value);
        TraverseInOrder(node.Right, result);
    }
}
