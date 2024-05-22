using Tic_Tac_Toe.Models;
using TicTacToe.Models;
using TicTacToe.Views;

namespace TicTacToe.Controllers
{

    public class GameController
    {
        private readonly Board _board;
        private IPlayer _player1;
        private IPlayer _player2;
        private IPlayer _currentPlayer;
        private readonly GameView _view;
        private int _drawCount;

        public GameController()
        {
            _board = Board.Instance;
            _view = new GameView();
            _board.AddObserver(_view);
            _drawCount = 0;
        }

        public void StartGame()
        {
            SetUpPlayers();

            while (true)
            {
                PlayRound();
                DisplayStatistics();
                if (!_view.PromptPlayAgain()) break;
                _view.ClearConsole();
                _board.Reset();
            }
        }

        private void SetUpPlayers()
        {
            _view.GetPlayerInfo(out string player1Name, out _);
            _player1 = new HumanPlayer(player1Name, 'X');

            int choice = _view.DisplayMenu();

            if (choice == 1)
            {
                _view.GetSecondPlayerInfo(out string player2Name);
                _player2 = new HumanPlayer(player2Name, 'O');
            }
            else
            {
                _player2 = new AIPlayer("AI Player", 'O');
            }

            _currentPlayer = _player1;
        }

        private void PlayRound()
        {
            while (true)
            {
                _view.ClearConsole();
                _view.DisplayBoard(_board);

                int cell = _currentPlayer.GetMove();

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
                    UpdateWinCount(_currentPlayer);
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
        public void UpdateWinCount(IPlayer player)
        {
            player.WinCount++;
        }

        private void DisplayStatistics()
        {
            _view.DisplayStatistics(_player1, _player2, _drawCount);
        }
    }
}

