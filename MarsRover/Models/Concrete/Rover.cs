using MarsRover.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class Rover : BaseRover
    {
        public Rover(IMap map) : base(map)
        {
            
        }
       
    }
}
