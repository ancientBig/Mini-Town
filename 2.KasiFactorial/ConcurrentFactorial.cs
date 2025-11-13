using System.Numerics;

namespace _2.KasiFactorial
{
    public class ConcurrentFactorial
    {

        private static readonly object lockObject = new object();

        public static BigInteger CalculateFactorial(int number)
        {
            BigInteger result = 1;

            var tasks = new List<Task<BigInteger>>();
            int[] numbersToCalculate = { number, number - 1, number - 2, 5, 4 }; // Example numbers

            foreach (int num in numbersToCalculate)
            {
                // Task.Run is an easy way to offload work to the ThreadPool.
                tasks.Add(Task.Run(() => FactorialInternal(num)));
            }

            Task.WhenAll(tasks).Wait(); // Wait for all tasks to complete

            BigInteger finalCombinedResult = 1;
            foreach (var task in tasks)
            {
                // The result property is safe to access after the task is completed
                finalCombinedResult *= task.Result;
            }

            return finalCombinedResult; // This might be a meaningless result (multiplying factorials), but demonstrates concurrency
        }

        // A simple, thread-safe internal function to calculate factorial of one number
        private static BigInteger FactorialInternal(int n)
        {
            BigInteger result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Factorial of {n} calculated on thread {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

    }
}
