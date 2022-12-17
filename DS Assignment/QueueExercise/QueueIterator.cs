namespace QueueExercise
{
    public class QueueIterator<T>
    {
        private readonly Queue<T> currentQueue;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="currentStack"></param>
        public QueueIterator(Queue<T> currentQueue)
        {
            this.currentQueue = currentQueue;
        }
        /// <summary>
        /// checking queue empty or not
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return currentQueue.IsEmpty();
        }
        /// <summary>
        /// Deleting item from queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            return currentQueue.Dequeue();
        }
    }
}
