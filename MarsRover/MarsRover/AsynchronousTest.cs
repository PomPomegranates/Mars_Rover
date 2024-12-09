using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class AsynchronousTest
    {
        internal static void ProcessNumber(int number)
        {
            List<int> myList = new();
            var random = new Random();
            //Console.WriteLine($"Processing number: {number}");
            Task.Delay(random.Next(1000, 10000)).Wait();
            //Console.WriteLine($"{number} has been processed");
            myList.Add(number);
            Console.Clear();
            Console.WriteLine($"Current Progress: {myList.Count}%");
        }
        internal static Task RunParallelTasksAsync()
        {
            List<int> numbers = Enumerable.Range(1, 100).ToList();
            return Task.Run(() => Console.WriteLine(Parallel.For(0, numbers.Count, ProcessNumber)));
        }
    }
}
