using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_BusinessLogic;

namespace TicTacToe_Ohad_ConsoleApp
{
    /// <summary>
    /// Everything that displayed in the game: colors, positions, styles... all visuals is here!
    /// </summary>
    public class ConsoleDisplayer : IDisplayer
    {
        
        #region Private Methods

        /// <summary>
        /// Calculates the space needed to make things in the center!
        /// </summary>
        /// <param name="spaceAlgo">Info algorithm provided</param>
        /// <returns>The space to make the thing in center</returns>
        private static string CalSpace(int spaceAlgo)
        {
            StringBuilder space = new StringBuilder();

            // Count every space according to the information provided by the field algorithm!
            for (int i = 0; i < spaceAlgo; i++)
            {
                space.Append(" "); // With spaces we can make text look in the center in console!
            }

            return space.ToString(); // Result of spaces needed to make the thing in center!
        }

        /// <summary>
        /// Display of the GameBoard array!
        /// </summary>
        /// <param name="game">From where to grab the data</param>
        private static void DisplayGameBoard(Game game)
        {
            for (int iRow = 0; iRow < 3; iRow++) // Running the rows in the array
            {
                Console.WriteLine("\t\t\t\t\t-------------------"); // Makes the table in the center
                Console.Write("\t\t\t\t\t"); // Makes the table in the center

                for (int iCol = 0; iCol < 3; iCol++) // Running the columns in the array
                {
                    if (game.GameBoard[iRow, iCol] == Shape.Empty) // If the cell 'Empty'
                    {
                        Console.Write("|     "); // Displays nothing
                    }
                    else if (game.GameBoard[iRow, iCol] == Shape.X) // If the cell chosen by player 1 (X)
                    {
                        Console.Write("|  ");
                        Console.ForegroundColor = ConsoleColor.Green; // Color of player 1
                        Console.Write("X"); // Displays (X)
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  ");
                    }
                    else if (game.GameBoard[iRow, iCol] == Shape.O) // If the cell chosen by player 2 (O)
                    {
                        Console.Write("|  ");
                        Console.ForegroundColor = ConsoleColor.Yellow; // Color of player 2
                        Console.Write("O"); // Displays (O)
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  ");
                    }
                }
                Console.Write("|\n"); // New line after row is finished!
            }
            Console.WriteLine("\t\t\t\t\t-------------------"); // Makes the table in the center
        }

        #endregion
        
        #region Public API

        /// <summary>
        /// Sets the style of the window, such as: color, size, position, etc...
        /// </summary>
        public void WindowStyle()
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkRed; // Default background color of the project
            Console.ForegroundColor = ConsoleColor.White; // Default text color of the project
            Console.Clear();
            Console.Title = "Ohad's \"Tic Tac Toe\" Project - John Bryce"; // Name of project
            Console.SetWindowSize(100, 50); // Defines the size of the console window
            Console.BufferHeight = 500;
            Console.BufferWidth = 100;
            Console.CursorSize = 100;
        }

        /// <summary>
        /// Clears everything displayed in the window!
        /// </summary>
        public void ClearWindow()
        {
            Console.Clear();
            Console.CursorVisible = true;
        }

        /// <summary>
        /// Making a beep sound!
        /// </summary>
        /// <param name="freq">The frequency for the beep</param>
        /// <param name="duration">The duration for the beep</param>
        public void BeepSound(int frequency, int duration)
        {
            Console.Beep(frequency, duration); // Sound!
        }

        /// <summary>
        /// Clears the last char in the line!
        /// </summary>
        public void ClearLastChar()
        {
            Console.Write("\b");
        }

