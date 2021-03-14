using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models.Abstract
{
    public interface IMap
    {
        int MaxX { get; set; }
        int MaxY { get; set; }
    }
}
