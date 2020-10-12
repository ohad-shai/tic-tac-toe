using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_BusinessLogic
{
    /// <summary>
    /// Computer (an electronic device) that can play a game
    /// </summary>
    public sealed class Computer : Player
    {
        #region Fields

        private static int countPlays; // Counts the play moves of the computer every game
        private int level;
        Random random = new Random();

        #endregion
        
        #region Properties

        /// <summary>
        /// Holds the level of the computer!
        /// </summary>
        public int Level
        {
            get { return level; }
            // Can not set this property
        }

        #endregion
        
        #region C'tor

        public Computer(string name, Shape playerShape, int level)
            : base(name, playerShape)
        {
            if (level < 1 || level > 3) // Throw exception, if level is not 1-3!
            {
                throw new Exception("Invalid computer level...");
            }

            this.level = level;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Looking for a potential winning, means 1 cell is left to draw a 3-cells-winning!
        /// If found a potential, it plays to draw the win!
        /// And then returns a 'true' indicator to inform other methods not to take any additional steps!
        /// </summary>
        /// <param name="game">Where to play the move</param>
        /// <returns>Indicator if found a potential winning</returns>
        private bool FindPotentialWinning(Game game)
        {
            bool isWinFound = false; // Indicator if found a win, to inform other methods later by return this!
            int diagonalCol = 2; // Helps to calculate diagonal columns

            if (countPlays >= 2) // Performance improvement - only after 2 moves there's a potential for winning!
            {
                Shape[] winLocator = new Shape[3]; // This 3-cells array locates a win by taking samples from the GameTable!

                #region Check HORIZONTAL lines for potential

                for (int iRow = 0; iRow < 3; iRow++) // Runs for the <Rows> in the GameTable!
                {
                    for (int iCol = 0; iCol < 3; iCol++) // Runs for the <Columns> in the GameTable!
                    {
                        winLocator[iCol] = game.GameBoard[iRow, iCol]; // Sampling the (3-cells) line to the locator
                    }

                    // Now, check potential in the locator array:

                    if (winLocator[0] == this.PlayerShape && winLocator[1] == this.PlayerShape && winLocator[2] == Shape.Empty) // Means 1 cell is left to win
                    {
                        game.GameBoard[iRow, 2] = this.PlayerShape; // Play the move to win!
                        return isWinFound = true; // Found a win!
                    }
                    else if (winLocator[1] == this.PlayerShape && winLocator[2] == this.PlayerShape && winLocator[0] == Shape.Empty) // Means 1 cell is left to win
                    {
                        game.GameBoard[iRow, 0] = this.PlayerShape; // Play the move to win!
                        return isWinFound = true; // Found a win!
                    }
                    else if (winLocator[0] == this.PlayerShape && winLocator[2] == this.PlayerShape && winLocator[1] == Shape.Empty) // Means 1 cell is left to win
                    {
                        game.GameBoard[iRow, 1] = this.PlayerShape; // Play the move to win!
                        return isWinFound = true; // Found a win!
                    }
                    // Continue to sample next row...
                }

                #endregion

                #region Check VERTICAL lines for potential

                for (int iCol = 0; iCol < 3; iCol++) // Runs for the <Columns> in the GameTable!
                {
                    for (int iRow = 0; iRow < 3; iRow++) // Runs for the <Rows> in the GameTable!
                    {
                        winLocator[iRow] = game.GameBoard[iRow, iCol]; // Sampling the (3-cells) line to the locator
                    }

                    // Now, check potential in the locator array:

                    if (winLocator[0] == this.PlayerShape && winLocator[1] == this.PlayerShape && winLocator[2] == Shape.Empty) // Means 1 cell is left to win
                    {
                        game.GameBoard[2, iCol] = this.PlayerShape; // Play the move to win!
                        return isWinFound = true; // Found a win!
                    }
                    else if (winLocator[1] == this.PlayerShape && winLocator[2] == this.PlayerShape && winLocator[0] == Shape.Empty) // Means 1 cell is left to win
                    {
                        game.GameBoard[0, iCol] = this.PlayerShape; // Play the move to win!
                        return isWinFound = true; // Found a win!
                    }
                    else if (winLocator[0] == this.PlayerShape && winLocator[2] == this.PlayerShape && winLocator[1] == Shape.Empty) // Means 1 cell is left to win
                    {
                        game.GameBoard[1, iCol] = this.PlayerShape; // Play the move to win!
                        return isWinFound = true; // Found a win!
                    }
                    // Continue to sample next row...
                }

                #endregion

                #region Check DIAGONAL lines for potential

                ////////// DIAGONAL 1  //////////
                for (int iCell = 0; iCell < 3; iCell++) // Runs for the <Rows> in the GameTable! select one cell, in a row, for diagonal check!
                {
                    winLocator[iCell] = game.GameBoard[iCell, iCell]; // Sampling the (3-cells) line to the locator
                }

                // Now, check potential in the locator array:                                        
                if (winLocator[0] == this.PlayerShape && winLocator[1] == this.PlayerShape && winLocator[2] == Shape.Empty) // Means 1 cell is left to win
                {
                    game.GameBoard[2, 2] = this.PlayerShape; // Play the move to win!
                    return isWinFound = true; // Found a win!
                }
                else if (winLocator[1] == this.PlayerShape && winLocator[2] == this.PlayerShape && winLocator[0] == Shape.Empty) // Means 1 cell is left to win
                {
                    game.GameBoard[0, 0] = this.PlayerShape; // Play the move to win!
                    return isWinFound = true; // Found a win!
                }
                else if (winLocator[0] == this.PlayerShape && winLocator[2] == this.PlayerShape && winLocator[1] == Shape.Empty) // Means 1 cell is left to win
                {
                    game.GameBoard[1, 1] = this.PlayerShape; // Play the move to win!
                    return isWinFound = true; // Found a win!
                }

                ////////// DIAGONAL 2  //////////
                for (int iCell = 0; iCell < 3; iCell++) // Runs for the <Rows> in the GameTable! select one cell, in a row, for diagonal check!
                {
                    winLocator[iCell] = game.GameBoard[iCell, diagonalCol]; // Sampling the (3-cells) line to the locator
                    diagonalCol--; // Helps to calculate diagonal columns  
                }

                // Now, check potential in the locator array:
                if (winLocator[0] == this.PlayerShape && winLocator[1] == this.PlayerShape && winLocator[2] == Shape.Empty) // Means 1 cell is left to win
                {
                    game.GameBoard[2, 0] = this.PlayerShape; // Play the move to win!
                    return isWinFound = true; // Found a win!
                }
                else if (winLocator[1] == this.PlayerShape && winLocator[2] == this.PlayerShape && winLocator[0] == Shape.Empty) // Means 1 cell is left to win
                {
                    game.GameBoard[0, 2] = this.PlayerShape; // Play the move to win!
                    return isWinFound = true; // Found a win!
                }
                else if (winLocator[0] == this.PlayerShape && winLocator[2] == this.PlayerShape && winLocator[1] == Shape.Empty) // Means 1 cell is left to win
                {
                    game.GameBoard[1, 1] = this.PlayerShape; // Play the move to win!
                    return isWinFound = true; // Found a win!
                }

                #endregion

            }
            return isWinFound; // False
        }
        
        /// <summary>
        /// Plays a random move in the game table!
        /// </summary>
        /// <param name="game">Where to play the move</param>
        private void PlayRandom(Game game)
        {
            int rnd; // Holds a randomized number
            bool isOk; // Assigning validation indicator!

            do
            {
                isOk = false;
                rnd = random.Next(1, 10); // Randomized number between 1-9

                if (rnd == 1 && game.GameBoard[2, 0] == Shape.Empty) // If random is '1' (and the cell is 'Null')
                {
                    isOk = true; // Found a valid assignment!
                    game.GameBoard[2, 0] = this.PlayerShape; // Assign the play move to the board!
                }
                else if (rnd == 2 && game.GameBoard[2, 1] == Shape.Empty) // If random is '2'
                {
                    isOk = true; // Found a valid assignment!
                    game.GameBoard[2, 1] = this.PlayerShape; // Assign play move!
                }
                else if (rnd == 3 && game.GameBoard[2, 2] == Shape.Empty) // If random is '3'
                {
                    isOk = true; // Found a valid assignment!
                    game.GameBoard[2, 2] = this.PlayerShape; // Assign play move!
                }
                else if (rnd == 4 && game.GameBoard[1, 0] == Shape.Empty) // If random is '4'
                {
                    isOk = true; // Found a valid assignment!
                    game.GameBoard[1, 0] = this.PlayerShape; // Assign play move!
                }
                else if (rnd == 5 && game.GameBoard[1, 1] == Shape.Empty) // If random is '5'
                {
                    isOk = true; // Found a valid assignment!
                    game.GameBoard[1, 1] = this.PlayerShape; // Assign play move!
                }
                else if (rnd == 6 && game.GameBoard[1, 2] == Shape.Empty) // If random is '6'
                {
                    isOk = true; // Found a valid assignment!
                    game.GameBoard[1, 2] = this.PlayerShape; // Assign play move!
                }
                else if (rnd == 7 && game.GameBoard[0, 0] == Shape.Empty) // If random is '7'
                {
                    isOk = true; // Found a valid assignment!
                    game.GameBoard[0, 0] = this.PlayerShape; // Assign play move!
                }
                else if (rnd == 8 && game.GameBoard[0, 1] == Shape.Empty) // If random is '8'
                {
                    isOk = true; // Found a valid assignment!
                    game.GameBoard[0, 1] = this.PlayerShape; // Assign play move!
                }
                else if (rnd == 9 && game.GameBoard[0, 2] == Shape.Empty) // If random is '9'
                {
                    isOk = true; // Found a valid assignment!
                    game.GameBoard[0, 2] = this.PlayerShape; // Assign play move!
                }
            } while (!isOk); // While play move is ok!
        }
        
        /// <summary>
        /// Blocking the other player from winning!
        /// And then returns a 'true' indicator to inform other methods not to take any additional steps!
        /// </summary>
        /// <param name="game">Where to play the move</param>
        /// <returns>Indicator if succeeded in blocking the other player</returns>
        private bool BlockOtherPlayer(Game game)
        {
            bool isBlockOther = false; // Indicator if blocked a player, to inform other methods later by return this!
            int diagonalCol = 2; // Helps to calculate diagonal columns

            if (countPlays >= 2) // Performance improvement - only after 2 moves there's a potential for winning!
            {
                Shape[] blockLocator = new Shape[3]; // This 3-cells array locates situations to block other player by taking samples from the GameTable!

                #region Check HORIZONTAL lines

                for (int iRow = 0; iRow < 3; iRow++) // Runs for the <Rows> in the GameTable!
                {
                    for (int iCol = 0; iCol < 3; iCol++) // Runs for the <Columns> in the GameTable!
                    {
                        blockLocator[iCol] = game.GameBoard[iRow, iCol]; // Sampling the (3-cells) line to the locator
                    }

                    // Now, check the cells left for other player to win, in the locator array:
                    // First, check if computer does not own the cell
                    // Second, check if the cell is 'Empty'
                    // If the two above is false = means the other player owns the cell!!!

                    if (blockLocator[0] != this.PlayerShape && blockLocator[0] != Shape.Empty &&
                        blockLocator[1] != this.PlayerShape && blockLocator[1] != Shape.Empty &&
                        blockLocator[2] == Shape.Empty) // Means 1 cell is left for other player to win!
                    {
                        game.GameBoard[iRow, 2] = this.PlayerShape; // Block!
                        return isBlockOther = true; // Blocked other player!
                    }
                    else if (blockLocator[1] != this.PlayerShape && blockLocator[1] != Shape.Empty &&
                        blockLocator[2] != this.PlayerShape && blockLocator[2] != Shape.Empty &&
                        blockLocator[0] == Shape.Empty) // Means 1 cell is left for other player to win!
                    {
                        game.GameBoard[iRow, 0] = this.PlayerShape; // Block!
                        return isBlockOther = true; // Blocked other player!
                    }
                    else if (blockLocator[0] != this.PlayerShape && blockLocator[0] != Shape.Empty &&
                        blockLocator[2] != this.PlayerShape && blockLocator[2] != Shape.Empty && 
                        blockLocator[1] == Shape.Empty) // Means 1 cell is left for other player to win!
                    {
                        game.GameBoard[iRow, 1] = this.PlayerShape; // Block!
                        return isBlockOther = true; // Blocked other player!
                    }
                    // Continue to sample next row...
                }

                #endregion

                #region Check VERTICAL lines

                for (int iCol = 0; iCol < 3; iCol++) // Runs for the <Columns> in the GameTable!
                {
                    for (int iRow = 0; iRow < 3; iRow++) // Runs for the <Rows> in the GameTable!
                    {
                        blockLocator[iRow] = game.GameBoard[iRow, iCol]; // Sampling the (3-cells) line to the locator
                    }

                    // Now, check the cells left for other player to win, in the locator array:
                    // First, check if computer does not own the cell
                    // Second, check if the cell is 'Empty'
                    // If the two above is false = means the other player owns the cell!!!

                    if (blockLocator[0] != this.PlayerShape && blockLocator[0] != Shape.Empty &&
                        blockLocator[1] != this.PlayerShape && blockLocator[1] != Shape.Empty && 
                        blockLocator[2] == Shape.Empty) // Means 1 cell is left for other player to win!
                    {
                        game.GameBoard[2, iCol] = this.PlayerShape; // Block!
                        return isBlockOther = true; // Blocked other player!
                    }
                    else if (blockLocator[1] != this.PlayerShape && blockLocator[1] != Shape.Empty &&
                        blockLocator[2] != this.PlayerShape && blockLocator[2] != Shape.Empty && 
                        blockLocator[0] == Shape.Empty) // Means 1 cell is left for other player to win!
                    {
                        game.GameBoard[0, iCol] = this.PlayerShape; // Block!
                        return isBlockOther = true; // Blocked other player!
                    }
                    else if (blockLocator[0] != this.PlayerShape && blockLocator[0] != Shape.Empty &&
                        blockLocator[2] != this.PlayerShape && blockLocator[2] != Shape.Empty && 
                        blockLocator[1] == Shape.Empty) // Means 1 cell is left for other player to win!
                    {
                        game.GameBoard[1, iCol] = this.PlayerShape; // Block!
                        return isBlockOther = true; // Blocked other player!
                    }
                    // Continue to sample next row...
                }

                #endregion

                #region Check DIAGONAL lines

                ////////// DIAGONAL 1  //////////
                for (int iCell = 0; iCell < 3; iCell++) // Runs for the <Rows> in the GameTable! select one cell, in a row, for diagonal check!
                {
                    blockLocator[iCell] = game.GameBoard[iCell, iCell]; // Sampling the (3-cells) line to the locator
                }

                // Now, check the cells left for other player to win, in the locator array:
                // First, check if computer does not own the cell
                // Second, check if the cell is 'Empty'
                // If the two above is false = means the other player owns the cell!!!

                if (blockLocator[0] != this.PlayerShape && blockLocator[0] != Shape.Empty &&
                    blockLocator[1] != this.PlayerShape && blockLocator[1] != Shape.Empty &&
                    blockLocator[2] == Shape.Empty) // Means 1 cell is left for other player to win!
                {
                    game.GameBoard[2, 2] = this.PlayerShape; // Block!
                    return isBlockOther = true; // Blocked other player!
                }
                else if (blockLocator[1] != this.PlayerShape && blockLocator[1] != Shape.Empty &&
                    blockLocator[2] != this.PlayerShape && blockLocator[2] != Shape.Empty &&
                    blockLocator[0] == Shape.Empty) // Means 1 cell is left for other player to win!
                {
                    game.GameBoard[0, 0] = this.PlayerShape; // Block!
                    return isBlockOther = true; // Blocked other player!
                }
                else if (blockLocator[0] != this.PlayerShape && blockLocator[0] != Shape.Empty &&
                    blockLocator[2] != this.PlayerShape && blockLocator[2] != Shape.Empty &&
                    blockLocator[1] == Shape.Empty) // Means 1 cell is left for other player to win!
                {
                    game.GameBoard[1, 1] = this.PlayerShape; // Block!
                    return isBlockOther = true; // Blocked other player!
                }

                ////////// DIAGONAL 2  //////////
                for (int iCell = 0; iCell < 3; iCell++) // Runs for the <Rows> in the GameTable! select one cell, in a row, for diagonal check!
                {
                    blockLocator[iCell] = game.GameBoard[iCell, diagonalCol]; // Sampling the (3-cells) line to the locator
                    diagonalCol--; // Helps to calculate diagonal columns  
                }

                // Now, check cells left for other player to win, in the locator array:

                if (blockLocator[0] != this.PlayerShape && blockLocator[0] != Shape.Empty &&
                    blockLocator[1] != this.PlayerShape && blockLocator[1] != Shape.Empty &&
                    blockLocator[2] == Shape.Empty) // Means 1 cell is left for other player to win!
                {
                    game.GameBoard[2, 0] = this.PlayerShape; // Block!
                    return isBlockOther = true; // Blocked other player!
                }
                else if (blockLocator[1] != this.PlayerShape && blockLocator[1] != Shape.Empty &&
                    blockLocator[2] != this.PlayerShape && blockLocator[2] != Shape.Empty &&
                    blockLocator[0] == Shape.Empty) // Means 1 cell is left for other player to win!
                {
                    game.GameBoard[0, 2] = this.PlayerShape; // Block!
                    return isBlockOther = true; // Blocked other player!
                }
                else if (blockLocator[0] != this.PlayerShape && blockLocator[0] != Shape.Empty &&
                    blockLocator[2] != this.PlayerShape && blockLocator[2] != Shape.Empty &&
                    blockLocator[1] == Shape.Empty) // Means 1 cell is left for other player to win!
                {
                    game.GameBoard[1, 1] = this.PlayerShape; // Block!
                    return isBlockOther = true; // Blocked other player!
                }

                #endregion
                
            }
            return isBlockOther; // False
        }

        /// <summary>
        /// Based on algorithm provided, will sabotage the other player!
        /// </summary>
        /// <param name="game">Where to play the move</param>
        /// <returns>Indicator if succeeded with sabotage the other player</returns>
        private bool SabotageOtherPlayer(Game game)
        {
            bool isSabotagePlay = false; // Indicator if played a sabotage move, to inform other methods later by return this!
            bool isOwnRange = false; // Indicator if owns the range of the row / column, means computer owns at least 1 cell!

            #region Section 1 - Avoids sabotage move from the other player!

            // Defend 'center knockout', play somewhere in the edge, if other player holds 5 (center)
            if (game.GameBoard[1, 1] != Shape.Empty && game.GameBoard[1, 1] != this.PlayerShape) // If 5 (center) is hold
            {
                // Play somewhere in the edge!

                if (game.GameBoard[0, 0] == Shape.Empty) // If 7 is open
                {
                    game.GameBoard[0, 0] = this.PlayerShape; // Play move!
                    return isSabotagePlay = true;
                }
                else if (game.GameBoard[0, 2] == Shape.Empty) // If 9 is open
                {
                    game.GameBoard[0, 2] = this.PlayerShape; // Play move!
                    return isSabotagePlay = true;
                }
                else if (game.GameBoard[2, 0] == Shape.Empty) // If 1 is open
                {
                    game.GameBoard[2, 0] = this.PlayerShape; // Play move!
                    return isSabotagePlay = true;
                }
                else if (game.GameBoard[2, 2] == Shape.Empty) // If 3 is open
                {
                    game.GameBoard[2, 2] = this.PlayerShape; // Play move!
                    return isSabotagePlay = true;
                }
            }

            // Defend edges (7,9,1,3) sabotage algorithm!
            else if (((game.GameBoard[0, 0] != Shape.Empty && game.GameBoard[0, 0] != this.PlayerShape) || // If other player holds 7
                (game.GameBoard[0, 2] != Shape.Empty && game.GameBoard[0, 2] != this.PlayerShape) || // If other player holds 9
                (game.GameBoard[2, 0] != Shape.Empty && game.GameBoard[2, 0] != this.PlayerShape) || // If other player holds 1
                (game.GameBoard[2, 2] != Shape.Empty && game.GameBoard[2, 2] != this.PlayerShape)) && // If other player holds 3
                game.GameBoard[1, 1] == Shape.Empty) // If 5 (center) is 'Empty'
            {
                game.GameBoard[1, 1] = this.PlayerShape; // Defend! --> plays in center (5)
                return isSabotagePlay = true; // Avoided other player from sabotage the computer!
            }

            #endregion
            
            #region Section 2 - Inspect options in range!

            #region Check VERTICAL lines for potential

            for (int iCol = 0; iCol < 3; iCol++) // Runs for the <Rows> in the GameBoard!
            {
                for (int iRow = 0; iRow < 3; iRow++) // Runs for the <Columns> in the GameBoard!
                {
                    if (this.PlayerShape == game.GameBoard[iRow, iCol]) // Checks if it owns a cell
                    {
                        isOwnRange = true;
                    }
                }

                // Now, if found a cell that computer owns, it fills the next empty cell...                
                if (isOwnRange)
                {
                    for (int i = 0; i < 3; i++) // Check empty cell to fill
                    {
                        if (game.GameBoard[i, iCol] == Shape.Empty)
                        {
                            game.GameBoard[i, iCol] = this.PlayerShape;
                            return isSabotagePlay = true;
                        }
                    }
                }

                // Continue to next row...
            }

            #endregion
            
            #region Check HORIZONTAL lines for potential

            for (int iRow = 0; iRow < 3; iRow++) // Runs for the <Rows> in the GameBoard!
            {
                for (int iCol = 0; iCol < 3; iCol++) // Runs for the <Columns> in the GameBoard!
                {
                    if (this.PlayerShape == game.GameBoard[iRow, iCol]) // Checks if it owns a cell
                    {
                        isOwnRange = true;
                    }
                }

                // Now, if found a cell that computer owns, it fills the next empty cell...                
                if (isOwnRange)
                {
                    for (int i = 0; i < 3; i++) // Check empty cell to fill
                    {
                        if (game.GameBoard[iRow, i] == Shape.Empty)
                        {
                            game.GameBoard[iRow, i] = this.PlayerShape;
                            return isSabotagePlay = true;
                        }
                    }                    
                }
                
                // Continue to next row...
            }

            #endregion

            #endregion

            return isSabotagePlay; // False
        }
        
        #endregion
        
        #region Public API

        /// <summary>
        /// Play move, execution of computer turn! (according to the level algorithm)
        /// </summary>
        /// <param name="game">Where to assign the play move</param>
        public override void Play(Game game)
        {
            if (game.PlaysCounter == 0) // If a new game is started, reset the computer counter...
            {
                // We know, when there's 0 plays in the game, a new game started...
                // So we reset the computer counter as well before playing the new game!
                countPlays = 0; // Reset the counter!
            }

            countPlays++; // Count this play move!

            if (Level == 1)
            {
                if (!FindPotentialWinning(game)) // If not found a potential win
                {
                    PlayRandom(game); // Only when not found a potential win, play random somewhere!
                }                
            }
            else if (Level == 2)
            {
                if (!FindPotentialWinning(game)) // If not found a potential win...
                {
                    if (!BlockOtherPlayer(game)) // If can't block other player...
                    {
                        PlayRandom(game); // Play random somewhere, if above does not take action!
                    }
                }
            }
            else if (Level == 3)
            {
                if (!FindPotentialWinning(game)) // If not found a potential win...
                {
                    if (!BlockOtherPlayer(game)) // If can't block other player...
                    {
                        if (!SabotageOtherPlayer(game)) // If sabotage algorithm is not available...
                        {
                            PlayRandom(game); // Play random somewhere, if above does not take action! 
                        }
                    }
                }
            }
        }
        
        #endregion
        
    }
}
