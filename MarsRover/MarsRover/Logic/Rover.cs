using MarsRover.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarsRover.Logic
{
    internal class Rover
    {
        public string Name;
        public Position _Position;
        private static int nameNumber = 0;
        private string[] _possibleNames = ["Dave", "Clarissa", "Margot", "Ingrid", "Pat", "Clementine"];

        public Rover(string? name, Coordinates startPosition, CardinalDirections facing)
        {
            if (name is not null)
            {
                Name = name;
            }
            else
            {
                Name = _possibleNames[nameNumber];
                nameNumber++;
                if (nameNumber > _possibleNames.Length)
                {
                    nameNumber = 0;
                }
            }
            _Position = new Position(startPosition, facing);
            CheckRoverPosition();
        }

        private void CheckRoverPosition()
        {
            var plateau = Plateau.GetMap();
            if (_Position.Coordinates.x < 0) _Position.Coordinates.x = 0;
            if (_Position.Coordinates.y < 0) _Position.Coordinates.y = 0;

            while (_Position.Coordinates.y > plateau.MapSize.y)
            {
                _Position.Coordinates.y--;
            }
            while (_Position.Coordinates.x > plateau.MapSize.x)
            {
                _Position.Coordinates.x--;
            }
        }
        public static Coordinates? ReleaseRover(string readInput)
        {
            Coordinates? input = (Coordinates)MarsTerrainParser.ParseMapInput(readInput);
            if (input != null) return input;
            else return (0, 0);
        }

        public void MoveRover(Instruction instruction)
        {
            switch (instruction)
            {
                case Instruction.L:
                    if (_Position.Facing == CardinalDirections.N)
                    {
                        _Position.Facing = CardinalDirections.W;
                    }
                    else _Position.Facing--;
                    break;
                case Instruction.R:
                    if (_Position.Facing == CardinalDirections.W)
                    {
                        _Position.Facing = CardinalDirections.N;
                    }
                    else _Position.Facing++;
                    break;
                case Instruction.M:
                    switch (_Position.Facing)
                    {
                        case CardinalDirections.N:
                            {
                                _Position.Coordinates.y++;
                                CheckRoverPosition();

                                break;
                            }
                        case CardinalDirections.S:
                            {
                                _Position.Coordinates.y--;
                                CheckRoverPosition();
                                break;
                            }

                        case CardinalDirections.E:
                            {
                                _Position.Coordinates.x++;
                                CheckRoverPosition();
                                break;
                            }
                        case CardinalDirections.W:
                            {
                                _Position.Coordinates.x--;
                                CheckRoverPosition();
                                break;
                            }

                    }
                    break;
            }
        }

    }
}
