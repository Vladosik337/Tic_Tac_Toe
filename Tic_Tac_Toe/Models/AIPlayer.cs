namespace Tic_Tac_Toe.Models;
public class AIPlayer : IPlayer
{
    public string Name { get; set; }
    public char Symbol { get; set; }
    public int WinCount { get; set; }

    public AIPlayer(string name, char symbol)
    {
        Name = name;
        Symbol = symbol;
        WinCount = 0;
    }

    public int GetMove()
    {

        Random random = new Random();
        return random.Next(1, 10);
    }
}