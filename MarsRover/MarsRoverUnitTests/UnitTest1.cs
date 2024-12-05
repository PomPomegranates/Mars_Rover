global using Coordinates = (int x, int y);
using Moq;
using System.Runtime.CompilerServices;
//[assembly: InternalsVisibleTo("DayTwoTests")]
using MarsRover;
using MarsRover.Inputs;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
namespace MarsRoverUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //arrange
            Plateau.GetMap();
        }
        [Test]
        public void TestDefaultMap()
        {
            
            //act
            var plateau = Plateau.GetMap();
            //assert
            Assert.That(plateau.MapSize, Is.EqualTo((10, 10)));
        }


        [TestCase ("LLRMR", new Instruction[] { Instruction.L, Instruction.L, Instruction.R, Instruction.M, Instruction.R })]
        [TestCase("RRRRRR", new Instruction[] { Instruction.R, Instruction.R, Instruction.R, Instruction.R, Instruction.R, Instruction.R })]
        [TestCase("YYYYYYYY", new Instruction[] { })]
        public void RoverInputTest(string input, Instruction[] output)
        {
            var actualOutput = RoverInput.Input(input);

            actualOutput.Should().BeEquivalentTo(output);

        }





        [Test]
        public void MapInputTest1()
        {
            var actualOutputNormalOutput = MarsTerrainParser.ParseMapInput("5,6");
            var expectedNormalOutput = new Coordinates(5, 6);
            var actualOutputShouldFailMultipleNumbers = MarsTerrainParser.ParseMapInput("5,5,5,5");
            
            var actualOutputShouldSucceedLargeNumbers = MarsTerrainParser.ParseMapInput("555,2");
            var expectedLargeNumbers = new Coordinates(555,2);
            var actualOutputShouldFailMultipleLetters = MarsTerrainParser.ParseMapInput("www, d");
            var actualOutputShouldSucceed00 = MarsTerrainParser.ParseMapInput("0,0");
            var expected00 = new Coordinates(0, 0);
            var actualOutputShouldNotBeNull = MarsTerrainParser.ParseMapInput("0,0");
            var actualOutputShouldNotWork = MarsTerrainParser.ParseMapInput("0,");



            Assert.Multiple(() =>
            {
                Assert.That(actualOutputNormalOutput, Is.EqualTo(expectedNormalOutput));
                Assert.That(actualOutputShouldFailMultipleNumbers, Is.EqualTo(null));
                Assert.That(actualOutputShouldSucceedLargeNumbers, Is.EqualTo(expectedLargeNumbers));
                Assert.That(actualOutputShouldFailMultipleLetters, Is.EqualTo(null));
                Assert.That(actualOutputShouldSucceed00, Is.EqualTo(expected00));
                Assert.That(actualOutputShouldNotBeNull, Is.Not.EqualTo(null));
                Assert.That(actualOutputShouldNotWork, Is.EqualTo(null));
                
            });

            

        }
        [Test]
        public  void TestMapGeneration()
        {
            //arrange
            Plateau.GetMap((3, 4));
            //act
            var plateau = Plateau.GetMap();
            //assert
            Assert.That(plateau.MapSize, Is.EqualTo((3, 4)));
        }
        
        [Test]
        public void TestOverrideMap()
        {
            //arrange
            Plateau.GetMap();
            //act
            var plateau = Plateau.GetMap((4,4));
            //assert
            Assert.That(plateau.MapSize, Is.EqualTo((4, 4)));
        }
        [Test]
        public void LaunchMissionControlTest()
        {
            //arrange
            MissionControl.LaunchMissionControl(3);
            //act
            var missionControl = MissionControl.GetMissionControl();
            //assert
            Assert.That(missionControl.Rovers.Count, Is.EqualTo(3));
        }
        [Test]
        public void OverideMissionControlTest()
        {
            //arrange
            MissionControl.GetMissionControl();
            //act
            var missionControl = MissionControl.LaunchMissionControl(5);
            //assert
            Assert.That(missionControl.Rovers.Count, Is.EqualTo(5));
        }
        [Test]
        public void DefaultMissionControlTest()
        {
            //arrange
            MissionControl.GetMissionControl();
            //act
            var missionControl = MissionControl.GetMissionControl();
            //assert
            Assert.That(missionControl.Rovers.Count, Is.EqualTo(1));
        }

        [Test]
        public void NamedRoverTest()
        {

            Rover rover = new("Piccolo", (2, 4), CardinalDirections.N);
            Assert.That(rover.Name, Is.EqualTo("Piccolo"));
        }
        [Test]
        public void OutOfBoundsRoverTest()
        {
            Plateau.GetMap((2, 3));
            Rover rover = new("Piccolo", (2, 4), CardinalDirections.N);
            Assert.That(rover._Position.Coordinates, Is.EqualTo((2,3)));
        }

        [Test]

        public void RotateRoverLeftTest() 
        {
            Rover rover = new("Piccolo", (2, 4), CardinalDirections.N);
            Assert.Multiple(() =>
            {

                rover.MoveRover(Instruction.L);
                Assert.That(rover._Position.Facing, Is.EqualTo(CardinalDirections.W));
                rover.MoveRover(Instruction.L);
                Assert.That(rover._Position.Facing, Is.EqualTo(CardinalDirections.S));
                rover.MoveRover(Instruction.L);
                Assert.That(rover._Position.Facing, Is.EqualTo(CardinalDirections.E));
                rover.MoveRover(Instruction.L);
                Assert.That(rover._Position.Facing, Is.EqualTo(CardinalDirections.N));

            });
        }
        [Test]

        public void RotateRoverRightTest()
        {
            Rover rover = new("Piccolo", (2, 4), CardinalDirections.N);
            Assert.Multiple(() =>
            {

                rover.MoveRover(Instruction.R);
                Assert.That(rover._Position.Facing, Is.EqualTo(CardinalDirections.E));
                rover.MoveRover(Instruction.R);
                Assert.That(rover._Position.Facing, Is.EqualTo(CardinalDirections.S));
                rover.MoveRover(Instruction.R);
                Assert.That(rover._Position.Facing, Is.EqualTo(CardinalDirections.W));
                rover.MoveRover(Instruction.R);
                Assert.That(rover._Position.Facing, Is.EqualTo(CardinalDirections.N));

            });
        }
        [Test]
        public void MultipleRoversRotateTest()
        {
            Rover rover = new("Piccolo", (2, 4), CardinalDirections.N);
            Rover rover2 = new("Piccolo", (2, 4), CardinalDirections.N);
            rover.MoveRover(Instruction.R);
            Assert.That(rover._Position.Facing, Is.EqualTo(CardinalDirections.E));
            Assert.That(rover2._Position.Facing, Is.EqualTo(CardinalDirections.N));
        }
        [Test]
        public void ForwardInputRotateTest()
        {
            Rover rover = new("Piccolo", (2, 4), CardinalDirections.N);
            rover.MoveRover(Instruction.M);

            Assert.That(rover._Position.Facing, Is.EqualTo(CardinalDirections.N));
        }
        [Test]
        public void MultipleInputsRotateTest()
        {
            Instruction[] instructions = RoverInput.Input("LLLRRRLLLRRRLLLRRRR");
            Rover rover = new("Piccolo", (2, 4), CardinalDirections.N);
            foreach (Instruction instruction in instructions) 
            {
                rover.MoveRover(instruction);
            }

            Assert.That(rover._Position.Facing, Is.EqualTo(CardinalDirections.E));
        }

        [Test]
        public void RoverCannotFallOffMapToTheSouth()
        {
            Rover rover = new("Piccolo", (2, 4), CardinalDirections.S);
            Plateau.GetMap((10, 10));
            Instruction[] instructions = RoverInput.Input("MMMMMMM");
            foreach (Instruction instruction in instructions) rover.MoveRover(instruction);
            rover._Position.Coordinates.Should().Be((2, 0));
        }
        [Test]
        public void RoverCannotFallOffMapToTheNorth()
        {
            Rover rover = new("Piccolo", (2, 4), CardinalDirections.N);
            Plateau.GetMap((10, 10));
            Instruction[] instructions = RoverInput.Input("MMMMMMMMMMMM");
            foreach (Instruction instruction in instructions) rover.MoveRover(instruction);
            rover._Position.Coordinates.Should().Be((2,10));
        }
        [Test]
        public void RoverCannotFallOffMapToTheEast()
        {
            Rover rover = new("Piccolo", (2, 4), CardinalDirections.E);
            Plateau.GetMap((5, 5));
            Instruction[] instructions = RoverInput.Input("MMMM");
            foreach (Instruction instruction in instructions) rover.MoveRover(instruction);
            rover._Position.Coordinates.Should().Be((5, 4));
        }
        [Test]
        public void RoverCannotFallOffMapToTheWest()
        {
            Rover rover = new("Piccolo", (2, 4), CardinalDirections.W);
            Plateau.GetMap((10, 10));
            Instruction[] instructions = RoverInput.Input("MMMMMMMMMMMMMMM");
            foreach (Instruction instruction in instructions) rover.MoveRover(instruction);
            rover._Position.Coordinates.Should().Be((0, 4));
        }
    }
}