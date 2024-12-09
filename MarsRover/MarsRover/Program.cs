using MarsRover.Inputs;
using MarsRover.Logic;
using MarsRover.User_Interface;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("DayTwoTests")]
namespace MarsRover
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("1 2 N\r\nLMLMLMLMM\r\n3 3 E\r\nMMRMMRMRRM");
            //Plateau.GetMap(MarsTerrainParser.ParseMapInput("5 5"));

            //MissionControl.LaunchMissionControl(RoverInput.RoverInitialiser("1 2 n").coords, RoverInput.RoverInitialiser("1 2 n").facing);
            //var control = MissionControl.GetMissionControl();
            //var initialiser = RoverInput.RoverInitialiser("3 3 e");
            //MissionControl.AddRover(initialiser.coords, initialiser.facing);
            //MissionControl.GetRover("Spirit").MoveRover(RoverInput.Input("LMLMLMLMM"));
            //MissionControl.GetRover("Opportunity").MoveRover(RoverInput.Input("MMRMMRMRRM"));
            //MissionControl.PrintRoverPosition("Spirit");
            //MissionControl.PrintRoverPosition("Opportunity");

            //Console.WriteLine( (char)160 );
            Display.TurnOn();
            Display.CreateMap();
            while (Display.IsRunning())
            {
                Display.ShowMap();
                await Task.Delay(10);
                Console.ReadLine();
                Console.Clear();
            }
            

            //await //AsynchronousTest.RunParallelTasksAsync();//.RunSynchronously();
            

            //MissionControl.LaunchMissionControl((2, 4), CardinalDirections.S);

            //var missionControl = MissionControl.GetMissionControl();
            //Console.WriteLine(missionControl.Rovers.ElementAt(0).Value.Name);//.ElementAt(0).Value.Name.Should().NotBeNull();


        }
    }
}
