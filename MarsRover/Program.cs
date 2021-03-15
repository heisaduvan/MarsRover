using Autofac;
using MarsRover.Models;
using MarsRover.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MarsRover>();
            builder.RegisterType<Map>().As<IMap>();
            return builder.Build();
        }

        static void Main(string[] args)
        {
            CompositionRoot().Resolve<MarsRover>().Execute();
        }
    }
}
