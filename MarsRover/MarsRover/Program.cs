using MarsRover.Inputs;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("DayTwoTests")]
namespace MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var input = RoverInput.Input(Console.ReadLine());
            foreach (var item in input) 
            {
                Console.WriteLine(item);
            }
            new Coordinates(5, 6);
        }
    }
}
