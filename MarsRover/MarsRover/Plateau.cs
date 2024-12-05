using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Plateau
    {
        public Coordinates MapSize;
        private static Plateau instance;
        public static Coordinates[] RoverPositions;


        private Plateau(Coordinates input)
        {
            MapSize = input;
            //RoverPositions = 
        }

        public static Plateau GetMap()
        {
            if (instance == null)
            {
                instance = new Plateau((10,10));
            }
             return instance;
        }

        public static Plateau GetMap(Coordinates coordinates)
        {
            if (instance.MapSize == coordinates)
            {
                return instance;
            }
            else
            {
                instance = new Plateau(coordinates);
                return instance;
            }
           
        }

            
    }
}
