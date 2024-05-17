using TicTacToe.Controllers;

namespace TicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameController gameController = new GameController();
            gameController.StartGame();
        }
    }
}
