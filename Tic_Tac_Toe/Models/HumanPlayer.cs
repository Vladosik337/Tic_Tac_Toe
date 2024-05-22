using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace Tic_Tac_Toe.Models
{
    public class HumanPlayer : IPlayer
    {
        public string Name { get; set; }
        public char Symbol { get; set; }
        public int WinCount { get; set; }

        public HumanPlayer(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
            WinCount = 0;
        }

        public int GetMove()
        {
            int cell;
            while (true)
            {
                Console.WriteLine($"{Name} ({Symbol}), enter your move (1-9): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out cell) && cell >= 1 && cell <= 9)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                }
            }
            return cell;
        }
    }
}