using System.Collections.Generic;

namespace CoreBoy.gpu
{
    public class IntQueue
    {
        List<int> queue;
        //private Queue<int> _inner;
        public IntQueue(int capacity) => queue = new List<int>(capacity);
        public int Size() => queue.Count;
        public void Enqueue (int value) => queue.Add (value);
        public int Dequeue ()
        {
            var value = queue [0];
            queue.RemoveAt (0);
            return value;
        }
        public int Get (int index) => queue [index];
        public void Clear() => queue.Clear();

        public void Set(int index, int value)
        {
            queue [index] = value;
        }
    }
}