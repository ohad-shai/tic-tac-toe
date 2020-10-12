using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_BusinessLogic
{
    /// <summary>
    /// Delivers a good flow for inputs, with full protection, this will ensure a valid input!
    /// </summary>
    public interface IUserInput
    {
        
        /// <summary>
        /// Reads a numeric key pressed or Esc by the user and returns (int) type!
        /// </summary>
        /// <returns>The number preesed (int)</returns>
        int ReadKeyNumber();

        /// <summary>
        /// Sets the mode of the game!
        /// </summary>
        /// <param name="game">The game to assign the mode</param>
        void SetGameMode(Game game);

        /// <summary>
        /// Requests the user to select an option: (Enter) = to continue playing, (Esc) = exit to the main menu!
        /// </summary>
        /// <returns>The option the user chose, 1 = Enter, 2 = Esc, -1 = Error</returns>
        int GameCompletedOptions();

        /// <summary>
        /// Collects and ensures a valid name for the human player!
        /// </summary>
        /// <param name="playerShape">The number of the player</param>
        /// <param name="name">The name of the player</param>
        string SetHumanName(Shape playerShape, string name);

        /// <summary>
        /// Sets the level of the computer!
        /// </summary>
        /// <returns>The level of computer</returns>
        int SetComputerLevel(Game game);

        /// <summary>
        /// Requests the user to select who is the first player to play!
        /// </summary>
        /// <returns>True = computer plays first, False = Human plays first</returns>
        bool IsComputerFirstToPlay(Game game);
        
    }
}
