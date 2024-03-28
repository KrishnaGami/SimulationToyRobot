using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RobotConApp.Helpers
{
    public class ToyRobotSimulator
    {
        private static readonly Regex _placeCommand = new Regex(@"PLACE (\d+),(\d+),(\w+)");

        private readonly ToyRobotFacing _toyRobotFacing;

        public ToyRobotSimulator(ToyRobotFacing toyRobotFacing)
        {
            _toyRobotFacing = toyRobotFacing;
        }

        public void Execute(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return;

            if (command == "MOVE") _toyRobotFacing.Move();
            if (command == "LEFT") _toyRobotFacing.Left();
            if (command == "RIGHT") _toyRobotFacing.Right();
            if (command == "REPORT") Console.WriteLine(_toyRobotFacing.Report());

            var match = _placeCommand.Match(command);
            if (match.Success)
            {
                var xIsValid = int.TryParse(match.Groups[1].Value, out var x);
                var yIsValid = int.TryParse(match.Groups[2].Value, out var y);
                var direction = match.Groups[3].Value;
                if (xIsValid && yIsValid)
                {
                    _toyRobotFacing.Place(x, y, direction);
                }
            }
        }
    }
}
