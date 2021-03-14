using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;
using MarsRover.Models;

namespace TestMarsRover
{
    [TestClass]
    public class InputValidatorTest
    {
        [TestMethod]
        public void CheckMapCoords_TwoIntInputWithSpace()
        {

            bool result = InputValidator.CheckMapCoords("3 5", out int x, out int y);

            Assert.AreEqual(true, result);
            Assert.AreEqual(3, x);
            Assert.AreEqual(5, y);
        }

        [TestMethod]
        public void CheckMapCoords_TwoNegativeInputWithSpace()
        {

            bool result = InputValidator.CheckMapCoords("-3 -5", out int x, out int y);

            Assert.AreEqual(false, result);
            Assert.AreEqual(0, x);
            Assert.AreEqual(0, y);
        }

        [TestMethod]
        public void CheckMapCoords_TwoStringInputWithSpace()
        {

            bool result = InputValidator.CheckMapCoords("X Y", out int x, out int y);

            Assert.AreEqual(false, result);
            Assert.AreEqual(0, x);
            Assert.AreEqual(0, y);
        }

        [TestMethod]
        public void CheckMapCoords_InputWithoutSpace()
        {

            bool result = InputValidator.CheckMapCoords("5", out int x, out int y);

            Assert.AreEqual(false, result);
            Assert.AreEqual(0, x);
            Assert.AreEqual(0, y);
        }

        [TestMethod]
        public void CheckRoverCoordsAndDirection_X_Y_AndCorrectDirectionInputWithSpace()
        {
            bool result = InputValidator.CheckRoverCoordsAndDirection("4 5 S", out int x, out int y, out Direction direction);
            Assert.AreEqual(true, result);
            Assert.AreEqual(4, x);
            Assert.AreEqual(5, y);
            Assert.AreEqual(Direction.S, direction);
        }

        [TestMethod]
        public void CheckRoverCoordsAndDirection_Negative_X_Y_AndCorrectDirectionInputWithSpace()
        {
            bool result = InputValidator.CheckRoverCoordsAndDirection("-4 -5 S", out int x, out int y, out Direction direction);
            Assert.AreEqual(false, result);
            Assert.AreEqual(0, x);
            Assert.AreEqual(0, y);
            Assert.AreEqual(Direction.N, direction);
        }

        [TestMethod]
        public void CheckRoverCoordsAndDirection_X_Y_AndWrongDirectionInputWithSpace()
        {
            bool result = InputValidator.CheckRoverCoordsAndDirection("4 5 F", out int x, out int y, out Direction direction);
            Assert.AreEqual(false, result);
            Assert.AreEqual(4, x);
            Assert.AreEqual(5, y);
            Assert.AreEqual(Direction.N, direction);
        }

        [TestMethod]
        public void CheckRoverCoordsAndDirection_MissingInputWithoutSpace()
        {
            bool result = InputValidator.CheckRoverCoordsAndDirection("45F", out int x, out int y, out Direction direction);
            Assert.AreEqual(false, result);
            Assert.AreEqual(0, x);
            Assert.AreEqual(0, y);
            Assert.AreEqual(Direction.N, direction);
        }

        [TestMethod]
        public void CheckMoveCommands_MissingInput()
        {
            bool result = InputValidator.CheckMoveCommands(" ");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CheckMoveCommands_CorrectInput()
        {
            bool result = InputValidator.CheckMoveCommands("LRMRMRMLLRM");
            Assert.AreEqual(true, result);
        }
    }
}
