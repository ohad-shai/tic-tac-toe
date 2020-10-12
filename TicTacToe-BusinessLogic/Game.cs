using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_BusinessLogic
{
    /// <summary>
    /// This is the engine, the core.
    /// It holds what you need to run the game, what's the rules in the game, and instructions how to run the game. 
    /// </summary>
    public sealed class Game
    {

        #region Fields

        private Shape playerTurn; // Holds the turn of the player!
        private Shape[,] gameBoard; // This is the board of the game!
        private int[] gameWins; // Holds the winning history of the players!
        private static int playsCounter; // Counts every play move of all players in the game!
        private bool isFirstRun; // Gives info if it's first run of the game!

        #endregion
        
        #region Properties

        /// <summary>
        /// Responsible for everything that displayed in the game!
        /// </summary>
        public IDisplayer Displayer { get; set; }

        /// <summary>
        /// Responsible for every input that the user enters to the game!
        /// </summary>
        public IUserInput UserInput { get; set; }

        /// <summary>
        /// Holds the game mode of the game!
        /// </summary>
        public GameMode GameMode { get; set; }

        /// <summary>
        /// Holds the turn of the player!
        /// </summary>
        public Shape PlayerTurn
        {
            get { return playerTurn; }
            // Can not set this prop
        }

        /// <summary>
        /// This is the board of the game!
        /// </summary>
        public Shape[,] GameBoard
        {
            get { return gameBoard; }
            // Can not set this prop
        }

        /// <summary>
        /// Holds the winning history of the players!
        /// </summary>
        public int[] GameWins
        {
            get { return gameWins; }
            // Can not set this prop
        }

        /// <summary>
        /// Counts every play move of all players in the game!
        /// </summary>
        public int PlaysCounter
        {
            get { return playsCounter; }
            // Can not set this prop
        }

        #endregion
        
        #region C'tor

        public Game(IDisplayer displayer, IUserInput userInput)
        {
            isFirstRun = true; // Starts with informing the game that it's first run!
            gameBoard = new Shape[3, 3]; // Define the 'GameTable' property
            gameWins = new int[2]; // Define the 'GameWins' property
            playerTurn = Shape.X; // Starts with the first player
            playsCounter = 0; // Starts with 0 play counts in the game!            
            Displayer = displayer; // Reference to the implementations of the Displayer!
            UserInput = userInput; // Reference to the implementations of the UserInput!
        }

        #endregion

        #region Private Methods
        
        /// <summary>
        /// Preparations before running the game mode: "Player Vs. Player"
        /// </summary>
        private void PlayerVsPlayer()
        {
            Displayer.ClearWindow();

            Human human1 = new Human(string.Empty, Shape.X, UserInput);
            Human human2 = new Human(string.Empty, Shape.O, UserInput);

            RunGameMode(human1, human2); // Run the mode
        }

        /// <summary>
        /// Preparations before running the game mode: "Player Vs. Computer"
        /// </summary>
        private void PlayerVsComputer()
        {
            int level = 0; // Holds the level of the computer
            bool isCompFirst = true; // Holds who is the first player to play

            // ====== Computer Levels Window ======
            Displayer.DisplayComputerLevels(true);
            level = UserInput.SetComputerLevel(this);

            // ======  First to Play Window  ======
            Displayer.DisplayWhoIsFirst(true);
            isCompFirst = UserInput.IsComputerFirstToPlay(this);
            
            if (isCompFirst)
            {
                Computer computer = new Computer("Computer", Shape.X, level);
                Human human = new Human(string.Empty, Shape.O, UserInput);
                RunGameMode(computer, human); // Run the mode
            }
            else
            {
                Human human = new Human(string.Empty, Shape.X, UserInput);
                Computer computer = new Computer("Computer", Shape.O, level);
                RunGameMode(human, computer); // Run the mode
            }
        }
        
        /// <summary>
        /// Actual running of the (Game Mode)!
        /// </summary>
        /// <param name="player1">First player</param>
        /// <param name="player2">Second player</param>
        private void RunGameMode(Player player1, Player player2)
        {
            int key; // Holds the option the user pressed after game is completed
            Shape winnerPlayer = Shape.Empty; // Holds the winner shape of the game
            bool isFullClear = true; // Indicator if the user wants a full clear

            #region Music (PlayDesk)
            System.Media.SoundPlayer playDeskMusic = new System.Media.SoundPlayer(); // for the music!
            playDeskMusic.SoundLocation = "3.wav";
            playDeskMusic.PlayLooping();
            #endregion

            do
            {
                Displayer.DisplayGameDesk(player1, player2, this);

                if (PlayerTurn == Shape.X)
                {
                    player1.Play(this);
                }
                else if (PlayerTurn == Shape.O)
                {
                    player2.Play(this);
                }

                playsCounter++; // Every play it counts it
                ChangePlayerTurn(); // Change the turn after a play

                #region Related to winning

                // NOTE: ~~~ Performance improvement ~~~
                // If the game has no 5 play moves, it will never find a win! till we pass 5 plays!
                // Only after 5 play moves, we can check for a win!
                if (playsCounter >= 5)
                {
                    winnerPlayer = CheckForWin();
                    if (winnerPlayer == Shape.X) // Found X win?
                    {
                        gameWins[0]++; // Count this win!
                        Displayer.DisplayWinner(player1.Name, winnerPlayer, this);
                        break;
                    }
                    else if (winnerPlayer == Shape.O) // Found O win?
                    {
                        gameWins[1]++; // Count this win!
                        Displayer.DisplayWinner(player2.Name, winnerPlayer, this);
                        break;
                    } 
                }

                if (playsCounter == 9) // If Game Table is full, then no one wins :(
                {
                    playsCounter = 0; // Reset counter
                    Displayer.DisplayNoWinner();
                    break;
                } 

                #endregion

            } while (GameMode != GameMode.ExitMode); // If pressed Esc
            
            // If pressed Esc --> while playing the game, below won't take action!
            // It takes action only after a game is completed! (after displaying result of game)
            #region Options after game is completed:

            if (GameMode != GameMode.ExitMode)
            {
                key = UserInput.GameCompletedOptions();

                if (key == 1) // If pressed Enter
                {
                    Displayer.ClearWindow();
                    isFullClear = false; // Not a full clear, because user want to keep winning history!
                    ClearGame(isFullClear);

                    // Return to Game Desk
                    this.RunGameMode(player1, player2);
                }
                else if (key == 0) // If pressed Esc
                {
                    Displayer.ClearWindow();
                    
                    // Return to Main Menu (and clears the game with the code below the loop)
                }
            }

            #endregion

            // Below takes action when Esc pressed - while playing the game, or after game is completed and user pressed Esc!
            isFullClear = true; // Full clear! (clears winning history)
            ClearGame(isFullClear);
        }

        /// <summary>
        /// Changes the turn of the player!
        /// </summary>
        private void ChangePlayerTurn()
        {
            if (playerTurn == Shape.X)
            {
                playerTurn = Shape.O;
                Displayer.BeepSound(1100, 300); // Sound!
            }
            else
            {
                playerTurn = Shape.X;
                Displayer.BeepSound(1100, 300); // Sound!
            }
        }

        /// <summary>
        /// Checks for a win!
        /// </summary>
        /// <returns>Returns the winner</returns>
        private Shape CheckForWin()
        {
            //Check HORIZONTAL lines for winner  
            if (GameBoard[0, 0] == Shape.X && GameBoard[0, 1] == Shape.X && GameBoard[0, 2] == Shape.X)
            {
                return Shape.X; // X Wins
            }
            if (GameBoard[0, 0] == Shape.O && GameBoard[0, 1] == Shape.O && GameBoard[0, 2] == Shape.O)
            {
                return Shape.O; // O Wins
            }
            if (GameBoard[1, 0] == Shape.X && GameBoard[1, 1] == Shape.X && GameBoard[1, 2] == Shape.X)
            {
                return Shape.X; // X Wins
            }
            if (GameBoard[1, 0] == Shape.O && GameBoard[1, 1] == Shape.O && GameBoard[1, 2] == Shape.O)
            {
                return Shape.O; // O Wins
            }
            if (GameBoard[2, 0] == Shape.X && GameBoard[2, 1] == Shape.X && GameBoard[2, 2] == Shape.X)
            {
                return Shape.X; // X Wins
            }
            if (GameBoard[2, 0] == Shape.O && GameBoard[2, 1] == Shape.O && GameBoard[2, 2] == Shape.O)
            {
                return Shape.O; // O Wins
            }

            // Check VERTICAL lines for winner  
            if (GameBoard[0, 0] == Shape.X && GameBoard[1, 0] == Shape.X && GameBoard[2, 0] == Shape.X)
            {
                return Shape.X; // X Wins
            }
            if (GameBoard[0, 0] == Shape.O && GameBoard[1, 0] == Shape.O && GameBoard[2, 0] == Shape.O)
            {
                return Shape.O; // O Wins
            }
            if (GameBoard[0, 1] == Shape.X && GameBoard[1, 1] == Shape.X && GameBoard[2, 1] == Shape.X)
            {
                return Shape.X; // X Wins
            }
            if (GameBoard[0, 1] == Shape.O && GameBoard[1, 1] == Shape.O && GameBoard[2, 1] == Shape.O)
            {
                return Shape.O; // O Wins
            }
            if (GameBoard[0, 2] == Shape.X && GameBoard[1, 2] == Shape.X && GameBoard[2, 2] == Shape.X)
            {
                return Shape.X; // X Wins
            }
            if (GameBoard[0, 2] == Shape.O && GameBoard[1, 2] == Shape.O && GameBoard[2, 2] == Shape.O)
            {
                return Shape.O; // O Wins
            }
            
            //Check DIAGONAL lines for winner
            if (GameBoard[0, 0] == Shape.X && GameBoard[1, 1] == Shape.X && GameBoard[2, 2] == Shape.X)
            {
                return Shape.X; // X Wins
            }
            if (GameBoard[0, 0] == Shape.O && GameBoard[1, 1] == Shape.O && GameBoard[2, 2] == Shape.O)
            {
                return Shape.O; // O Wins
            }
            if (GameBoard[2, 0] == Shape.X && GameBoard[1, 1] == Shape.X && GameBoard[0, 2] == Shape.X)
            {
                return Shape.X; // X Wins
            }
            if (GameBoard[2, 0] == Shape.O && GameBoard[1, 1] == Shape.O && GameBoard[0, 2] == Shape.O)
            {
                return Shape.O; // O Wins
            }

            // No one wins
            return Shape.Empty;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Run the game, Main Menu window shows in the start, or after running a game!
        /// </summary>
        /// <param name="isFirstRun">Indicator if the game is running for the first time</param>
        public void Run()
        {            
            System.Media.SoundPlayer music = new System.Media.SoundPlayer(); // Creating an instance for the music!

            Displayer.WindowStyle();

            do
            { // While "Esc" is not pressed, the main menu will be showen after every game!
                Displayer.ClearWindow();                

                #region Related to first run options

                if (!isFirstRun)
                {
                    Displayer.Logo(); // Tic Tac Toe Logo
                }
                else
                {
                    Displayer.LogoAnimation(); // Logo with Animation only at first run!
                } 

                #endregion

                #region Menu Music
                music.SoundLocation = "1.wav";
                music.PlayLooping();
                #endregion

                Displayer.DisplayGameOptions(true); // Sends true for not showing error msg at the beginning
                UserInput.SetGameMode(this); // Sends the game to set it's mode!

                if (GameMode == GameMode.PlayerVsPlayer)
                {
                    #region Music (Typing Players)
                    music.SoundLocation = "2.wav";
                    music.PlayLooping();
                    #endregion
                    PlayerVsPlayer(); // Go to the chosen mode!
                }
                else if (GameMode == GameMode.PlayerVsComputer)
                {
                    #region Music (Typing Players)
                    music.SoundLocation = "2.wav";
                    music.PlayLooping();
                    #endregion
                    PlayerVsComputer(); // Go to the chosen mode!
                }

                isFirstRun = false; // If it's first run: now we completed the first run of the game!
            } while (GameMode != GameMode.ExitMode); // If pressed Esc
            Displayer.CloseGame();
        }

        /// <summary>
        /// Clears the Game! erase data!
        /// </summary>
        public void ClearGame(bool isFullClear)
        {
            // Clear the GameBoard array
            for (int iRow = 0; iRow < 3; iRow++) // Running the rows!
            {
                for (int iCol = 0; iCol < 3; iCol++) // Running the columns!
                {
                    gameBoard[iRow, iCol] = Shape.Empty; // Clears the board
                }
            }

            // Clear the turn of the Player
            playerTurn = Shape.X; // Always start with the first player

            playsCounter = 0; // Reset counter of the play turns

            if (isFullClear) // When user wants a full clear (means clear all winning history)
            {
                GameMode = GameMode.Waiting; // Reset the game mode for waiting...

                // Clear the wins of the players
                for (int i = 0; i < gameWins.Length; i++)
                {
                    gameWins[i] = 0; // Reset wins
                }
            }
        }
        
        #endregion
        
    }
}
