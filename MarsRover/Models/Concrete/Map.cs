using MarsRover.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class Map : IMap
    {
        private int maxX;
        private int maxY;
        public int MaxX { get => maxX; set => maxX = value; }
        public int MaxY { get => maxY; set => maxY = value; }
    }
}
