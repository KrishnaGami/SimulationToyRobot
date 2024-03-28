using FakeItEasy;
using NUnit.Framework;
using RobotConApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotConApp.Test.Helpers
{
    [TestFixture]
    public class ToyRobotSimulatorTest
    {
        [TestCase("PLACE 0,0,NORTH", 0, 0, RobotDirection.North)]
        [TestCase("PLACE 1,2,EAST", 1, 2, RobotDirection.East)]
        [TestCase("PLACE 3,4,SOUTH", 3, 4, RobotDirection.South)]
        [TestCase("PLACE 4,0,WEST", 4, 0, RobotDirection.West)]
        public void ExecutePlacecommand(string command, int x, int y, string RobotDirection)
        {
            var ToyRobotFacing = A.Fake<ToyRobotFacing>();
            var ToyRobotSimulator = new ToyRobotSimulator(ToyRobotFacing);

            ToyRobotSimulator.Execute(command);

            A.CallTo(() => ToyRobotFacing.Place(x, y, RobotDirection)).MustHaveHappened();
        }

        [Test]
        public void ExecuteMovecommand()
        {
            var ToyRobotFacing = A.Fake<ToyRobotFacing>();
            var ToyRobotSimulator = new ToyRobotSimulator(ToyRobotFacing);
            ToyRobotFacing.Place(2, 2, RobotDirection.North);

            ToyRobotSimulator.Execute("MOVE");

            A.CallTo(() => ToyRobotFacing.Move()).MustHaveHappened();
        }

        [Test]
        public void ExecuteLeftcommand()
        {
            var ToyRobotFacing = A.Fake<ToyRobotFacing>();
            var ToyRobotSimulator = new ToyRobotSimulator(ToyRobotFacing);
            ToyRobotFacing.Place(2, 2, RobotDirection.North);

            ToyRobotSimulator.Execute("LEFT");

            A.CallTo(() => ToyRobotFacing.Left()).MustHaveHappened();
        }

        [Test]
        public void ExecuteRightcommand()
        {
            var ToyRobotFacing = A.Fake<ToyRobotFacing>();
            var ToyRobotSimulator = new ToyRobotSimulator(ToyRobotFacing);
            ToyRobotFacing.Place(2, 2, RobotDirection.North);

            ToyRobotSimulator.Execute("RIGHT");

            A.CallTo(() => ToyRobotFacing.Right()).MustHaveHappened();
        }

        [Test]
        public void ExecuteReportcommand()
        {
            var ToyRobotFacing = A.Fake<ToyRobotFacing>();
            var ToyRobotSimulator = new ToyRobotSimulator(ToyRobotFacing);
            ToyRobotFacing.Place(2, 2, RobotDirection.North);

            ToyRobotSimulator.Execute("REPORT");

            A.CallTo(() => ToyRobotFacing.Report()).MustHaveHappened();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("A")]
        [TestCase("BB")]
        [TestCase("CCC")]
        [TestCase("PLACE x,0,NORTH")]
        [TestCase("PLACE 1,x,EAST")]
        [TestCase("PLACE 11111111111111111111,0,SOUTH")]
        [TestCase("PLACE 0,222222222222222222222,WEST")]
        public void Ignoreinvalidcommands(string command)
        {
            var ToyRobotFacing = A.Fake<ToyRobotFacing>();
            var ToyRobotSimulator = new ToyRobotSimulator(ToyRobotFacing);

            ToyRobotSimulator.Execute(command);

            A.CallTo(() => ToyRobotFacing.Place(A<int>.Ignored, A<int>.Ignored, A<string>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => ToyRobotFacing.Move()).MustNotHaveHappened();
            A.CallTo(() => ToyRobotFacing.Left()).MustNotHaveHappened();
            A.CallTo(() => ToyRobotFacing.Right()).MustNotHaveHappened();
            A.CallTo(() => ToyRobotFacing.Report()).MustNotHaveHappened();
        }
    }
}
