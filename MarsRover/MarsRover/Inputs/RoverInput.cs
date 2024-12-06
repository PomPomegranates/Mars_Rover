using MarsRover.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("DayTwoTests")]
namespace MarsRover.Inputs
{
    internal class RoverInput : IInput
    {
        //This class recieves Input from a string 


        public static (Coordinates coords, CardinalDirections facing) RoverInitialiser(string? input)
        {
            CardinalDirections facing = new CardinalDirections();
            string[] roverStart = input.Split(' ');
                if (roverStart.Length == 3 && int.TryParse(roverStart[0], out int resultX) && int.TryParse(roverStart[1], out int resultY))
                {
                    switch (roverStart[2].ToUpper())
                    {
                        case "N":
                            facing = CardinalDirections.N;
                            return (new Coordinates(resultX, resultY),facing);
                        case "E":
                            facing = CardinalDirections.E;
                            return (new Coordinates(resultX, resultY), facing);
                        case "S":
                            facing = CardinalDirections.S;
                            return (new Coordinates(resultX, resultY), facing);
                        case "W":
                            facing = CardinalDirections.W;
                            return (new Coordinates(resultX, resultY), facing);
                        default:
                            break;
                    }
                }

            Console.WriteLine("Returning Default");
            return (new Coordinates(0, 0), CardinalDirections.N);


        }
        public static Instruction[] Input(string? input)
        {
            List<Instruction> instructions = [];

                foreach (char letter in input.ToUpper())
                {
                    switch (letter)
                    {
                        case 'L':
                            instructions.Add(Instruction.L);
                            break;
                        case 'M':
                            instructions.Add(Instruction.M);
                            break;
                        case 'R':
                            instructions.Add(Instruction.R);
                            break;
                        default:
                            break;

                    }
                }
            return instructions.ToArray();
        }


    }
}
