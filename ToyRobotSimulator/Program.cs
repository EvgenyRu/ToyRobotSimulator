using System;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            ToyRobot robot = new ToyRobot();

            while (true)
            {
                Console.WriteLine("\nEnter a command for Robot ('X' to quit):");
                string strCommand = Console.ReadLine().Trim().ToUpper();

                if (strCommand == "X")
                    break;

                Console.WriteLine(robot.DoCommand(strCommand));
             }

            Console.WriteLine("Exited. Press any key to close... === test ===");
            Console.ReadKey();
        }
    }
}
