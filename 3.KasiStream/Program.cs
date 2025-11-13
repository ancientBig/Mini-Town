using _3.KasiStream;

public class Program
{
    public static void Main()
    {
        ProducerConsumerQueue pcQueue = new ProducerConsumerQueue();
        //Create the producer and consumer
        Thread producerThread = new Thread(new ThreadStart(pcQueue.Producer));
        Thread consumerThread = new Thread(new ThreadStart(pcQueue.Consumer));

        producerThread.Start();
        consumerThread.Start();

        producerThread.Join();
        consumerThread.Join();
        Console.WriteLine("Program finished.");
    }
}