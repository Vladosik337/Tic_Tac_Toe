using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace Tic_Tac_Toe.Models
{
    public class AIPlayer : IPlayer
    {
        public string Name { get; set; }
        public char Symbol { get; set; }

        public AIPlayer(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public int GetMove()
        {

            Random random = new Random();
            return random.Next(1, 10);
        }
    }
}