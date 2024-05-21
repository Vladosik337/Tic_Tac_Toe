using Tic_Tac_Toe.Models;
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
            player2Name = null;
        }

        public void DisplayInvalidMoveMessage()
        {
            Console.WriteLine("Invalid move. Try again.");
        }

        public void DisplayWinnerMessage(IPlayer player)
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

        public int DisplayMenu()
        {
            Console.WriteLine("Choose the game mode:");
            Console.WriteLine("1. Play with another player");
            Console.WriteLine("2. Play with AI");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2:");
            }
            return choice;
        }

        public void GetSecondPlayerInfo(out string player2Name)
        {
            Console.WriteLine("Enter name for Player 2 (O): ");
            player2Name = Console.ReadLine();
        }
    }
}