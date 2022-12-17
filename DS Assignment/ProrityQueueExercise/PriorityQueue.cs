using System;
namespace PriorityQueue
{
    public class MyPriorityQueue
    {
        public Node head;
        public Node Front { get; set; }
        public int count;
        /// <summary>
        /// Constructor
        /// </summary>
        public MyPriorityQueue()
        {
            count = 0;
        }
        /// <summary>
        /// Creating priority Queue
        /// </summary>
        public void CreatePriorityQueue()
        {
        x:
            Console.WriteLine("Enter total number of elements:- ");
            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine("Error! Enter a valid value");
                goto x;
            }
            for (int i = 0; i < num; i++)
            {
            y:
                Console.WriteLine("Enter element:- ");
                if (!int.TryParse(Console.ReadLine(), out int element))
                {
                    Console.WriteLine("Error! Enter a valid value");
                    goto y;
                }
            z:
                Console.WriteLine("Enter priority of the element:- ");
                if (!int.TryParse(Console.ReadLine(), out int priority))
                {
                    Console.WriteLine("Error! Enter a valid value");
                    goto z;
                }
                Enqueue(priority, element);
            }
        }
        /// <summary>
        /// Adding elements to Priority Queue
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="element"></param>
        public void Enqueue(int priority, int element) 
        {
            if (Front == null)
            {
                Node obj = new Node(priority, element);
                Front = obj;
                return;
            }
            else
            {
                Node obj = new Node(priority, element); 
                Node temp = Front;
                if (obj.priority < temp.priority)
                {
                    obj.next = temp;
                    Front = obj;
                }
                else
                {
                    while (temp.next != null)
                    {
                        if (temp.next.priority > priority)
                        {
                            break;
                        }
                        temp = temp.next;
                    }
                    obj.next = temp.next;
                    temp.next = obj;
                }
            }
        }
        /// <summary>
        /// Deleting Element from Priority Queue
        /// </summary>
        public void Dequeue() 
        {
            Node temp1 = Front;
            Node temp2 = Front;
            if (Front == null)
            {
                System.Console.WriteLine("Priority Queue is empty.");
                return;
            }
            while (temp1.next != null)
            {
                temp1 = temp1.next;
            }
            while (temp2.next.next != null)
            {
                temp2 = temp2.next;
            }
            Console.WriteLine("The element removed is:- " + temp1.data);
            temp2.next = null;
        }
        /// <summary>
        /// Center element of priority Queue
        /// </summary>
        public void Center()
        {
            Node temp1 = Front;
            Node temp2 = Front;
            if (Front != null)
            {
                while (temp2 != null && temp2.next != null)
                {
                    temp2 = temp2.next.next;
                    temp1 = temp1.next;
                }
                Console.WriteLine("Center: {0}", temp1.data);
            }
        }
        /// <summary>
        /// checkind whether the element is contained or not
        /// </summary>
        /// <param name="element"></param>
        public void Contains(int element) 
        {
            Node temp = Front;
            int present = 1; while (temp != null) 
            {
                if (temp.data == element)
                {
                    present = 1;
                    break;
                }
                else
                {
                    present = 0;
                }
                temp = temp.next;
            } //end of while loop
            if (present == 1) //if present is 1 element is in the queue
            {
                Console.WriteLine("Element is present in queue.");
            }
            else
                Console.WriteLine("Element is not present in queue.");
        }
        /// <summary>
        /// Peek element of Priority Queue
        /// </summary>
        public void Peek() 
        {
            Node temp1 = Front;
            while (temp1.next != null)
            {
                temp1 = temp1.next;
            }
            Console.WriteLine("The peek element is:- " + temp1.data); //removes the top element
        }
        /// <summary>
        /// Finding size of Priority Queue
        /// </summary>
        public void Size() //function for the size of Priority Queue
        {
            int count = 0;
            Node temp = Front;
            while (temp != null)
            {
                count++; //counter variable
                temp = temp.next;
            }
            Console.WriteLine("Size of Queue is:- {0}", count);
        }
        /// <summary>
        /// Iterator Method
        /// </summary>
        public void Iterator()
        {
            if (Front != null)
            {
                Front.Iterator();
            }
        }
        /// <summary>
        /// Reverse of Priority Queue
        /// </summary>
        /// <returns></returns>
        public Node ReverseQueue() 
        {
            Node prev = null;
            Node current = Front;
            Node temp;
            while (current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            Front = prev;
            return Front;
        }
        /// <summary>
        /// Printing Priority Queue
        /// </summary>
        public void PrintQueue()
        {
            if (Front != null)
            {
                Front.Print();
            }
        }
        
    }
}
    
