using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Position(Coordinates coordinates, CardinalDirections facing)
    {
        public Coordinates Coordinates = coordinates;
        public CardinalDirections Facing = facing;
    }
}
