using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.DataStructures
{
    public class DoublyLinkedList<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }
            public Node(T data) { Data = data; Next = Prev = null; }
        }

        private Node head;
        private Node tail;

        public DoublyLinkedList() { head = tail = null; }

        public void Add(T data)
        {
            var newNode = new Node(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        public void PrintAll()
        {
            var current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}
