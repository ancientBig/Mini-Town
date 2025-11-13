using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.KasiStream
{
    public class ProducerConsumerQueue
    {
        private readonly Queue<int> queue = new Queue<int>();
        private readonly object lockObject = new object();
        private bool producing = true;

        public void Producer()
        {
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                int number = rand.Next(1, 100);
                lock (lockObject)
                {
                    queue.Enqueue(number);
                    Console.WriteLine($"Producer added: {number}");
                    Monitor.PulseAll(lockObject); // Notify waiting consumers
                }
                Thread.Sleep(rand.Next(100, 500)); 
            }
            lock (lockObject)
            {
                producing = false;
                Monitor.PulseAll(lockObject); // Notify consumers that production is finished
            }
        }

        public void Consumer()
        {
            while (true)
            {
                int number = 0;
                lock (lockObject)
                {
                    while (queue.Count == 0 && producing)
                    {
                        Monitor.Wait(lockObject); // Wait for producer to add something
                    }

                    if (queue.Count == 0 && !producing)
                    {
                        Console.WriteLine("Consumer finished all items.");
                        break;
                    }

                    number = queue.Dequeue();
                }
                Console.WriteLine($"Consumer read: {number}");
                Thread.Sleep(600); // Simulate work
            }
        }
    }
}
