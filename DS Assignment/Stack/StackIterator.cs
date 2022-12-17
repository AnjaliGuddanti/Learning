namespace StackExersise
{
    public class StackIterator<T> 
    {
        private readonly Stack<T> currentStack;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="currentStack"></param>
        public StackIterator(Stack<T> currentStack)
        {
            this.currentStack = currentStack;
        }
        /// <summary>
        /// Checking stack is empty or not
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return currentStack.IsEmpty();
        }
        /// <summary>
        /// deleting item from stack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            return currentStack.Pop();
        }
    }
}
