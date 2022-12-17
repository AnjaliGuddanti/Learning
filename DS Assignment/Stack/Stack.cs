using System;

namespace StackExersise
{
    public class Stack<T>
    {
        /// <summary>
        /// Declaration
        /// </summary>
        private T[] items;
        private int top;
        private readonly int capacity;
        /// <summary>
        /// Constructor
        /// </summary>
        public Stack()
        {
            capacity = 10000;
            items = new T[capacity];
            top = -1;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity"></param>
        public Stack(int capacity)
        {
            this.capacity = capacity;
            items = new T[capacity];
            top = -1;
        }
        /// <summary>
        /// Adding item to the stack
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (!IsFull())
            {
                items[++top] = item;
            }
            else
            {
                throw new Exception("Stack is full");
            }
        }
        /// <summary>
        /// Removing peek item from stack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (!IsEmpty())
            {
                return items[top--];
            }
            else
            {
                throw new Exception("Stack is empty");
            }
        }
        /// <summary>
        /// Return First item from stack without deleting
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return items[top];
        }
        /// <summary>
        /// Returns size of stack
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return top + 1;
        }
        /// <summary>
        /// Contains value in stack or not
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            for (int i = 0; i < top; i++)
            {
                if (item.Equals(items[i]))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Traverse the stack
        /// </summary>
        public void Traverse()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty");
            }
            else
            {
                Console.WriteLine("Items in the stack are:");
                for (int i = top; i >= 0; i--)
                {
                    Console.WriteLine(items[i]);
                }
            }
        }
        /// <summary>
        ///  stack is empty or not
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() { return top == -1; }
        /// <summary>
        /// stack is full or not
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return top == capacity - 1;
        }
        /// <summary>
        /// Reverse stack
        /// </summary>
        public void Reverse()
        {
            T[] itemsTemp = new T[top + 1];
            int counter = top;
            for (int i = 0; i <= top; i++)
            {
                itemsTemp[counter] = items[i];
                counter--;
            }
            items = itemsTemp;
        }
        /// <summary>
        /// print center element of stack without removing
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <param name="current"></param>
        public void Center(Stack<int> s, int n, int current = 0)
        {
            if (s.Size() < 0 || current == n)
            {
                return;
            }
            int x = s.Peek();
            s.Pop();
            Center(s, n, current + 1);
            if (current == n / 2)
            {
                Console.WriteLine("Center element : {0}", x);
            }
            s.Push(x);
        }
        /// <summary>
        /// sort the stack
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public Stack<int> Sort(Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();
            while(Size() > 0)
            {
                var element = stack.Pop();
                while(temp.Size()>0 && element < temp.Peek())
                {
                    stack.Push(temp.Pop());
                   
                }
                temp.Push(element);

            }
            return temp;
        } 
    }

}


