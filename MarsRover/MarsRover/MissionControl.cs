using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    internal class MissionControl
    {
        //public Rover Rover;
        private static MissionControl instance;
        public Dictionary<string, Rover> Rovers = new Dictionary<string,Rover>();
        
        private MissionControl(Rover rover)
        {

            Rovers.Add(rover.Name, rover);

        }

        public static MissionControl LaunchMissionControl(Coordinates coordinates, CardinalDirections cardinalDirection, string? name = null)
        {
            var rover = new Rover(name, coordinates, cardinalDirection);
            instance = new MissionControl(rover);

            return instance;
        }

        public static MissionControl GetMissionControl()
        {
            
            return instance;
        }

        public static void AddRover(Coordinates coords, CardinalDirections facing)
        {
            if (instance.Rovers.Count < 5)
            {
                Rover rover = new Rover(null, coords, facing);
                instance.Rovers.Add(rover.Name, rover);
            }
            else
            {
                Console.WriteLine("Too Many Rovers!");
            }
            
        }

        //public static void AddRover()


    }
}
