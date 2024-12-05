using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    internal class MissionControl
    {
        public Rover[] Rovers;
        private static MissionControl instance;

        private MissionControl(Rover[] numberOfRovers)
        {
            Rovers = numberOfRovers;

        }

        public static MissionControl LaunchMissionControl(int numberOfRovers)
        {
            instance = new MissionControl(new Rover[numberOfRovers]);

            return instance;
        }

        public static MissionControl GetMissionControl()
        {
            
            if (instance == null)
            {
                instance = new MissionControl(new Rover[1]);
            }
            return instance;
        }


    }
}
