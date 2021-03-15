using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models.Abstract
{
    public abstract class BaseRover
    {
        public int PosX;
        public int PosY;
        public Direction RoverDirection;
        public string MoveCommandString;
        internal IMap PlatoMap;

        public BaseRover(IMap map)
        {
            PlatoMap = map;
        }
        public void ExecuteCommand()
        {
            var commands = this.MoveCommandString.ToCharArray();

            foreach (var command in commands)
            {
                if (Enum.TryParse(command.ToString(), out MoveCommand comm))
                {
                    switch (comm)
                    {
                        case MoveCommand.L:
                            TurnLeft();
                            break;
                        case MoveCommand.R:
                            TurnRight();
                            break;
                        case MoveCommand.M:
                            Move();
                            break;
                    }
                }
            }
        }
        public void Move()
        {
            switch (RoverDirection)
            {
                case Direction.N:
                    PosY = IsMoveValid(PosX, PosY + 1) ? PosY + 1 : PosY;
                    break;
                case Direction.W:
                    PosX = IsMoveValid(PosX-1, PosY) ? PosX- + 1 : PosX;
                    break;
                case Direction.S:
                    PosY = IsMoveValid(PosX, PosY - 1) ? PosY - 1 : PosY;
                    break;
                case Direction.E:
                    PosX = IsMoveValid(PosX + 1, PosY) ? PosX + 1 : PosX;
                    break;
            }
        }
        public bool IsMoveValid(int newX, int newY)
        {
            bool result = (newX >= 0 && newX <= PlatoMap.MaxX) && (newY >= 0 && newY <= PlatoMap.MaxY);

            if(!result)
            {
                Console.WriteLine($"Error : Rover harita sınırları dışına çıkamaz. [ {newX} , {newY}] noktası geçersiz.");
            }

            return result;
        }
        public void TurnLeft()
        {
            if (RoverDirection == Direction.N) { RoverDirection = Direction.W; return; }
            if (RoverDirection == Direction.W) { RoverDirection = Direction.S; return; }
            if (RoverDirection == Direction.S) { RoverDirection = Direction.E; return; }
            if (RoverDirection == Direction.E) { RoverDirection = Direction.N; return; }
        }
        public void TurnRight()
        {
            if (RoverDirection == Direction.N) { RoverDirection = Direction.E; return; }
            if (RoverDirection == Direction.E) { RoverDirection = Direction.S; return; }
            if (RoverDirection == Direction.S) { RoverDirection = Direction.W; return; }
            if (RoverDirection == Direction.W) { RoverDirection = Direction.N; return; }
        }
        public override string ToString()
        {
            return $"Roverın Koordinatları [ {PosX} , {PosY} ] {RoverDirection}";
        }
    }
}
