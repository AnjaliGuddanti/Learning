using System;

namespace QueueExercise
{
    /// <summary>
    /// Queue class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T>
    {
        private  T[] items;
        private readonly int front;
        private int rear;
        private readonly int capacity;
        public Queue()
        {
            capacity = 1000;
            items = new T[capacity];
            front = 0;
            rear = 0;
        }
        public Queue(int capacity)
        {
            this.capacity = capacity;
            items = new T[capacity];
            front = 0;
            rear = 0;
        }
        /// <summary>
        /// checking Queue is empty or not
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return front == rear;
        }
        /// <summary>
        /// Adding item to queue
        /// </summary>
        /// <param name="item"></param>
        
        public void Enqueue(T item)
        {
            if (IsFull())
            {
                throw new Exception("Queue is full");
            }
            items[rear] = item;
            rear++;
        }
        /// <summary>
        /// Deleting item from queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {

            // check if queue is empty 
            if (IsEmpty())
            {
                throw new Exception("Queue is empty");
            }
            T frontItem = items[this.front];
            // shift elements to the right
            for (int i = 0; i < rear - 1; i++)
            {
                items[i] = items[i + 1];
            }
            rear--;
            return frontItem;
        }
        /// <summary>
        /// Finding peek item from queue
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return items[front];
        }
        /// <summary>
        /// checking item contained in queue or not
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            for (int i = front; i < rear; i++)
            {
                if (item.Equals(items[i]))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Finding size of queue
        /// </summary>
        /// <returns></returns>
        public int Size()
        {

            return rear;
        }
        /// <summary>
        /// Reverse the queue
        /// </summary>
        public void Reverse()
        {
            T[] itemsTemp = new T[rear];
            int counter = rear - 1;
            for (int i = front; i < rear; i++)
            {
                itemsTemp[counter] = items[i];
                counter--;
            }
            items = itemsTemp;
        }
        /// <summary>
        /// Printing the items of queue
        /// </summary>
        public void Print()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty");
            }
            
            
            for (int i = front; i < rear; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
        /// <summary>
        /// checking Queue is Full or not
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return capacity == rear;
        }
        /// <summary>
        /// Finding center item from queue  
        /// </summary>
        public void Center()
        {
            Console.WriteLine("center element : {0}", items[rear/2]);
        }
        /// <summary>
        /// Finding minimum item
        /// </summary>
        /// <param name="q"></param>
        /// <param name="sortedIndex"></param>
        /// <returns></returns>
        static int MinIndex(ref Queue<int> q,int sortedIndex)
        {
            int minIndex = -1;
            int minValue = int.MaxValue;
            int n = q.Size();
            for(int i = 0;i<n; i++)
            {
                int curr = q.Peek();
                q.Dequeue();
                if(curr<=minValue&&i<=sortedIndex)
                {
                    minIndex = i;
                    minValue = curr;
                }
                q.Enqueue(curr);
            }
            return minIndex;
        }
        /// <summary>
        /// Inserting minimum item to rear
        /// </summary>
        /// <param name="q"></param>
        /// <param name="minIndex"></param>
        static void InsertMinToRear(ref Queue<int> q,int minIndex)
        {
            int minValue = 0;
            int n = q.Size();
            for(int i =0;i<n; i++)
            {
                int curr = q.Peek();
                q.Dequeue();
                if (i != minIndex)
                    q.Enqueue(curr);
                else
                    minValue = curr;
            }
            q.Enqueue(minValue);
        }
        /// <summary>
        /// Sorting the queue
        /// </summary>
        /// <param name="myQueue"></param>
        public void Sort(ref Queue<int>myQueue)
        {
            for(int i = 1; i<=myQueue.Size();i++)
            {
                int minIndex = MinIndex(ref myQueue, myQueue.Size() - 1);
                InsertMinToRear(ref myQueue, minIndex);
            }
        }

    }
    

}

    
