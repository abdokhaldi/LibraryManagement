using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;

public class Node
{
   public int Data { get; set; }
   public Node Next { get; set; }
    
    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList {
    private  Node head = null;
    private int count;
    public void InsertToFirst(int data)
    {
        
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            count++;
            return;
         }
        newNode.Next = head;
        head = newNode;
        count++;
    }
    public void InsertToLast(int data)
    {
        Node newNode = new Node(data);
        Node current = head;
        if (head == null)
        {
           head = newNode;
            count++;
            return;
        }
        while (current.Next !=null)
        {
            current = current.Next;
        }
       
        current.Next = newNode;
        count++;
    }

    public void RemoveAtFirst()
    {
        Node temp = head;
        if (head != null)
        {
            head = temp.Next;
            temp = null;
            count--;
            return;
        }
     }

    public void RemoveAtEnd()
    {
        
        Node current = head;
        Node previous = null;

        if (head == null)
            return;

        if (head.Next == null)
        {
            head = null;
            count--;
            return;
        }

        while (current.Next != null)
        {
            previous = current;
            current = current.Next;
        }
        previous.Next = null;
        count--;
    }

    public void RemoveAt(int index)
    {
        if (index > count)
            return;
        
        Node current = head;
        Node previous = null;
      
        if (head == null)
            return;
        
        if (index == 0)
        {
            head = head.Next;
            count--;
            return;
        }

        int i = 0;

        while (current.Next != null && i!=index)
        {
            previous = current;
            current = current.Next;
            i++;
        }
        
       previous.Next = previous.Next.Next;
        count--;
        
    }
    
    public void Reverse()
    {
        Node current = head;
        Node pre = null;
        Node next = null;
        while (current != null)
        {
            next = current.Next;
            current.Next = pre;
            pre = current;
            current = next;
        }
        head = pre;
    }



    public void Reverse()
    {
        Node current = head;
        Node next = null;
        Node prev = null;
       
        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }
        head = prev;
    }
    public int Count => count;



    public void PrintData()
    {
        Node current = head;
        if (head == null)
            return;

        if (head.Next == null)
        {
            Console.Write(head.Data);
            return;
        }
        while (current.Next != null)
        {
            Console.Write(current.Data);
            current = current.Next;
        }
        Console.Write(current.Data);
    }

}


class Program
{

    static void Main()
    {
        LinkedList list = new LinkedList();
        list.InsertToLast(1);
        list.InsertToLast(2);
        list.InsertToLast(3);
        list.InsertToLast(4);
        // list.RemoveAtEnd();
        // list.RemoveAtFirst();
        list.Reverse();
       // list.RemoveAt(9);
       // Console.WriteLine(list.Count);
        list.PrintData();

    }

}