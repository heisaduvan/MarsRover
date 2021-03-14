using System;
using MarsRover.Models;
using MarsRover.Models.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestMarsRover
{
    [TestClass]
    public class RoverTest
    {
        private BaseRover rover;
        private Mock<IMap> map = new Mock<IMap>();

        public RoverTest()
        {
            map.Setup(x => x.MaxX).Returns(5);
            map.Setup(x => x.MaxY).Returns(5);
            rover = new Rover(map.Object);
        }
        [TestMethod]
        public void TurnLeft_FromNorthToNorth()
        {
            rover.RoverDirection = Direction.N;
            rover.MoveCommandString = "L";
            rover.TurnLeft();
            Assert.AreEqual(Direction.W, rover.RoverDirection);
            rover.TurnLeft();
            Assert.AreEqual(Direction.S, rover.RoverDirection);
            rover.TurnLeft();
            Assert.AreEqual(Direction.E, rover.RoverDirection);
            rover.TurnLeft();
            Assert.AreEqual(Direction.N, rover.RoverDirection);
        }
        [TestMethod]
        public void TurnRight_FromNorthToNorth()
        {
            rover.RoverDirection = Direction.N;
            rover.MoveCommandString = "R";
            rover.TurnRight();
            Assert.AreEqual(Direction.E, rover.RoverDirection);
            rover.TurnRight();
            Assert.AreEqual(Direction.S, rover.RoverDirection);
            rover.TurnRight();
            Assert.AreEqual(Direction.W, rover.RoverDirection);
            rover.TurnRight();
            Assert.AreEqual(Direction.N, rover.RoverDirection);
        }
        [TestMethod]
        public void MoveNorth_InMap()
        {
            rover.RoverDirection = Direction.N;
            rover.PosX = 1;
            rover.PosY = 2;
            bool result = rover.MoveNorth();
            Assert.IsTrue(result);
            Assert.AreEqual(3, rover.PosY);
            Assert.AreEqual(1, rover.PosX);
            Assert.AreEqual(Direction.N, rover.RoverDirection);
        }
        [TestMethod]
        public void MoveNorth_OutMap()
        {
            rover.RoverDirection = Direction.N;
            rover.PosX = 5;
            rover.PosY = 5;
            bool result = rover.MoveNorth();
            Assert.IsFalse(result);
            Assert.AreEqual(5, rover.PosY);
            Assert.AreEqual(5, rover.PosX);
            Assert.AreEqual(Direction.N, rover.RoverDirection);
        }
        [TestMethod]
        public void MoveWest_InMap()
        {
            rover.RoverDirection = Direction.W;
            rover.PosX = 1;
            rover.PosY = 2;
            bool result = rover.MoveWest();
            Assert.IsTrue(result);
            Assert.AreEqual(0, rover.PosX);
            Assert.AreEqual(2, rover.PosY);
            Assert.AreEqual(Direction.W, rover.RoverDirection);
        }
        [TestMethod]
        public void MoveWest_OutMap()
        {
            rover.RoverDirection = Direction.W;
            rover.PosX = 0;
            rover.PosY = 5;
            bool result = rover.MoveWest();
            Assert.IsFalse(result);
            Assert.AreEqual(5, rover.PosY);
            Assert.AreEqual(0, rover.PosX);
            Assert.AreEqual(Direction.W, rover.RoverDirection);
        }
        [TestMethod]
        public void MoveSouth_InMap()
        {
            rover.RoverDirection = Direction.S;
            rover.PosX = 1;
            rover.PosY = 2;
            bool result = rover.MoveSouth();
            Assert.IsTrue(result);
            Assert.AreEqual(1, rover.PosY);
            Assert.AreEqual(1, rover.PosX);
            Assert.AreEqual(Direction.S, rover.RoverDirection);
        }
        [TestMethod]
        public void MoveSouth_OutMap()
        {
            rover.RoverDirection = Direction.S;
            rover.PosX = 5;
            rover.PosY = 0;
            bool result = rover.MoveSouth();
            Assert.IsFalse(result);
            Assert.AreEqual(0, rover.PosY);
            Assert.AreEqual(5, rover.PosX);
            Assert.AreEqual(Direction.S, rover.RoverDirection);
        }
        [TestMethod]
        public void MoveEast_InMap()
        {
            rover.RoverDirection = Direction.E;
            rover.PosX = 1;
            rover.PosY = 2;
            bool result = rover.MoveEast();
            Assert.IsTrue(result);
            Assert.AreEqual(2, rover.PosY);
            Assert.AreEqual(2, rover.PosX);
            Assert.AreEqual(Direction.E, rover.RoverDirection);
        }
        [TestMethod]
        public void MoveEast_OutMap()
        {
            rover.RoverDirection = Direction.E;
            rover.PosX = 5;
            rover.PosY = 5;
            bool result = rover.MoveEast();
            Assert.IsFalse(result);
            Assert.AreEqual(5, rover.PosY);
            Assert.AreEqual(5, rover.PosX);
            Assert.AreEqual(Direction.E, rover.RoverDirection);
        }
        [TestMethod]
        public void Move_InMap()
        {
            rover.RoverDirection = Direction.E;
            rover.PosX = 1;
            rover.PosY = 2;
            rover.Move();
            Assert.AreEqual(2, rover.PosY);
            Assert.AreEqual(2, rover.PosX);
            Assert.AreEqual(Direction.E, rover.RoverDirection);
        }
        [TestMethod]
        public void Move_OutMap()
        {
            rover.RoverDirection = Direction.E;
            rover.PosX = 5;
            rover.PosY = 2;
            rover.Move();
            Assert.AreEqual(2, rover.PosY);
            Assert.AreEqual(5, rover.PosX);
            Assert.AreEqual(Direction.E, rover.RoverDirection);
        }
        [TestMethod]
        public void ExecuteCommand_WithSampleInputOne()
        {
            rover.RoverDirection = Direction.N;
            rover.PosX = 1;
            rover.PosY = 2;
            rover.MoveCommandString = "LMLMLMLMM";
            rover.ExecuteCommand();
            Assert.AreEqual(3, rover.PosY);
            Assert.AreEqual(1, rover.PosX);
            Assert.AreEqual(Direction.N, rover.RoverDirection);
        }
        [TestMethod]
        public void ExecuteCommand_WithSampleInputTwo()
        {
            rover.RoverDirection = Direction.E;
            rover.PosX = 3;
            rover.PosY = 3;
            rover.MoveCommandString = "MMRMMRMRRM";
            rover.ExecuteCommand();
            Assert.AreEqual(1, rover.PosY);
            Assert.AreEqual(5, rover.PosX);
            Assert.AreEqual(Direction.E, rover.RoverDirection);
        }
    }
}
