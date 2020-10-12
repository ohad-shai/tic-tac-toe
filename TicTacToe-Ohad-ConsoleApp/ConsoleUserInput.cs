using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_BusinessLogic;

namespace TicTacToe_Ohad_ConsoleApp
{
    /// <summary>
    /// Delivers a good flow for inputs, with full protection, this will ensure a valid input!
    /// </summary>
    public class ConsoleUserInput : IUserInput
    {
        
        #region Fields

        /// <summary>
        /// Where to assign the key input from the user
        /// </summary>
        private static ConsoleKeyInfo key;
        /// <summary>
        /// Input validation indicator!
        /// </summary>
        private static bool isOk;

        #endregion

        #region Public API

        /// <summary>
        /// Reads a numeric key pressed or Esc by the user and returns (int) type!
        /// </summary>
        /// <returns>The number preesed (int)</returns>
        public int ReadKeyNumber()
        {
            ConsoleKeyInfo key;

            key = Console.ReadKey();

            if ((int)key.KeyChar == 49) // If pressed 1
            {
                return 1;
            }
            else if ((int)key.KeyChar == 50) // If pressed 2
            {
                return 2;
            }
            else if ((int)key.KeyChar == 51) // If pressed 3
            {
                return 3;
            }
            else if ((int)key.KeyChar == 52) // If pressed 4
            {
                return 4;
            }
            else if ((int)key.KeyChar == 53) // If pressed 5
            {
                return 5;
            }
            else if ((int)key.KeyChar == 54) // If pressed 6
            {
                return 6;
            }
            else if ((int)key.KeyChar == 55) // If pressed 7
            {
                return 7;
            }
            else if ((int)key.KeyChar == 56) // If pressed 8
            {
                return 8;
            }
            else if ((int)key.KeyChar == 57) // If pressed 9
            {
                return 9;
            }
            else if ((int)key.KeyChar == 27) // If pressed Esc
            {
                return 0;
            }
            
            return -1;
        }

        /// <summary>
        /// Sets the mode of the game!
        /// </summary>
        /// <param name="game">The game to assign the mode</param>
        public void SetGameMode(Game game)
        {
            do
            {
                isOk = false;
                key = Console.ReadKey();

                if ((int)key.KeyChar == 49) // If pressed 1
                {
                    game.GameMode = GameMode.PlayerVsPlayer;
                    isOk = true;
                }
                else if ((int)key.KeyChar == 50) // If pressed 2
                {
                    game.GameMode = GameMode.PlayerVsComputer;
                    isOk = true;
                }
                else if ((int)key.KeyChar == 27) // If pressed Esc
                {
                    game.GameMode = GameMode.ExitMode;
                    isOk = true;
                }
                else // If pressed a bad key
                {
                    Console.Clear();
                    game.Displayer.Logo();
                    game.Displayer.DisplayGameOptions(isOk); // Sends the bad key to display error msg!
                }
            } while (!isOk);
        }

        /// <summary>
        /// Requests the user to select an option: (Enter) = to continue playing, (Esc) = exit to the main menu!
        /// </summary>
        /// <returns>The option the user chose, 1 = Enter, 2 = Esc, -1 = Error</returns>
        public int GameCompletedOptions()
        {
            do
            {
                isOk = false;

                Console.ForegroundColor = ConsoleColor.Red; // Hide typed input
                Console.BackgroundColor = ConsoleColor.Red; // Hide typed input

                key = Console.ReadKey();

                Console.ForegroundColor = ConsoleColor.White; // Makes typed input visible
                Console.BackgroundColor = ConsoleColor.DarkRed; // Makes typed input visible

                if ((int)key.KeyChar == 13) // If pressed Enter
                {
                    isOk = true;
                    return 1;
                }
                else if ((int)key.KeyChar == 27) // If pressed Esc
                {
                    isOk = true;
                    return 0;
                }
                else // If bad key pressed
                {
                    Console.Beep(300, 550); // Error sound!
                    // "isOk" stays 'false'
                }
            } while (!isOk);

            return -1;
        }

