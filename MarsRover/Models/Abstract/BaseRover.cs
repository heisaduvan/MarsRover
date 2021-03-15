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
            bool isMoveSuccess = false;
            switch (RoverDirection)
            {
                case Direction.N:
                    isMoveSuccess = MoveNorth();
                    break;
                case Direction.W:
                    isMoveSuccess = MoveWest();
                    break;
                case Direction.S:
                    isMoveSuccess = MoveSouth();
                    break;
                case Direction.E:
                    isMoveSuccess = MoveEast();
                    break;
            }
            
            if(isMoveSuccess) { Console.WriteLine($"[ {PosX} , {PosY}] koordinatları keşfedildi."); }
        }
        public bool MoveNorth()
        {
            if ((PosY + 1) <= PlatoMap.MaxY) { PosY += 1; return true; }
            else { Console.WriteLine($"*Error : Rover harita sınırları dışına çıkamaz. [ {PosX} , {PosY + 1}] noktası geçersiz."); return false; }
        }
        public bool MoveWest()
        {
            if ((PosX - 1) >= 0) { PosX -= 1; return true; }
            else { Console.WriteLine($"Error : Rover harita sınırları dışına çıkamaz. [ {PosX - 1} , {PosY}] noktası geçersiz."); return false; }
        }
        public bool MoveSouth()
        {
            if ((PosY - 1) >= 0) { PosY -= 1; return true; }
            else { Console.WriteLine($"Error : Rover harita sınırları dışına çıkamaz. [ {PosX} , {PosY - 1}] noktası geçersiz."); return false; }
        }
        public bool MoveEast()
        {
            if ((PosX + 1) <= PlatoMap.MaxX) { PosX += 1; return true; }
            else { Console.WriteLine($"Error : Rover harita sınırları dışına çıkamaz. [ {PosX + 1} , {PosY}] noktası geçersiz."); return false; }
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
