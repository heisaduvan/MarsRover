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
            rover.RoverDirection = Direction.N;
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
        public void IsMoveValid_ReturnFalse()
        {
            var resultUpperMaxY = rover.IsMoveValid(3,6);
            var resultLowerMinY = rover.IsMoveValid(3, -1);
            var resultUpperMaxX = rover.IsMoveValid(6, 3);
            var resultLowerMinX = rover.IsMoveValid(-1, 3);
            var result_UpperMaxY_LowerMinX = rover.IsMoveValid(-1, 6);
            var result_UpperMaxY_UpperMaxX = rover.IsMoveValid(6,6);
            var result_LowerMinY_LowerMinX = rover.IsMoveValid(-1, -1);
            var result_LowerMinY_UpperMaxX = rover.IsMoveValid(6, -1);

            Assert.IsFalse(resultUpperMaxY);
            Assert.IsFalse(resultLowerMinY);
            Assert.IsFalse(resultUpperMaxX);
            Assert.IsFalse(resultLowerMinX);
            Assert.IsFalse(result_UpperMaxY_LowerMinX);
            Assert.IsFalse(result_UpperMaxY_UpperMaxX);
            Assert.IsFalse(result_LowerMinY_LowerMinX);
            Assert.IsFalse(result_LowerMinY_UpperMaxX);
        }

        [TestMethod]
        public void IsMoveValid_ReturnTrue()
        {
            var resultUpperRighCorner = rover.IsMoveValid(5, 5);
            var resultUpperLeftCorner = rover.IsMoveValid(0, 5);
            var resultLowerLeftCorner = rover.IsMoveValid(0,0);
            var resultLowerRighCorner = rover.IsMoveValid(5, 0);
            var resultInMap = rover.IsMoveValid(2, 3);

            Assert.IsTrue(resultUpperRighCorner);
            Assert.IsTrue(resultUpperLeftCorner);
            Assert.IsTrue(resultLowerLeftCorner);
            Assert.IsTrue(resultLowerRighCorner);
            Assert.IsTrue(resultInMap);
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
