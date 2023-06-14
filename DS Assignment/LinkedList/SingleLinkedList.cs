using System;

namespace LinkedList
{
    public class SingleLinkedList
    {
        public Node start;
        /// <summary>
        /// Constructor
        /// </summary>
        public SingleLinkedList()
        {
            start = null;
        }
        /// <summary>
        /// Traversing linkedlist
        /// </summary>
        public void Traverse()
        {
            Node p;
            if (start == null)
            {
                Console.WriteLine("LinkedList is Empty ");
                return;
            }
            Console.WriteLine("LinkedList elements are :");
            p = start;
            while (p != null)
            {
                Console.WriteLine(p.data + "  ");
                p = p.next;
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Insert data to linkedlist at end
        /// </summary>
        /// <param name="data"></param>
        public void Insert(int data)
        {
            Node p;
            Node temp = new Node(data);
            if (start == null)
            {
                start = temp;
                return;
            }
            p = start;
            while (p.next != null)
                p = p.next;
            p.next = temp;
        }
        /// <summary>
        /// insert data to linkedlist at position
        /// </summary>
        /// <param name="data"></param>
        /// <param name="k"></param>
        public void InsertAtPosition(int data, int k)
        {
            Node temp;
            int i;
            if (k == 1)
            {
                temp = new Node(data)
                {
                    next = start
                };
                start = temp;
                return;

            }
            Node p = start;
            for (i = 1; i < k - 1 && p != null; i++)
            {
                p = p.next;
            }
            if (p == null)
            {
                Console.WriteLine("you can only insert upto " + i + "th posion");
            }
            else
            {
                temp = new Node(data)
                {
                    next = p.next
                };
                p.next = temp;
            }
        }
        /// <summary>
        /// delete last element from linkedlist
        /// </summary>
        /// <param name="x"></param>
        public void Delete(int x)
        {
            if (start == null)
            {
                Console.WriteLine("LinkedList is Empty");
                return;
            }
            if (start.data == x)
            {
                start = start.next;
                return;
            }
            Node p = start;
            while (p.next != null)
            {
                if (p.next.data == x)
                    break;
                p = p.next;
            }
            if (p.next == null)
                Console.WriteLine("Element " + x + "not in Linkedlist");
            else
                p.next = p.next.next;
        }
        /// <summary>
        /// Delete data at specific position
        /// </summary>
        /// <param name="x"></param>
        public void DeleteAtPosition(int x)
        {
            if (x < 1)
            {
                Console.WriteLine("Position should be greater than 1 ");
                return;
            }
            else if (x == 1 && start != null)
            {
                start = start.next;
            }
            else
            {
                Node temp = start;
                for (int i = 0; temp != null && i < x - 1; i++)
                {
                    temp.next = temp.next.next;
                }
                if (temp == null || temp.next == null)
                    return;
            }

        }
        /// <summary>
        /// center element of linkedlist
        /// </summary>
        public void Center()
        {
            int count = 0;
            var start1 = start;
            Node mid = start1;
            while (start1 != null)
            {
                if (count % 2 == 1)
                {
                    mid = mid.next;
                }
                count++;
                start1 = start1.next;
            }
            if (mid != null)
            {
                Console.WriteLine("The center element is " + mid.data);
            }
        }
        /// <summary>
        /// Reverse linkedlist
        /// </summary>
        public void Reverse()
        {
            Node prev = null;
            Node current = start;
            while (current != null)
            {
                Node temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            start = prev;
            Traverse();
        }
        /// <summary>
        /// size of linkedlist
        /// </summary>
        public void Size()
        {
            int n = 0;
            Node p;
            if (start == null)
            {
                Console.WriteLine("LinkedList is Empty ");
                return;
            }
            p = start;
            while (p != null)
            {
                n++;
                p = p.next;
            }
            Console.WriteLine("Number of nodes : " + n);
        }
        /// <summary>
        /// sorting linkedlist
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public Node Sort(Node h)
        {
            if (h == null || h.next == null)
            {
                return h;
            }

            Node middle = GetMiddle(h);
            Node nextofmiddle = middle.next;
            middle.next = null;
            Node left = Sort(h);
            Node right = Sort(nextofmiddle);
            Node sortedlist = SortedMerge(left, right);
            return sortedlist;
        }

        Node SortedMerge(Node a, Node b)
        {
            if (a == null)
                return b;
            if (b == null)
                return a;
            Node result;
            if (a.data <= b.data)
            {
                result = a;
                result.next = SortedMerge(a.next, b);
            }
            else
            {
                result = b;
                result.next = SortedMerge(a, b.next);
            }
            return result;
        }

       /// <summary>
       /// get middle value from linkedlist
       /// </summary>
       /// <param name="h"></param>
       /// <returns></returns>

        Node GetMiddle(Node h)
        {
            // Base case
            if (h == null)
                return h;
            Node fastptr = h.next;
            Node slowptr = h;

            while (fastptr != null)
            {
                fastptr = fastptr.next;
                if (fastptr != null)
                {
                    slowptr = slowptr.next;
                    fastptr = fastptr.next;
                }
            }
            return slowptr;
        }
        /// <summary>
        /// Iterating LinkedList
        /// </summary>
        public void Iterator()
        {
            Node temp1 = start;
            if (temp1 == null)
            {
                Console.WriteLine("Linkedlist is empty");
            }
            else
            {
                Traverse();
            }

        }
    }
}