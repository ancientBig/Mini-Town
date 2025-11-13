using _2.KasiFactorial;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        BigInteger result = ConcurrentFactorial.CalculateFactorial(10);
        Console.WriteLine($"Final (example combined) result: {result}");
    }
}