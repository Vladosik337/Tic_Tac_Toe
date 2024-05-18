namespace TicTacToe.Models;
public class Player
{
    public string Name { get; set; }
    public char Symbol { get; set; }
    public int WinCount { get; set; }

    public Player(string name, char symbol)
    {
        Name = name;
        Symbol = symbol;
        WinCount = 0;
    }
}
