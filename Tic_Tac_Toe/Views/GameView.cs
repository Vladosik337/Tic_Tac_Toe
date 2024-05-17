using TicTacToe.Models;

namespace TicTacToe.Views
{
    public class GameView
    {
        public void DisplayBoard(Board board)
        {
            for (int i = 0; i < Board.Size; i++)
            {
                for (int j = 0; j < Board.Size; j++)
                {
                    Console.Write(board.Grid[i, j]);
                    if (j < Board.Size - 1) Console.Write("|");
                }
                Console.WriteLine();
                if (i < Board.Size - 1) Console.WriteLine("-----");
            }
        }

        public void ClearConsole()
        {
            Console.Clear();
        }

        public void GetPlayerInfo(out string player1Name, out string player2Name)
        {
            Console.WriteLine("Enter name for Player 1 (X): ");
            player1Name = Console.ReadLine();
            Console.WriteLine("Enter name for Player 2 (O): ");
            player2Name = Console.ReadLine();
        }

        public void GetPlayerMove(Player player, out int cell)
        {
            while (true)
            {
                Console.WriteLine($"{player.Name} ({player.Symbol}), enter your move (1-9): ");
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
        }

        public void DisplayInvalidMoveMessage()
        {
            Console.WriteLine("Invalid move. Try again.");
        }

        public void DisplayWinnerMessage(Player player)
        {
            Console.WriteLine($"{player.Name} wins!");
        }

        public void DisplayDrawMessage()
        {
            Console.WriteLine("The game is a draw!");
        }

        public bool PromptPlayAgain()
        {
            Console.WriteLine("Do you want to play again? (y/n): ");
            string response = Console.ReadLine().ToLower();
            return response == "y";
        }
    }
}
