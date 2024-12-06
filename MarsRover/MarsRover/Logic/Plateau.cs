using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Logic
{
    public class Plateau
    {
        public Coordinates MapSize;
        private static Plateau instance;
        //public static Coordinates[] RoverPositions;



        private Plateau(Coordinates input)
        {
            MapSize = input;
        }

        public static Plateau GetMap()
        {
            if (instance == null)
            {
                instance = new Plateau((10, 10));
            }
            return instance;
        }

        public static Plateau GetMap(Coordinates? coordinates)
        {

            
                instance = new Plateau(coordinates ?? (5,5));
                return instance;


        }




        //public static Plateau GetMap(Coordinates? coordinates)
        //{
        //    if (instance.MapSize == coordinates)
        //    {
        //        return instance;
        //    }
        //    else if (coordinates == null)
        //    {
        //        return GetMap();
        //    }
        //    return GetMap(coordinates);

        //}
        //public static Plateau GetMap(Coordinates coordinates)
        //{
        //    if (instance.MapSize == coordinates)
        //    {
        //        return instance;
        //    }
        //    else
        //    {
        //        return instance = new Plateau(coordinates);
        //    }

        //}

    }
}
