using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarsRover.Logic
{
    internal class MissionControl
    {
        //public Rover Rover;
        private static MissionControl instance;
        public Dictionary<string, Rover> Rovers = new Dictionary<string, Rover>();

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

        public static Rover GetRover(string name)
        {
            return instance.Rovers[name];
        }

        public static Position GetRoverPosition(string name)
        {

            Rover rover = instance.Rovers[name];
            return rover._Position;

        }
        public static void PrintRoverPosition(string name)
        {

            Rover rover = instance.Rovers[name];
            string x = rover._Position.Coordinates.x.ToString();
            string y = rover._Position.Coordinates.y.ToString();
            switch (rover._Position.Facing)
            {
                case CardinalDirections.N:
                    {
                        Console.WriteLine(x + ' ' + y + ' ' + 'N');
                        break;
                    }
                    case CardinalDirections.E: 
                    {
                        Console.WriteLine(x + ' ' + y + ' ' + 'E');
                        break;
                    }
                    case CardinalDirections.S: 
                    {
                        Console.WriteLine(x + ' ' + y + ' ' + 'S');
                        break;
                    }
                    case CardinalDirections.W:
                    {
                        Console.WriteLine(x + ' ' + y + ' ' + 'W');
                        break ;
                    }
            }

        }

        public static bool isCrash()
        {
            if (MissionControl.GetMissionControl().Rovers.Values.ToList().Select(x => x._Position.Coordinates.ToString()).Distinct().ToList().Count() == GetMissionControl().Rovers.Count())
            {
                return false;
            }
            return true;
            
        }


    }
}
