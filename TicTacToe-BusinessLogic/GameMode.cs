using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_BusinessLogic
{
    /// <summary>
    /// Holds the modes the game can run!
    /// </summary>
    public enum GameMode
    {
        PlayerVsPlayer,
        PlayerVsComputer,
        Waiting,
        ExitMode
    }
}
