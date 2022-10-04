/*
 * Albero di ricerca binario (Binary Search Tree)
 * 1. Se la sottostruttura sinistra di qualsiasi nodo non è vuota, 
 * il valore di tutti i nodi sulla sottostruttura sinistra è inferiore al valore del suo nodo radice; 
 * 2. Se la sottostruttura destra di qualsiasi nodo non è vuota, 
 * il valore di tutti i nodi sulla sottostruttura destra è maggiore del valore del suo nodo radice;
 * 3. La sottostruttura sinistra e la sottostruttura destra di qualsiasi nodo sono anche alberi di ricerca binari.
 */


/*
 * 1. Costruire un albero di ricerca binario 
 * I nodi inseriti vengono confrontati dal nodo radice e 
 * il più piccolo del nodo radice viene confrontato con la sottostruttura sinistra del nodo radice, altrimenti,
 * confrontato con la sottostruttura destra fino a quando la sottostruttura sinistra è vuota o la sottostruttura destra è vuota, 
 * quindi è inserito.
 */


using AlberoDiRIcercaBinario;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
class BinaryTree
{
    private Node root;

    public Node GetRoot()
    {
        return root;
    }

    public void InOrder(Node root)
    {
        if (root == null)
        {
            return;
        }

        InOrder(root.left);
        Console.Write(root.data + " , ");
        InOrder(root.right);
    }

    public void Insert(Node node, int newData)
    {
        if(this.root == null)
        {
            this.root = new Node(newData, null, null);
            return;

        }

        int compareValue = newData - node.data;

        if(compareValue < 0)
        {
            if(node.left == null)
            {
                node.left = new Node(newData, null, null);
            }
            else
            {
                Insert(node.left, newData);
            }
        }
        else if(compareValue > 0)
        {
            if(node.right == null)
            {
                node.right = new Node(newData, null, null);
            }
            else
            {
                Insert(node.right, newData);
            }
        }
    }

    public void PreOrder(Node root)
    {
        if(root == null)
        {
            return;
        }
        Console.Write(root.data + " , ");
        PreOrder(root.left);
        PreOrder(root.right);
    }

    public void PostOrder(Node root)
    {
        if (root == null)
        {
            return;
        }
        PostOrder(root.left);
        PostOrder(root.right);
        Console.Write(root.data + " , ");

    }


    public Node searchMinValue(Node node)
    {
        if (node == null || node.data == 0)
            return null;

        if(node.left == null)
        {
            return node;
        }
        return searchMinValue(node.left);
    }

    public Node searchMaxValue(Node node)
    {
        if (node == null || node.data == 0)
            return null;

        if (node.right == null)
        {
            return node;
        }
        return searchMaxValue(node.right);
    }

    public Node Remove(Node node, int newData)
    {
        if(node == null)
        {
            return node;
        }

        int compareValue = newData - node.data;

        if(compareValue > 0)
        {
            node.right = Remove(node.right, newData);
        }
        else if(compareValue < 0)
        {
            node.left = Remove(node.left, newData);
        } 
        else if(node.left != null && node.right!= null)
        {
            node.data = searchMinValue(node.right).data;
            node.right = Remove(node.right, node.data);
        }
        else
        {
            node = (node.left != null) ? node.left : node.right;
        }
        return node;
    }
    public static void Main(string[] args)
    {
        BinaryTree binaryTree = new BinaryTree();

        binaryTree.Insert(binaryTree.GetRoot(), 60);
        binaryTree.Insert(binaryTree.GetRoot(), 40);
        binaryTree.Insert(binaryTree.GetRoot(), 20);
        binaryTree.Insert(binaryTree.GetRoot(), 10);
        binaryTree.Insert(binaryTree.GetRoot(), 30);
        binaryTree.Insert(binaryTree.GetRoot(), 50);
        binaryTree.Insert(binaryTree.GetRoot(), 80);
        binaryTree.Insert(binaryTree.GetRoot(), 70);
        binaryTree.Insert(binaryTree.GetRoot(), 90);

        Console.WriteLine("In-order traversal binary search tree");
        binaryTree.InOrder(binaryTree.GetRoot());
        Console.WriteLine();
        Console.WriteLine("Pre-order traversal binary search tree");
        binaryTree.PreOrder(binaryTree.GetRoot());
        Console.WriteLine();
        Console.WriteLine("Post-order traversal binary search tree");
        binaryTree.PostOrder(binaryTree.GetRoot());
        Console.WriteLine();
        Console.WriteLine("Minimum value");
        Node minNode = binaryTree.searchMinValue(binaryTree.GetRoot());
        Console.Write(minNode.data);
        Console.WriteLine();
        Console.WriteLine("Maximum value");
        Node maxNode = binaryTree.searchMaxValue(binaryTree.GetRoot());
        Console.Write(maxNode.data);
        Console.WriteLine();
        Console.WriteLine("Delete node is 10:");
        binaryTree.Remove(binaryTree.GetRoot(), 10);
        binaryTree.InOrder(binaryTree.GetRoot());

    }
}