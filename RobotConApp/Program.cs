using RobotConApp.Helpers;
using System;
using System.IO;
using System.Linq;

namespace RobotConApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inputFiles = args.Where(File.Exists);

            foreach (var path in inputFiles)
            {
                Console.WriteLine("Start Process for " + path);
                Console.WriteLine();

                ExecuteCommandsFrom(path);

                Console.WriteLine();
                Console.WriteLine("End Process");
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void ExecuteCommandsFrom(string path)
        {
            var toyRobot = new ToyRobotFacing();
            var simulator = new ToyRobotSimulator(toyRobot);

            using (var file = new StreamReader(path))
            {
                string command;
                while ((command = file.ReadLine()) != null)
                {
                    Console.WriteLine("Executing command: " + command);
                    simulator.Execute(command);
                }
            }
        }
    }
}
