using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotSimulator.Tests
{
    /// <summary>
    /// The main ToyRobot Test class.
    /// Contains methods for testing the basic Robot's simulation functions.
    /// </summary>
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void Robot_CommandIgnored_WhenNotPlacedYet()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("REPORT");
            Assert.AreEqual(robot.NOT_PLACED_YET_MESSAGE, result);
        }

        /// <summary>
        /// Test for PLACE command valid number of parameters
        /// </summary>
        [TestMethod]
        public void Robot_IgnoreCommandWrongNumberOfPlaceParameters()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE");
            Assert.AreEqual(robot.NOT_VALID_PLACE_PARAMS, result);

            result = robot.DoCommand("PLACE 1,2,EAST,WEST");
            Assert.AreEqual(robot.NOT_VALID_PLACE_PARAMS, result);
        }

        /// <summary>
        /// Test for PLACE command valid numeric POSITION parameters
        /// </summary>
        [TestMethod]
        public void Robot_IgnoreCommandPlaceNonNumericParameters()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 1,V,NORTH");
            Assert.AreEqual(robot.NOT_VALID_PLACE_PARAMS, result);
        }

        [TestMethod]
        public void Robot_CommandReturnEmptyString_AfterBeingPlaced()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,NORTH");
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Robot_Report_AfterBeingPlaced()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,NORTH");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,0,NORTH", result);
        }

        /// <summary>
        /// Test Robot's cardinal directions
        /// </summary>
        [TestMethod]
        public void Robot_Report_0_1_N_AfterPlaced_0_0_N_AndSingleMove()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,NORTH");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,1,NORTH", result);
        }

        [TestMethod]
        public void Robot_Report_1_0_E_AfterPlaced_0_0_E_AndSingleMove()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,EAST");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("1,0,EAST", result);
        }

        [TestMethod]
        public void Robot_Report_1_0_S_AfterPlaced_1_1_S_AndSingleMove()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 1,1,SOUTH");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("1,0,SOUTH", result);
        }

        [TestMethod]
        public void Robot_Report_0_1_W_AfterPlaced_1_1_W_AndSingleMove()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 1,1,WEST");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,1,WEST", result);
        }

        /// <summary>
        ///  Test left direction
        /// </summary>
        [TestMethod]
        public void Robot_Report_0_0_W_AfterPlaced_0_0_N_AndLeftCommand()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,NORTH");
            result = robot.DoCommand("LEFT");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,0,WEST", result);
        }

        [TestMethod]
        public void Robot_Report_0_0_S_AfterPlaced_0_0_W_AndLeftCommand()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,WEST");
            result = robot.DoCommand("LEFT");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,0,SOUTH", result);
        }

        [TestMethod]
        public void Robot_Report_0_0_E_AfterPlaced_0_0_S_AndLeftCommand()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,SOUTH");
            result = robot.DoCommand("LEFT");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,0,EAST", result);
        }

        [TestMethod]
        public void Robot_Report_0_0_N_AfterPlaced_0_0_E_AndLeftCommand()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,EAST");
            result = robot.DoCommand("LEFT");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,0,NORTH", result);
        }

        /// <summary>
        ///  Test right direction
        /// </summary>
        [TestMethod]
        public void Robot_Report_0_0_E_AfterPlaced_0_0_N_AndRightCommand()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,NORTH");
            result = robot.DoCommand("RIGHT");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,0,EAST", result);
        }

        [TestMethod]
        public void Robot_Report_0_0_S_AfterPlaced_0_0_E_AndRightCommand()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,EAST");
            result = robot.DoCommand("RIGHT");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,0,SOUTH", result);
        }

        [TestMethod]
        public void Robot_Report_0_0_W_AfterPlaced_0_0_S_AndRightCommand()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,SOUTH");
            result = robot.DoCommand("RIGHT");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,0,WEST", result);
        }

        [TestMethod]
        public void Robot_Report_0_0_N_AfterPlaced_0_0_W_AndRightCommand()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,WEST");
            result = robot.DoCommand("RIGHT");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,0,NORTH", result);
        }

        /// <summary>
        /// Test Robot's environment boundaries on placement
        /// </summary>
        [TestMethod]
        public void Robot_IgnoreCommand_AfterPlace_NegativeXCoordinate()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE -1,0,WEST");
            Assert.AreEqual(robot.OUT_OF_BOUNDS_MESSAGE, result);
        }

        [TestMethod]
        public void Robot_IgnoreCommand_AfterPlace_NegativeYCoordinate()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,-1,WEST");
            Assert.AreEqual(robot.OUT_OF_BOUNDS_MESSAGE, result);
        }

        [TestMethod]
        public void Robot_IgnoreCommand_AfterPlace_UpperBoundX()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 6,5,WEST");
            Assert.AreEqual(robot.OUT_OF_BOUNDS_MESSAGE, result);
        }

        [TestMethod]
        public void Robot_IgnoreCommand_AfterPlace_UpperBoundY()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 5,6,WEST");
            Assert.AreEqual(robot.OUT_OF_BOUNDS_MESSAGE, result);
        }

        /// <summary>
        ///  Test Robot's environment boundaries on movement 
        /// </summary>
        [TestMethod]
        public void Robot_IgnoreCommand_AfterMove_NegativeXCoordinate()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,WEST");
            result = robot.DoCommand("MOVE");
            Assert.AreEqual(robot.OUT_OF_BOUNDS_MESSAGE, result);
        }

        [TestMethod]
        public void Robot_IgnoreCommand_AfterMove_NegativeYCoordinate()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,SOUTH");
            result = robot.DoCommand("MOVE");
            Assert.AreEqual(robot.OUT_OF_BOUNDS_MESSAGE, result);
        }

        [TestMethod]
        public void Robot_IgnoreCommand_AfterMove_UpperBoundXCoordinate()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,EAST");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("MOVE");
            Assert.AreEqual(robot.OUT_OF_BOUNDS_MESSAGE, result);
        }

        [TestMethod]
        public void Robot_IgnoreCommand_AfterMove_UpperBoundYCoordinate()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,NORTH");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("MOVE");
            Assert.AreEqual(robot.OUT_OF_BOUNDS_MESSAGE, result);
        }

        /// <summary>
        /// Sample test provided 
        /// </summary>
        [TestMethod]
        public void ProvidedTest_A()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,NORTH");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,1,NORTH", result);
        }

        /// <summary>
        /// Sample test provided 
        /// </summary>
        [TestMethod]
        public void ProvidedTest_B()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 0,0,NORTH");
            result = robot.DoCommand("LEFT");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("0,0,WEST", result);
        }

        /// <summary>
        /// Sample test provided 
        /// </summary>
        [TestMethod]
        public void ProvidedTest_C()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE 1,2,EAST");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("LEFT");
            result = robot.DoCommand("MOVE");
            result = robot.DoCommand("REPORT");
            Assert.AreEqual("3,3,NORTH", result);
        }

        /// <summary>
        /// Test garbage input
        /// </summary>
        [TestMethod]
        public void Robot_ReturnsErrorMessage_AfterPlacement_WhenGarbageCommandSent()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("BANANAS");
            Assert.AreEqual(robot.NOT_VALID_COMMAND_MESSAGE, result);
        }

        /// <summary>
        /// Test garbage input
        /// </summary>
        [TestMethod]
        public void Robot_ReturnsValidCommandsMessage_WhenGarbageCommandSent()
        {
            ToyRobot robot = new ToyRobot();
            string result = robot.DoCommand("PLACE %,2,EAST");
            Assert.AreEqual(robot.NOT_VALID_COMMAND_MESSAGE, result);
        }
    }
}
