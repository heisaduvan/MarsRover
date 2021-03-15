using MarsRover.Models;
using MarsRover.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class MarsRover
    {
        private static List<BaseRover> rovers = new List<BaseRover>();
        private static IMap map;

        public MarsRover()
        {
            map = new Map(); 
        }

        static void Main(string[] args)
        {
            GetMapCoords();

            GetRoverCoords();

            foreach(var rover in rovers)
            {
                rover.ExecuteCommand();
                Console.WriteLine(rover.ToString());
            }

            Console.ReadLine();
        }

        private static void GetMapCoords()
        {
            Console.Write("Haritanın sağ üst köşesinin koordinatlarını giriniz. [ X Y ] = ");
            if (InputValidator.CheckMapCoords(Console.ReadLine(), out int upperRightX, out int upperRightY))
            {
                map.MaxX = upperRightX;
                map.MaxY = upperRightY;
                return;
            }

            GetMapCoords();
        }

        private static void GetRoverCoords()
        {
            Console.Write("Roverın koordinatlarını ve yönünü giriniz. [ X Y N,W,S,E ] = ");
            if (InputValidator.CheckRoverCoordsAndDirection(Console.ReadLine(), out int x, out int y, out Direction _direction))
            {
                Rover rover = new Rover(map)
                {
                    PosX = x,
                    PosY = y,
                    RoverDirection = _direction
                };

                Console.WriteLine(rover.ToString());

                GetRoverCommand(rover);

                rovers.Add(rover);

                Console.WriteLine("Başka bir rover eklemek istiyorsanız E'ye basınız.");
                Console.WriteLine("Devam etmek için herhangi bir tuşa basabilirsiniz.");
                if (Console.ReadLine() != "E") return;
            }
            GetRoverCoords();
        }

        private static void GetRoverCommand(BaseRover rover)
        {
            Console.Write("Koordinatlarını girdiğiniz rover için hareket komutlarını giriniz. [L R M] = ");
            var commands = Console.ReadLine();
            if (InputValidator.CheckMoveCommands(commands))
            {
                rover.MoveCommandString = commands;
                return;
            }

            GetRoverCommand(rover);
        }
    }
}
