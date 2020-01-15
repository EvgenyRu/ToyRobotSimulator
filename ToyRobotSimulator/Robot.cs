using System;

namespace ToyRobotSimulator
{
    /// <summary>
    /// The main ToyRobot class.
    /// Contains all methods and properties for performing basic Robot's simulation functions.
    /// </summary>
    /// <remarks>
    /// This class can place, move, turn left/right Robot and report its location.
    /// </remarks>
    public class ToyRobot
    {
        #region Private Constants
        // Table size
        const int TABLE_SIZE_X = 5;
        const int TABLE_SIZE_Y = 5;

        // Initial bounderies
        const int LowerBoundX = 0;
        const int LowerBoundY = 0;

        // Movements Directions
        const string DIRECTION_NORTH = "NORTH";
        const string DIRECTION_SOUTH = "SOUTH";
        const string DIRECTION_EAST = "EAST";
        const string DIRECTION_WEST = "WEST";

        // Command strings constants
        const string COMMAND_PLACE = "PLACE";
        const string COMMAND_MOVE = "MOVE";
        const string COMMAND_REPORT = "REPORT";
        const string COMMAND_LEFT = "LEFT";
        const string COMMAND_RIGHT = "RIGHT";
        #endregion

        #region Public Error Messages
        // Error messages strings
        public string NOT_PLACED_YET_MESSAGE = "Command ignored: robot not placed yet";
        public string OUT_OF_BOUNDS_MESSAGE = $"Command ignored: out of bounds, maximum table size is {TABLE_SIZE_X}x{TABLE_SIZE_Y}, where X,Y > -1)";
        public string NOT_VALID_COMMAND_MESSAGE = "Command ignored: this command is not valid. Valid commands are:\nPLACE X,Y,F\nMOVE\nLEFT\nRIGHT\nREPORT";
        public string NOT_VALID_PLACE_PARAMS = "Command ignored: valid PLACE command can only accept 3 parameters: PLACE X,Y,DIRECTION";
        public string NOT_VALID_PLACE_NUMERIC = "Command ignored: first 2 arameters for 'PLACE' command must be numbers";
        public string NOT_VALID_PLACE_DIRECTION = "Command ignored: DIRECTION parameter for 'PLACE' command is not valid. Valid values are: NORTH, SOUTH, EAST, WEST";
        #endregion