        /// <summary>
        /// Collects and ensures a valid name for the human player!
        /// </summary>
        /// <param name="playerShape">The number of the player</param>
        /// <param name="name">The name of the player</param>
        public string SetHumanName(Shape playerShape, string name)
        {
            do
            {
                isOk = false;
                Console.Beep(500, 100); // Sound!
                Console.Write("Enter the name of Player {0} ({1}): ", (int)playerShape, playerShape);
                name = Console.ReadLine();

                // ======================= 1st Check =======================
                if (name.Length < 16 && name.Length > 0)
                {
                    isOk = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*** Name can contain 1 to 15 characters! ***");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Beep(350, 500); // Error sound!
                }

                // ======================= 2nd Check =======================
                if (name == "Computer" || name == "computer")
                {
                    isOk = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*** Can not be a computer! ***");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Beep(350, 500); // Error sound!
                }

                if (isOk) // If isOk so far, let's explore the spaces and tabs in the name!
                {
                    int fndSpaces = 0;
                    for (int i = 0; i < name.Length; i++) // Pass every char in the name
                    {
                        if (name[i] == ' ')
                        {
                            fndSpaces++; // Spaces counter!
                        }

                        // ======================= 3rd Check =======================
                        if (name[i] == '\t') // Looking for a tab in the name!
                        {
                            isOk = false;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("*** Name can not contain a tab! ***");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Beep(350, 500); // Error sound!
                            break;
                        }
                    }

                    // ======================= 4th Check =======================
                    if (fndSpaces > 1) // If too much spaces found, is not Ok!
                    {
                        isOk = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("*** Can not contain too much spaces! ***");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Beep(350, 500); // Error sound!
                    }

                    // ======================= 5th Check =======================
                    if (name[0] == ' ' || name[name.Length - 1] == ' ') // If first/last char is a space, is not Ok!
                    {
                        isOk = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("*** First / Last character can not contain a space! ***");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Beep(350, 500); // Error sound!
                    }
                }
            } while (!isOk);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ok!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===================================================================================================");
            Console.Beep(600, 500); // Sound!
            return name; // Now we're sure the name is valid
        }

        /// <summary>
        /// Sets the level of the computer!
        /// </summary>
        /// <returns>The level of computer</returns>
        public int SetComputerLevel(Game game)
        {
            Console.Beep(600, 500); // Sound!
            do
            {
                isOk = false;

                Console.Write("{0," + (Console.WindowWidth / 2) + "}", ""); // Center the key cursor
                key = Console.ReadKey();

                if ((int)key.KeyChar == 49) // If pressed 1
                {
                    isOk = true;
                    return 1;
                }
                else if ((int)key.KeyChar == 50) // If pressed 2
                {
                    isOk = true;
                    return 2;
                }
                else if ((int)key.KeyChar == 51) // If pressed 3
                {
                    isOk = true;
                    return 3;
                }
                else // If bad key pressed
                {
                    // "isOk" stays 'false'
                    Console.Clear();
                    game.Displayer.DisplayComputerLevels(isOk); // Sends 'isOk' to display error msg!
                }
            } while (!isOk);

            return -1;
        }

        /// <summary>
        /// Requests the user to select who is the first player to play!
        /// </summary>
        /// <returns>True = computer plays first, False = Human plays first</returns>
        public bool IsComputerFirstToPlay(Game game)
        {
            Console.Beep(600, 500); // Sound!
            do
            {
                isOk = false;

                Console.Write("{0," + (Console.WindowWidth / 2) + "}", ""); // Center the key cursor
                key = Console.ReadKey();

                Console.Clear();

                if ((int)key.KeyChar == 49) // If pressed 1 = Computer is first
                {
                    isOk = true;
                    return true;
                }
                else if ((int)key.KeyChar == 50) // If pressed 2 = Human is first
                {
                    isOk = true;
                    return false;
                }
                else // If bad key pressed
                {
                    // "isOk" stays 'false'
                    Console.Clear();
                    game.Displayer.DisplayWhoIsFirst(isOk); // Sends 'isOk' to display error msg!
                }
            } while (!isOk);

            return true;
        }

        #endregion

    }
}
