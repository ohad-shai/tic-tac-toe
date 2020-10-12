using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_BusinessLogic
{
    /// <summary>
    /// Everything that displayed in the game: colors, positions, styles... all visuals is here!
    /// </summary>
    public interface IDisplayer
    {

        /// <summary>
        /// Holds the style of the window, such as: color, size, position, etc...
        /// </summary>
        void WindowStyle();

        /// <summary>
        /// Clears everything displayed in the window!
        /// </summary>
        void ClearWindow();

        /// <summary>
        /// Making a beep sound!
        /// </summary>
        /// <param name="freq">The frequency for the beep</param>
        /// <param name="duration">The duration for the beep</param>
        void BeepSound(int frequency, int duration);

        /// <summary>
        /// Clears the last char in the line!
        /// </summary>
        void ClearLastChar();
        
        /// <summary>
        /// Displays the TicTacToe Logo with animation and sounds! (only at first run)
        /// </summary>
        void LogoAnimation();

        /// <summary>
        /// Displays the TicTacToe Logo!
        /// </summary>
        void Logo();

        /// <summary>
        /// Displays the game options in the Main Menu (in the center!)
        /// </summary>
        /// <param name="isKeyOk">Displays an error text if last key was bad!</param>
        void DisplayGameOptions(bool isKeyOk);

        /// <summary>
        /// Display of the playing desk!
        /// </summary>
        /// <param name="player1">Name of player 1</param>
        /// <param name="player2">Name of player 2</param>
        /// <param name="game">The game which holds all data</param>
        void DisplayGameDesk(Player player1, Player player2, Game game);

        /// <summary>
        /// Displays the winner!
        /// </summary>
        /// <param name="playerWinner">The name of the winner</param>
        /// <param name="winnerShape">The shape of the winner</param>
        /// <param name="game">The game which holds all data</param>
        void DisplayWinner(string playerWinner, Shape winnerShape, Game game);

        /// <summary>
        /// Displays no winner!
        /// </summary>
        void DisplayNoWinner();

        /// <summary>
        /// Displays the levels of the computer!
        /// </summary>
        /// <param name="isLastKeyOk">Displays an error text if last key was bad!</param>
        void DisplayComputerLevels(bool isLastKeyOk);

        /// <summary>
        /// Displays who is the first to play, Computer or Human?
        /// </summary>
        /// <param name="isLastKeyOk">Displays an error text if last key was bad!</param>
        void DisplayWhoIsFirst(bool isLastKeyOk);

        /// <summary>
        /// Closes the game! end of the program!
        /// </summary>
        void CloseGame();

    }
}