        #region Private Properies
        int UpperBoundX { get; set; } = -1;
        int UpperBoundY { get; set; }  = -1;
        int PositionX { get; set; } = -1;
        int PositionY { get; set; } = -1;
        bool IsRobotPlaced { get; set; } = false;
        string Direction { get; set; } = string.Empty;
        string ErrorMsg { get; set; } = string.Empty;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor for the ToyRobot class
        /// </summary>
        public ToyRobot()
        {
            UpperBoundX = TABLE_SIZE_X;
            UpperBoundY = TABLE_SIZE_Y;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Validates Robot's position on the table. Must not exceed the pre-defined bounderies constants
        /// </summary>
        /// <returns>True if the bounderies are in the valid range, false otherwise</returns>
        bool ValidatePosition()
        {
            return PositionX >= LowerBoundX && PositionY >= LowerBoundY && PositionX <= UpperBoundX && PositionY <= UpperBoundY;
        }

        /// <summary>
        /// Executes PLACE command and places the Robot on the table upon received coordinates and Direction
        /// </summary>
        /// <param name="parCommand">String for the PLACE command</param>
        void Place(string parCommand)
        {
            string result = "";
            string[] placeStr = parCommand.Split(new char[] { ',', ' ' });

            if (placeStr.Length != 4)
                result = NOT_VALID_PLACE_PARAMS;

            else
            {
                // First 2 parameters must be numeric > -1 and not exceeding maximum table size
                bool isNumeric = int.TryParse(placeStr[1], out int num);

                if (!isNumeric)
                    result = NOT_VALID_PLACE_NUMERIC;
                else
                    PositionX = num;

                isNumeric = int.TryParse(placeStr[2], out num);

                if (!isNumeric)
                    result = NOT_VALID_PLACE_NUMERIC;
                else
                    PositionY = num;

                if (isNumeric)
                {
                    // Check for valid Direction values
                    string tmpDirection = placeStr[3];

                    if (tmpDirection != DIRECTION_EAST && tmpDirection != DIRECTION_WEST && tmpDirection != DIRECTION_NORTH && tmpDirection != DIRECTION_SOUTH)
                        result = NOT_VALID_PLACE_DIRECTION;

                    else
                    {
                        Direction = placeStr[3];

                        if (!ValidatePosition())
                            result = OUT_OF_BOUNDS_MESSAGE;
                        else
                            IsRobotPlaced = true;
                    }
                }
            }

            ErrorMsg = result;
        }

        /// <summary>
        /// Executes REPORT command
        /// </summary>
        /// <returns>Returns Robot's location in a form of {X,Y,DIRECTION}, or Error mesage if the Robot has not been placed on the table yet.</returns>
        string Report()
        {
            return IsRobotPlaced ? $"{PositionX},{PositionY},{Direction}" : NOT_PLACED_YET_MESSAGE;
        }

        /// <summary>
        /// Executes MOVE command
        /// </summary>
        void Move()
        {
            if (!IsRobotPlaced)
                ErrorMsg = NOT_PLACED_YET_MESSAGE;

            else
            {
                int originalX = PositionX;
                int originalY = PositionY;

                switch (Direction)
                {
                    case DIRECTION_NORTH:
                        PositionY ++;
                        break;

                    case DIRECTION_WEST:
                        PositionX --;
                        break;

                    case DIRECTION_SOUTH:
                        PositionY --;
                        break;

                    case DIRECTION_EAST:
                        PositionX ++;
                        break;
                }

                if (!ValidatePosition())
                {
                    PositionX = originalX;
                    PositionY = originalY;
                    ErrorMsg = OUT_OF_BOUNDS_MESSAGE;
                }
            }
        }

        // <summary>
        /// Executes LEFT command
        /// </summary>
        void Left()
        {
            switch (Direction)
            {
                case DIRECTION_NORTH:
                    Direction = DIRECTION_WEST;
                    break;

                case DIRECTION_WEST:
                    Direction = DIRECTION_SOUTH;
                    break;

                case DIRECTION_SOUTH:
                    Direction = DIRECTION_EAST;
                    break;

                case DIRECTION_EAST:
                    Direction = DIRECTION_NORTH;
                    break;
            }
        }

        // <summary>
        /// Executes RIGHT command
        /// </summary>
        void Right()
        {
            switch (Direction)
            {
                case DIRECTION_NORTH:
                    Direction = DIRECTION_EAST;
                    break;

                case DIRECTION_EAST:
                    Direction = DIRECTION_SOUTH;
                    break;
                
                case DIRECTION_SOUTH:
                    Direction = DIRECTION_WEST;
                    break;
                
                case DIRECTION_WEST:
                    Direction = DIRECTION_NORTH;
                    break;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Executes Robot's command by the received string command parameter
        /// </summary>
        /// <param name="parCommand">Command value parameter</param>
        /// <returns>Command execution status or error string</returns>
        public string DoCommand(string parCommand)
        {
            string strResult = "";
            ErrorMsg = "";

            try
            {
                if (parCommand.Split(' ')[0] == COMMAND_PLACE)
                    Place(parCommand);

                else if (parCommand == COMMAND_REPORT)
                    strResult = Report();

                else if (parCommand == COMMAND_MOVE)
                    Move();

                else if (parCommand == COMMAND_LEFT)
                    Left();

                else if (parCommand == COMMAND_RIGHT)
                    Right();

                else
                    ErrorMsg = NOT_VALID_COMMAND_MESSAGE;
            }

            catch (Exception parExp)
            {
                ErrorMsg = parExp.ToString();
            }

            if (!string.IsNullOrWhiteSpace(ErrorMsg))
                strResult = ErrorMsg;

            return strResult;
        }
        #endregion
    }
}
