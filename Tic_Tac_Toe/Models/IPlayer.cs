namespace Tic_Tac_Toe.Models;
public interface IPlayer
{
    string Name { get; set; }
    char Symbol { get; set; }
    int WinCount { get; set; }

    int GetMove();
}