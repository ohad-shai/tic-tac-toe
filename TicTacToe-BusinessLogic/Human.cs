using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_BusinessLogic
{
    /// <summary>
    /// Human that can play a game
    /// </summary>
    public sealed class Human : Player
    {

        #region Properties

        /// <summary>
        /// Responsible for every input that the user enters to the game!
        /// </summary>
        internal IUserInput UserInput { get; set; }

        #endregion
        
        #region C'tor

        public Human(string name, Shape playerShape, IUserInput userInput)
            : base(name, playerShape)
        {
            UserInput = userInput; // Reference to the implementations of the UserInput!
            base.name = GetHumanName();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get a valid human name from the 'UserInput' set!
        /// </summary>
        /// <returns>The name</returns>
        private string GetHumanName()
        {
            return UserInput.SetHumanName(playerShape, name);
        }
        
        #endregion

        #region Public API

        /// <summary>
        /// Play move, and ensures a valid move, then assigns it to the Game!
        /// </summary>
        /// <param name="game">Where to assign the play move</param>
        public override void Play(Game game)
        {
            int key;
            bool isKeyOk = false;
            
            do
            {
                key = UserInput.ReadKeyNumber();

                if (key == 1 && game.GameBoard[2, 0] == Shape.Empty) // If pressed 1 (and cell is 'Empty')
                {
                    game.GameBoard[2, 0] = this.PlayerShape; // Assign the (Shape) player who pressed, to the Game Board!
                    isKeyOk = true; // Found a valid key!
                }
                else if (key == 2 && game.GameBoard[2, 1] == Shape.Empty) // If pressed 2 (same as up)
                {
                    game.GameBoard[2, 1] = this.PlayerShape; // Same as up
                    isKeyOk = true; // Same as up
                }
                else if (key == 3 && game.GameBoard[2, 2] == Shape.Empty) // If pressed 3
                {
                    game.GameBoard[2, 2] = this.PlayerShape;
                    isKeyOk = true;
                }
                else if (key == 4 && game.GameBoard[1, 0] == Shape.Empty) // If pressed 4
                {
                    game.GameBoard[1, 0] = this.PlayerShape;
                    isKeyOk = true;
                }
                else if (key == 5 && game.GameBoard[1, 1] == Shape.Empty) // If pressed 5
                {
                    game.GameBoard[1, 1] = this.PlayerShape;
                    isKeyOk = true;
                }
                else if (key == 6 && game.GameBoard[1, 2] == Shape.Empty) // If pressed 6
                {
                    game.GameBoard[1, 2] = this.PlayerShape;
                    isKeyOk = true;
                }
                else if (key == 7 && game.GameBoard[0, 0] == Shape.Empty) // If pressed 7
                {
                    game.GameBoard[0, 0] = this.PlayerShape;
                    isKeyOk = true;
                }
                else if (key == 8 && game.GameBoard[0, 1] == Shape.Empty) // If pressed 8
                {
                    game.GameBoard[0, 1] = this.PlayerShape;
                    isKeyOk = true;
                }
                else if (key == 9 && game.GameBoard[0, 2] == Shape.Empty) // If pressed 9
                {
                    game.GameBoard[0, 2] = this.PlayerShape;
                    isKeyOk = true;
                }
                else if (key == 0) // If pressed Esc
                {
                    game.GameMode = GameMode.ExitMode;
                    return;
                }
                else // Error Beep when bad key pressed, or when tried to assign a key to used cell!
                {
                    game.Displayer.ClearLastChar(); // it's like \b
                    isKeyOk = false;
                    game.Displayer.BeepSound(300, 550); // Error sound!
                }
            } while (!isKeyOk);
        }

        #endregion
        
    }
}
