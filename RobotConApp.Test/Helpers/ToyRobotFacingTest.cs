using NUnit.Framework;
using RobotConApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotConApp.Test.Helpers
{
    [TestFixture]
    public class ToyRobotFacingTest
    {
        [TestCase(RobotDirection.North, RobotDirection.East)]
        [TestCase(RobotDirection.East, RobotDirection.South)]
        [TestCase(RobotDirection.South, RobotDirection.West)]
        [TestCase(RobotDirection.West, RobotDirection.North)]
        public void Rotaterobotright90degrees(string before, string after)
        {
            var toyRobot = new ToyRobotFacing();
            toyRobot.Place(1, 1, before);

            toyRobot.Right();

            Assert.AreEqual(toyRobot.Facing, after);
        }

        [TestCase(0, 0, RobotDirection.North, "0,0,NORTH")]
        [TestCase(1, 2, RobotDirection.East, "1,2,EAST")]
        [TestCase(3, 4, RobotDirection.South, "3,4,SOUTH")]
        [TestCase(4, 0, RobotDirection.West, "4,0,WEST")]
        public void Returnpositionwhenitisvalid(int x, int y, string direction, string report)
        {
            var toyRobot = new ToyRobotFacing();
            toyRobot.Place(x, y, direction);

            var result = toyRobot.Report();

            Assert.AreEqual(result, report);
        }


        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void SetrobotsXposition(int x)
        {
            var toyRobot = new ToyRobotFacing();

            toyRobot.Place(x, 2, RobotDirection.South);

            Assert.AreEqual(toyRobot.X, x);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void SetrobotsYposition(int y)
        {
            var toyRobot = new ToyRobotFacing();

            toyRobot.Place(1, y, RobotDirection.South);

            Assert.AreEqual(toyRobot.Y, y);
        }

        [TestCase(RobotDirection.North)]
        [TestCase(RobotDirection.South)]
        [TestCase(RobotDirection.East)]
        [TestCase(RobotDirection.West)]
        public void Setrobotsdirection(string direction)
        {
            var toyRobot = new ToyRobotFacing();

            toyRobot.Place(1, 2, direction);

            Assert.AreEqual(toyRobot.Facing, direction);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(5)]
        [TestCase(6)]
        public void DiscardcommandwhenXisinvalid(int x)
        {
            var toyRobot = new ToyRobotFacing();

            toyRobot.Place(x, 2, RobotDirection.South);

            Assert.AreNotEqual(toyRobot.X, x);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(5)]
        [TestCase(6)]
        public void DiscardcommandwhenYisinvalid(int y)
        {
            var toyRobot = new ToyRobotFacing();

            toyRobot.Place(1, y, RobotDirection.South);

            Assert.AreNotEqual(toyRobot.Y, y);
        }

        [TestCase("")]
        [TestCase("A")]
        [TestCase("BB")]
        [TestCase("CCC")]
        public void Discardcommandwhendirectionisinvalid(string direction)
        {
            var toyRobot = new ToyRobotFacing();

            toyRobot.Place(1, 2, direction);

            Assert.AreNotEqual(toyRobot.Facing, direction);
        }

        [Test]
        public void MoveNorthwhenfacingNorth()
        {
            var toyRobot = new ToyRobotFacing();
            toyRobot.Place(2, 2, RobotDirection.North);

            toyRobot.Move();

            Assert.AreEqual(toyRobot.X, 2);
            Assert.AreEqual(toyRobot.Y, 3);
        }

        [Test]
        public void MoveEastwhenfacingEast()
        {
            var toyRobot = new ToyRobotFacing();
            toyRobot.Place(2, 2, RobotDirection.East);

            toyRobot.Move();

            Assert.AreEqual(toyRobot.X, 3);
            Assert.AreEqual(toyRobot.Y, 2);
        }

        [Test]
        public void MoveSouthwhenfacingSouth()
        {
            var toyRobot = new ToyRobotFacing();
            toyRobot.Place(2, 2, RobotDirection.South);

            toyRobot.Move();

            Assert.AreEqual(toyRobot.X, 2);
            Assert.AreEqual(toyRobot.Y, 1);
        }

        [Test]
        public void MoveWestwhenfacingWest()
        {
            var toyRobot = new ToyRobotFacing();
            toyRobot.Place(2, 2, RobotDirection.West);

            toyRobot.Move();

            Assert.AreEqual(toyRobot.X, 1);
            Assert.AreEqual(toyRobot.Y, 2);
        }

        [Theory]
        [TestCase(4, 4, RobotDirection.North)]
        [TestCase(4, 4, RobotDirection.East)]
        [TestCase(0, 0, RobotDirection.South)]
        [TestCase(0, 0, RobotDirection.West)]
        public void Notcausetherobottofalloutsidethetable(int x, int y, string direction)
        {
            var toyRobot = new ToyRobotFacing();
            toyRobot.Place(x, y, direction);

            toyRobot.Move();

            Assert.AreEqual(toyRobot.X, x);
            Assert.AreEqual(toyRobot.Y, y);
        }


        [TestCase(RobotDirection.North, RobotDirection.West)]
        [TestCase(RobotDirection.East, RobotDirection.North)]
        [TestCase(RobotDirection.South, RobotDirection.East)]
        [TestCase(RobotDirection.West, RobotDirection.South)]
        public void Rotaterobotleft90degrees(string before, string after)
        {
            var toyRobot = new ToyRobotFacing();
            toyRobot.Place(1, 1, before);

            toyRobot.Left();

            Assert.AreEqual(toyRobot.Facing, after);
        }

        [Test]
        public void DiscardMovecommandwhentherobotwasnotplacedonthetable()
        {
            var toyRobot = new ToyRobotFacing();

            toyRobot.Move();

            Assert.IsNull(toyRobot.X);
            Assert.IsNull(toyRobot.Y);
            Assert.IsNull(toyRobot.Facing);
        }

        [Test]
        public void DiscardLeftcommandwhentherobotwasnotplacedonthetable()
        {
            var toyRobot = new ToyRobotFacing();

            toyRobot.Left();

            Assert.IsNull(toyRobot.X);
            Assert.IsNull(toyRobot.Y);
            Assert.IsNull(toyRobot.Facing);
        }

        [Test]
        public void DiscardRightcommandwhentherobotwasnotplacedonthetable()
        {
            var toyRobot = new ToyRobotFacing();

            toyRobot.Right();

            Assert.IsNull(toyRobot.X);
            Assert.IsNull(toyRobot.Y);
            Assert.IsNull(toyRobot.Facing);
        }

        [Test]
        public void DiscardReportcommandwhentherobotwasnotplacedonthetable()
        {
            var toyRobot = new ToyRobotFacing();

            var result = toyRobot.Report();

            Assert.IsNull(result);
        }
    }
}
