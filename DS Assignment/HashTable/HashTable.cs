using System;

namespace HashTable
{
    public class Hashtable<T>
    {
        public readonly Node<T>[] buckets;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size"></param>
        public Hashtable(int size)
        {
            buckets = new Node<T>[size];
        }
        /// <summary>
        /// Adding Key and item to HashTable
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item"></param>
        public void Insert(string key,T item)
        {
            ValidateKey(key);
            var valueNode = new Node<T> { Key = key, Value = item, Next = null };
            int position = GetBucketByKey(key);
            Node<T> listNode = buckets[position];
            if(null == listNode)
            {
                buckets[position] = valueNode;
            }
            else
            {
                while(null!=listNode.Next)
                {
                    listNode = listNode.Next;
                }
                listNode.Next = valueNode;
            }
        }
        /// <summary>
        /// Getting Position for Key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetBucketByKey(string key)
        {
            return key[0] % buckets.Length;
        }
        /// <summary>
        /// Checking Key is valid or not
        /// </summary>
        /// <param name="key"></param>
        protected void ValidateKey(string key)
        {
            if(string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
        }
        /// <summary>
        /// Getting node from key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected (Node<T> Previous, Node<T> Current) GetNodeByKey(string key)
        {
            int position = GetBucketByKey(key);
            Node<T> listNode = buckets[position];
            Node<T> previous = null;
            while(null!=listNode)
            {
                if (listNode.Key == key)
                    return (previous,listNode);
                previous = listNode;
                listNode = listNode.Next;
            }
            return (null, null);
        }
        /// <summary>
        /// Getting Value from Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get(string key)
        {
            ValidateKey(key);
            var (_, Node) = GetNodeByKey(key);
            if (Node == null)
            {
                throw new ArgumentOutOfRangeException(nameof(key), $"the key '{key}' is not found");
            }
            return Node.Value;
        }
        /// <summary>
        /// checking whether key contained or not in HashTable
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            ValidateKey(key);
            var (_, Node) = GetNodeByKey(key);
            return null != Node;
        }
        /// <summary>
        /// Deleting Key from HashTable
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Delete(string key)
        {
            ValidateKey(key);
            int position = GetBucketByKey(key);
            var (previous, current) = GetNodeByKey(key);
            if (null == current)
                return false;
            if (null == previous)
            {
                buckets[position] = null;
                return true;
            }
            previous.Next = current.Next;
            return true;
        }
        /// <summary>
        /// Sixe of HashTable
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            int count = 0;
            foreach(Node<T> e in buckets)
            {
                if (e != null)
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// priting HashTable
        /// </summary>
        public void Traverse()
        {
            if (buckets == null)
            {
                Console.WriteLine("HashTable is empty");
            }
            else
            {
                Console.WriteLine("HashTable");
                foreach (Node<T> e in buckets)
                {
                    if (e != null)
                    {
                        Console.WriteLine("Key : " + e.Key + "         " + "value : " + e.Value);
                    }
                }
            }

        }
        /// <summary>
        /// Iterator method
        /// </summary>
        public void Iterator()
        {
            if (Size() == 0)
            {
                Console.WriteLine("Priority Queue is Empty");
            }
            else
            {
                Console.WriteLine("Elements in Prioririty Queue");
                Traverse();
            }
        }
    }
}