        /// <summary>
        /// Displays the TicTacToe Logo with animation and sounds! (only at first run)
        /// </summary>
        public void LogoAnimation()
        {
            // Sound after every print of line, makes the logo look like an animation!
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.Write("====================================================================================================");
            Console.Beep(50, 100); // Sound!
            Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
            Console.Beep(100, 100); // Sound!
            Console.Write("@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B");
            Console.Beep(150, 100); // Sound!
            Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
            Console.Beep(200, 100); // Sound!
            Console.Write("@B         B  @B@B@B@B@B@B@BG        B@B@B@B@B@B@B@B@B@B@B@S        @B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B");
            Console.Beep(250, 100); // Sound!
            Console.Write("B@B@B  rB@B@M9B@B@Mrs@B@B@B@B@B@  B@B@B@9rs@B@B@BMrsB@B@B@B@B@B  @B@B@B@srM@B@B@B2r@B@B@B@B@B@B@B@B@");
            Console.Beep(300, 100); // Sound!
            Console.Write("@B@B@  H@B@B  @B9      B@B@B@B@B  @B@B@  2   B@5  ,   @B@B@B@B@  B@B@B   ,  rB@   s  B@B@B@B@B@B@B@B");
            Console.Beep(400, 50); // Sound!
            Console.Write("B@B@B  2B@B@  B@  B@B@B@B@B@B@B@  B@B@B@GH   @B  @B@B@B@B@B@B@B  @B@B  @B@B  @B  @B2  B@B@B@B@B@B@B@");
            Console.Beep(500, 50); // Sound!
            Console.Write("@B@B@  s@B@B  @B  @B@B@B@B@B@B@B  @B@B   B@  B@  B@B@B@B@B@B@B@  B@B@  B@B@  BB  B@Gss@B@B@B@B@B@B@B");
            Console.Beep(600, 50); // Sound!
            Console.Write("B@B@B  iB@B@  B@S  ,   @B@B@B@B@  B@B@   S   @B2  ,   B@B@B@B@B  @B@B@   :  ;@B   2  BB@B@B@B@B@B@B@");
            Console.Beep(700, 50); // Sound!
            Console.Write("@B@B@BMB@B@B@G@B@BMisB@B@B@B@B@BMM@B@B@Bss@BMB@B@Gir@B@B@B@B@B@GBB@B@B@BsiGB@B@B@srX@B@B@B@B@B@B@B@B");
            Console.Beep(800, 50); // Sound!
            Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
            Console.Beep(900, 50); // Sound!
            Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
            Console.Beep(1000, 50); // Sound!
            Console.Write("@B@B@B@B@B@B@B@B@B X@B@B@B@B@B@B@B@Br     rB@  B@B@B@B@B@B@B@B@B  @B@B@      B@  B@B@B@B@B@B@B r@B@B");
            Console.Beep(1200, 50); // Sound!
            Console.Write("B@B@B@B@B@B@B@B@B@  ,  @B s@B  @B@Bi 5B@B9 iB  s  S@Bi   2B@9  s  B@B@B  @B@2@B  s  s@Br   sB@ SB@B@");
            Console.Beep(1400, 50); // Sound!
            Console.Write("@B@B@B@B@B@B@B@B@B  @B  @  B@ 2B@B@  B@B@B  @  B@  B@s9B  @B r@B  @B@B@Br    B@  B@  B@HXB  @B  @B@B");
            Console.Beep(1600, 50); // Sound!
            Console.Write("B@B@B@B@B@B@B@B@B@ sB@  B@    B@B@Bi sB@BS :B  @B  @B  @  BS @B@  B@B@B B@B@  B  @B2 @B  @  B@  B@B@");
            Console.Beep(1800, 50); // Sound!
            Console.Write("@B@B@B@B@B@B@B@B@B  :  2@B@  B@B@B@Br     rB@  B@  B@  5  @B      @B@B@      B@  B@r B@  2  @B  @B@B");
            Console.Beep(2000, 50); // Sound!
            Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@9  @B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
            Console.Beep(2200, 50); // Sound!
            Console.Write("@B@B@B@B@B@B@B@B@B@B@B@B@i G@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B");
            Console.Beep(2400, 50); // Sound!
            Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
            Console.Beep(2500, 100); // Sound!
            Console.Write("====================================================================================================");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Displays the TicTacToe Logo!
        /// </summary>
        public void Logo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.Write("====================================================================================================");
            Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
            Console.Write("@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B");
            Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
            Console.Write("@B         B  @B@B@B@B@B@B@BG        B@B@B@B@B@B@B@B@B@B@B@S        @B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B");
            Console.Write("B@B@B  rB@B@M9B@B@Mrs@B@B@B@B@B@  B@B@B@9rs@B@B@BMrsB@B@B@B@B@B  @B@B@B@srM@B@B@B2r@B@B@B@B@B@B@B@B@");
            Console.Write("@B@B@  H@B@B  @B9      B@B@B@B@B  @B@B@  2   B@5  ,   @B@B@B@B@  B@B@B   ,  rB@   s  B@B@B@B@B@B@B@B");
            Console.Write("B@B@B  2B@B@  B@  B@B@B@B@B@B@B@  B@B@B@GH   @B  @B@B@B@B@B@B@B  @B@B  @B@B  @B  @B2  B@B@B@B@B@B@B@");
            Console.Write("@B@B@  s@B@B  @B  @B@B@B@B@B@B@B  @B@B   B@  B@  B@B@B@B@B@B@B@  B@B@  B@B@  BB  B@Gss@B@B@B@B@B@B@B");
            Console.Write("B@B@B  iB@B@  B@S  ,   @B@B@B@B@  B@B@   S   @B2  ,   B@B@B@B@B  @B@B@   :  ;@B   2  BB@B@B@B@B@B@B@");
            Console.Write("@B@B@BMB@B@B@G@B@BMisB@B@B@B@B@BMM@B@B@Bss@BMB@B@Gir@B@B@B@B@B@GBB@B@B@BsiGB@B@B@srX@B@B@B@B@B@B@B@B");
            Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
            Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
            Console.Write("@B@B@B@B@B@B@B@B@B X@B@B@B@B@B@B@B@Br     rB@  B@B@B@B@B@B@B@B@B  @B@B@      B@  B@B@B@B@B@B@B r@B@B");
            Console.Write("B@B@B@B@B@B@B@B@B@  ,  @B s@B  @B@Bi 5B@B9 iB  s  S@Bi   2B@9  s  B@B@B  @B@2@B  s  s@Br   sB@ SB@B@");
            Console.Write("@B@B@B@B@B@B@B@B@B  @B  @  B@ 2B@B@  B@B@B  @  B@  B@s9B  @B r@B  @B@B@Br    B@  B@  B@HXB  @B  @B@B");
            Console.Write("B@B@B@B@B@B@B@B@B@ sB@  B@    B@B@Bi sB@BS :B  @B  @B  @  BS @B@  B@B@B B@B@  B  @B2 @B  @  B@  B@B@");
            Console.Write("@B@B@B@B@B@B@B@B@B  :  2@B@  B@B@B@Br     rB@  B@  B@  5  @B      @B@B@      B@  B@r B@  2  @B  @B@B");
            Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@9  @B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
            Console.Write("@B@B@B@B@B@B@B@B@B@B@B@B@i G@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B");
            Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
            Console.Write("====================================================================================================");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Displays the game options in the Main Menu (in the center!)
        /// </summary>
        /// <param name="isLastKeyOk">Displays an error text if last key was bad!</param>
        public void DisplayGameOptions(bool isKeyOk)
        {
            string msg;
            msg = "-----------------------";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg); // center text
            msg = "|    Game options:    |";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg); // center text
            msg = "-----------------------\n";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg); // center text
            msg = "-------------                              ";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg); // center text
            msg = "|  Press 1  | --->  Player Vs. Player  <---";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg); // center text
            msg = "-------------                              ";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg); // center text
            msg = "|  Press 2  | ---> Player vs. Computer <---";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg); // center text
            msg = "-------------                              ";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg); // center text
            msg = "| Press Esc | --->       Exit       <---   ";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg); // center text
            msg = "-------------                              ";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg); // center text
            Console.WriteLine("\n\n\n\n\n");
            msg = "Press a key!";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg); // center text
            Console.WriteLine();

            if (!isKeyOk) // If last key was bad, it displays it!
            {
                Console.Beep(350, 100); // Error sound!
                Console.Beep(250, 100); // Error sound!
                Console.Beep(150, 100); // Error sound!
                Console.ForegroundColor = ConsoleColor.Red;
                msg = "*** Enter a valid option! ***";
                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + msg.Length / 2) + "}", msg); // center text
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Write("{0," + (Console.WindowWidth / 2) + "}", ""); // Center the key cursor
        }

        /// <summary>
        /// Display of the playing desk!
        /// </summary>
        /// <param name="player1">Name of player 1</param>
        /// <param name="player2">Name of player 2</param>
        /// <param name="game">The game which holds all data</param>
        public void DisplayGameDesk(Player player1, Player player2, Game game)
        {
            Console.Clear();
            Console.CursorVisible = false; // Hide the cursor
            string msg, turnName = "";

            #region Calculate spaces needed to make things in center
            // Window width is 98, half is 49
            // 22 - is the length of the format(<<< (...) >>>)
            int nameLengthL = (49 - (22 + player1.Name.Length)) / 2;
            int nameLengthR = (49 - (22 + player2.Name.Length)) / 2;
            int winLengthL = (49 - (11 + 1 + player1.Name.Length)) / 2;
            int winLengthR = (49 - (11 + 1 + player2.Name.Length)) / 2;

            #endregion

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("===================================================================================================");
            #region Player Names Line!

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0}<<< Player 1 (X): ", CalSpace(nameLengthL));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0}", player1.Name);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(" >>>{0}", CalSpace(nameLengthL));
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0}<<< Player 2 (O): ", CalSpace(nameLengthR));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", player2.Name);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(" >>>{0}", CalSpace(nameLengthR));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Black;

            #endregion
            Console.WriteLine("===================================================================================================");
            #region Player Turn Line!

            Console.ForegroundColor = ConsoleColor.White;
            if (game.PlayerTurn == Shape.X) // Check the turn of the player
            {
                turnName = player1.Name;
            }
            else if (game.PlayerTurn == Shape.O)
            {
                turnName = player2.Name;
            }
            msg = "Player's turn: ";
            Console.Write("{0," + ((Console.WindowWidth / 2) + (msg.Length - turnName.Length) / 2) + "}", msg); // Center text

            if (game.PlayerTurn == Shape.X) // Responsible for different color in the players
            {
                Console.ForegroundColor = ConsoleColor.Green; // For player 1
            }
            else if (game.PlayerTurn == Shape.O)
            {
                Console.ForegroundColor = ConsoleColor.Yellow; // For player 2
            }

            Console.WriteLine("{0}", turnName); // center text
            Console.ForegroundColor = ConsoleColor.Black;

            #endregion
            Console.WriteLine("===================================================================================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            DisplayGameBoard(game); // Dispaly of the GameBoard

            Console.WriteLine("\n\n\n");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n===================================================================================================");
            #region Wins Line!

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0}(X) ", CalSpace(winLengthL));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0}", player1.Name);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(" wins: {0}{1}", game.GameWins[0], CalSpace(winLengthL));
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("|");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0}(O) ", CalSpace(winLengthR));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", player2.Name);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(" wins: {0}{1}", game.GameWins[1], CalSpace(winLengthR));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Black;

            #endregion
            Console.WriteLine("===================================================================================================");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\n\t\t\t\t  Press <1-9> - to play the game!");
            Console.WriteLine("\n\t\t\t  Press <Esc> - to return the Main Menu any time!");

            Console.Beep(650, 100); // Sound!

            #region Displays Cursor Location!

            Console.SetCursorPosition(49, 15);
            Console.WriteLine("^");
            Console.SetCursorPosition(49, 16);

            #endregion
        }

        /// <summary>
        /// Displays the winner!
        /// </summary>
        /// <param name="playerWinner">The name of the winner</param>
        /// <param name="winnerShape">The shape of the winner</param>
        /// <param name="game">The game which holds all data</param>
        public void DisplayWinner(string playerWinner, Shape winnerShape, Game game)
        {
            Console.Clear();
            #region Music (Display Winner)
            System.Media.SoundPlayer winnerMusic = new System.Media.SoundPlayer(); // for the music!
            winnerMusic.SoundLocation = "4.wav";
            winnerMusic.PlayLooping();
            #endregion

            string[] colors = new string[] { "Green", "Cyan", "Yellow", "Blue", "Red" }; // Colors I like :)

            for (int iAll = 0; iAll < 3; iAll++) // Return the Color Madness 3 times!
            {
                for (int iOne = 0; iOne < colors.Length; iOne++) // Color Madness!!!
                {
                    // Changes the background color from the Enum 'ConsoleColor'!
                    Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colors[iOne]);
                    Console.Clear();

                    #region WINNER LOGO
                    Console.Write("B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@BBB@BBB@BBB@BBBBB@B@B@B@B@B@B@BBB@BBB@B@BBB@B@B@BBB@B@B@BBB@BBB@B@");
                    Console.Write("BB@B@B@B@B@B@@@B@B@@@B@B@B@B@B@B@B@B@B@B@@@B@B@B@B@B@B@B@@@B@B@B@B@B@@@B@B@B@B@B@B@@@@@B@B@B@B@B@@@B");
                    Console.Write("B@@@B@B@B@B@B@B@@@B@B@@@B@B@B@B@B@B@B@B@B@B@@@B@B@B@B@B@B@B@@@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@@@@@@@B@");
                    Console.Write("@B@B@B@B@B@B@B@B@B@B@@@B@B@B@B@B@B@B@B@B@B@B@@@B@B@B@@@@@B@B@B@B@B@B@B@B@@@B@B@B@B@B@B@B@B@B@B@B@B@B");
                    Console.Write("B@B@r   B@B@BM   YB@B@BU  .@B   5@B@.   v@@@B@r  5B@@.   L@@B@B7  u@B@         iB@1       ,1B@B@B@B@");
                    Console.Write("@@@BE   OB@B@,    @@@B@   J@@   YB@B     r@B@B:  v@B@     7B@B@:  vB@B         r@Bi          M@B@B@B");
                    Console.Write("B@@@B   :@B@B     q@B@M   B@@   U@B@      2@B@i  uB@@      UB@Br  J@@@   @B@@@B@B@7  .B@B@    B@B@B@");
                    Console.Write("@B@B@q   B@@2  :  .@@Bi  v@B@   1B@B  ,@   0@Br  u@B@  .@   0@@r  UB@B   B@B@B@@@Bv  .@B@B.  .@B@B@B");
                    Console.Write("B@B@B@   SB@   @   @B@   @B@@   2@B@   @5   B@r  2B@B   BS   @@7  u@B@        .@@@7   Lvr    @B@B@B@");
                    Console.Write("@B@B@@Y   @B  rB7  r@N  :B@@@   5B@@   @@i   B1  u@B@   @Br   @1  U@@@    .   iB@Bv        N@B@B@B@B");
                    Console.Write("B@B@B@@   BY  B@B   B:  B@B@B   2@B@   @B@,  :u  2B@B   B@B,  ,1  j@B@   @B@B@B@B@7   B@Y   G@B@B@B@");
                    Console.Write("@B@B@B@:  L   @B@   U   @B@@@   1B@B   @@B@      u@B@   @B@B      uB@B   B@B@B@B@Bv   @B@v   @@B@B@@");
                    Console.Write("B@B@B@B@     1B@BN     ZB@@@@   J@B@   @B@@@     LB@B   B@B@B     7@B@   ,i:::.uB@;   B@B@    @@@@B@");
                    Console.Write("@B@B@@@B.    B@B@B     B@B@@@   uB@B   B@B@@@    S@B@   @@@B@B    SB@B          @Br   @B@@@   7B@B@B");
                    Console.Write("B@B@B@B@B@@@B@B@B@B@B@B@B@B@B@B@@@B@B@B@B@B@@@B@B@B@B@B@@@@@B@B@@@B@@@B@@@@@B@B@B@B@B@B@B@B@B@B@B@B@");
                    Console.Write("@@@B@B@B@B@B@B@@@B@B@@@B@B@B@B@B@B@B@@@B@B@B@B@B@B@B@B@B@B@@@B@B@B@B@@@B@B@B@@@B@@@B@B@@@@@B@B@B@B@B");
                    Console.Write("B@B@B@B@B@B@B@B@@@B@@@@@B@B@B@B@B@@@B@B@@@B@B@B@@@@@@@B@B@B@B@B@@@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@");
                    Console.Write("BB@B@@@B@@@B@@@B@@@B@B@B@B@@@@@B@B@B@B@B@@@@@B@B@B@B@@@B@B@B@B@B@B@B@B@@@B@@@B@B@B@B@B@B@B@B@B@B@B@B");
                    #endregion
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.WriteLine("\n\n\n");

                    int winnerLength = (100 - (24 + playerWinner.Length)) / 2; // Calculate spaces needed to make it center

                    Console.Write("{0}", CalSpace(100)); // Black line
                    Console.Write("{0}!!! The Winner is : ", CalSpace(winnerLength));

                    if (winnerShape == Shape.X) // X color is green
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (winnerShape == Shape.O) // O color is yellow
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write("{0}", playerWinner);
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(" !!!{0}", CalSpace(winnerLength));
                    Console.Write("{0}", CalSpace(100)); // Black line
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n"); // Make space for GameTable Display later...

                    Console.Write("{0}", CalSpace(100)); // Black line
                    Console.Write("{0}Press <Enter> - to play another round! (Keeps winning history){0}", CalSpace(19));
                    Console.Write("{0}", CalSpace(100)); // Black line

                    Console.WriteLine("\n\n");

                    Console.Write("{0}", CalSpace(100)); // Black line
                    Console.Write("{0} Press <Esc> - to return the Main Menu! (Clears winning history){0}", CalSpace(18));
                    Console.Write("{0}\n", CalSpace(100)); // Black line

                    Console.Beep((iOne * 250) + 800, 100); // Sounds!
                }
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 27); // Go to the center of the window
            DisplayGameBoard(game); // Dispaly of the Game Table

            Console.BackgroundColor = ConsoleColor.DarkRed; // Return to default background color
        }

        /// <summary>
        /// Displays no winner!
        /// </summary>
        public void DisplayNoWinner()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("\n\n\n");

            Console.WriteLine("{0}", CalSpace(100)); // Black line
            Console.Write("{0}", CalSpace(100)); // Black line
            Console.Write("{0}--- NO ONE WINS! ---{0}", CalSpace(40)); // Center text
            Console.Write("{0}\n", CalSpace(100)); // Black line
            Console.WriteLine("{0}", CalSpace(100)); // Black line

            Console.WriteLine("\n\n\n");

            Console.Write("{0}", CalSpace(100)); // Black line
            Console.Write("{0}Press <Enter> - to play another round! (Keeps winning history){0}", CalSpace(19));
            Console.Write("{0}", CalSpace(100)); // Black line

            Console.WriteLine("\n\n");

            Console.Write("{0}", CalSpace(100)); // Black line
            Console.Write("{0} Press <Esc> - to return the Main Menu! (Clears winning history){0}", CalSpace(18));
            Console.Write("{0}\n", CalSpace(100)); // Black line

            for (int i = 10; i > 0; i--) // Sounds!
            {
                Console.Beep((i * 250) + 800, 100); // Sounds!
            }

            Console.BackgroundColor = ConsoleColor.DarkRed; // Return to default background color
        }

        /// <summary>
        /// Displays the levels of the computer!
        /// </summary>
        /// <param name="isLastKeyOk">Displays an error text if last key was bad!</param>
        public void DisplayComputerLevels(bool isLastKeyOk)
        {
            Console.Clear();

            Console.WriteLine("\n\n");

            Console.WriteLine("{0} ------------------------------------------{0}", CalSpace(28));
            Console.WriteLine("{0} |    Enter the level of the Computer:    |{0}", CalSpace(28));
            Console.WriteLine("{0} ------------------------------------------{0}", CalSpace(28));
            Console.WriteLine("\n\n");

            Console.WriteLine("{0}-------------                                              {0}", CalSpace(20));

            Console.Write("{0}|  Press 1  | ", CalSpace(20));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--->         EASY - You can win          <---{0}", CalSpace(20));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("{0}-------------                                              {0}", CalSpace(20));

            Console.Write("{0}|  Press 2  | ", CalSpace(20));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--->  MEDIUM - Computer will try to win  <---{0}", CalSpace(20));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("{0}-------------                                              {0}", CalSpace(20));

            Console.Write("{0}|  Press 3  | ", CalSpace(20));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--->      HARD - You have no chance      <---{0}", CalSpace(20));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("{0}-------------                                              {0}", CalSpace(20));

            Console.WriteLine("\n\n\n\n\n");

            Console.WriteLine("{0}Press a key!{0}", CalSpace(44));

            if (!isLastKeyOk) // If last key was not ok, it displays it!
            {
                Console.Beep(350, 100); // Error sound!
                Console.Beep(250, 100); // Error sound!
                Console.Beep(150, 100); // Error sound!
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}*** Enter a valid option! ***{0}\n\n", CalSpace(35));
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Displays who is the first to play, Computer or Human?
        /// </summary>
        /// <param name="isLastKeyOk">Displays an error text if last key was bad!</param>
        public void DisplayWhoIsFirst(bool isLastKeyOk)
        {
            Console.Clear();

            Console.WriteLine("\n\n");

            Console.WriteLine("{0} ------------------------------------------{0}", CalSpace(28));
            Console.WriteLine("{0} |       Who is the first to play ?       |{0}", CalSpace(28));
            Console.WriteLine("{0} ------------------------------------------{0}", CalSpace(28));
            Console.WriteLine("\n\n");

            Console.WriteLine("{0}-------------                                   {0}", CalSpace(25));
            Console.WriteLine("{0}|  Press 1  | --->    Computer is first!    <---{0}", CalSpace(25));
            Console.WriteLine("{0}-------------                                   {0}", CalSpace(25));
            Console.WriteLine("{0}|  Press 2  | --->      You are first!      <---{0}", CalSpace(25));
            Console.WriteLine("{0}-------------                                   {0}", CalSpace(25));

            Console.WriteLine("\n\n\n\n");

            Console.WriteLine("{0}Press a key!{0}", CalSpace(44));

            if (!isLastKeyOk) // If last key was not ok, it displays it!
            {
                Console.Beep(350, 100); // Error sound!
                Console.Beep(250, 100); // Error sound!
                Console.Beep(150, 100); // Error sound!
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}*** Enter a valid option! ***{0}\n\n", CalSpace(35));
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Closes the game! end of the program!
        /// </summary>
        public void CloseGame()
        {
            #region GoodBye Voice
            System.Media.SoundPlayer goodbyeVoice = new System.Media.SoundPlayer();
            goodbyeVoice.SoundLocation = "goodbye.wav";
            goodbyeVoice.Play();
            #endregion

            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@@B@B@B@B@B@B");
            Console.WriteLine("@B@B@B@B@BB@B       B@Bv      B@B@      ,@B        @B@       rB    @B   L      :B    @B@B@B@B@B@B@B");
            Console.WriteLine("@B@B@B@B@B@B    5    Br   :,   B@    u    @    .    @B    :   iB   B    @      :@    B@@B@B@B@B@B@B");
            Console.WriteLine("@B@B@B@B@BB@    B    @    B@   .B   i@    B    @u   r@   vB    @   1   @B    @B@B    @B@B@B@B@B@B@B");
            Console.WriteLine("@B@B@B@B@B@B    @B@B@B    @B   ,@   :B    @    BL   vB    1   LBL      B@    YrB@    B@@B@B@B@B@B@B");
            Console.WriteLine("@B@B@B@B@BB@    J    @    B@   :B   ,@    B    @7   v@        B@B     B@B      :B    @B@B@B@B@B@B@B");
            Console.WriteLine("@B@B@B@B@B@B    @    B.   @B   ,@   :B    @    BL   LB   :@    B@7   .@B@    B@B@    B@@B@B@B@B@B@B");
            Console.WriteLine("@B@B@B@B@BB@    Bi   @    B@   :B   :@    B    @u   r@   rB    @B@   7B@B    @B@B@B@B@B@B@B@B@B@B@B");
            Console.WriteLine("@B@B@B@B@B@B    @    B7   r:   r@    B    @    i    @B    r    B@B   :@B@       @    B@@B@B@B@B@B@B");
            Console.WriteLine("@B@B@B@B@BB@B        @B:      :@B@       @B         B@        :@B@   :B@B       B    @B@B@B@B@B@B@B");
            Console.WriteLine("@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@@B@B@B@B@B@B");
            Console.WriteLine("@B@B@B@B@BB@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B@B\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t     /////////////////////////////////////");
            Console.WriteLine("\n\t\t\t     * All rights reserved to Ohad Shai *\n");
            Console.WriteLine("\t\t\t     \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\n\n\n\n\n\n\t\t\t\t   Press any key to close... ");
            Console.ReadKey();
            Console.WriteLine();
        }

        #endregion
        
    }
}
