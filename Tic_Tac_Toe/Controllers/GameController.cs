using TicTacToe.Models;
using TicTacToe.Views;

namespace TicTacToe.Controllers
{
    public class GameController
    {
        private readonly Board _board;
        private Player _player1;
        private Player _player2;
        private Player _currentPlayer;
        private readonly GameView _view;

        public GameController()
        {
            _board = new Board();
            _view = new GameView();
        }

        public void StartGame()
        {
            SetUpPlayers();

            while (true)
            {
                PlayRound();
                if (!_view.PromptPlayAgain()) break;
                _view.ClearConsole();
                _board.Reset();
            }
        }

        private void SetUpPlayers()
        {
            _view.GetPlayerInfo(out string player1Name, out string player2Name);
            _player1 = new Player(player1Name, 'X');
            _player2 = new Player(player2Name, 'O');
            _currentPlayer = _player1;
        }

        private void PlayRound()
        {
            while (true)
            {
                _view.ClearConsole();
                _view.DisplayBoard(_board);

                int cell;
                _view.GetPlayerMove(_currentPlayer, out cell);

                if (!_board.MakeMove(cell, _currentPlayer.Symbol))
                {
                    _view.DisplayInvalidMoveMessage();
                    continue;
                }

                if (_board.CheckWinner() == _currentPlayer.Symbol)
                {
                    _view.ClearConsole();
                    _view.DisplayBoard(_board);
                    _view.DisplayWinnerMessage(_currentPlayer);
                    break;
                }

                if (_board.IsFull())
                {
                    _view.ClearConsole();
                    _view.DisplayBoard(_board);
                    _view.DisplayDrawMessage();
                    break;
                }

                _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
            }
        }
    }
}
