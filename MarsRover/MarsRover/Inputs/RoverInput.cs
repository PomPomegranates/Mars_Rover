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
