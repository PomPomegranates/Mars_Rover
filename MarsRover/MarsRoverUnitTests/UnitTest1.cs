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
    }
}