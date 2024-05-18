namespace TicTacToe.Models;
public class PlayerFactory
{
    public static Player CreatePlayer(string name, char symbol)
    {
        return new Player(name, symbol);
    }
}
