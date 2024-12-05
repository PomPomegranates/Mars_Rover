global using Coordinates = (int x, int y);
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Inputs
{
    internal class MarsTerrainParser
    {
        public static Coordinates? ParseMapInput(string input)
        {

            string[] stringCoordinates = input.Split(',');
            if (stringCoordinates.Length == 2 && int.TryParse(stringCoordinates[0], out int resultX) && int.TryParse(stringCoordinates[1], out int resultY)) return new Coordinates(resultX, resultY);
            else return null;

        }
    }
}
