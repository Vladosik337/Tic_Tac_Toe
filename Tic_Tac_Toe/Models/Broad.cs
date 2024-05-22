using System;
using Tic_Tac_Toe.Views;

namespace TicTacToe.Models
{
    public class Board
    {
        private static Board _instance;
        public char[,] Grid { get; private set; }
        public const int Size = 3;
        private List<IBoardObserver> _observers = new List<IBoardObserver>();

        private Board()
        {
            Grid = new char[Size, Size];
            Reset();
        }

        public static Board Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Board();
                }
                return _instance;
            }
        }

        public void Reset()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j] = (char)('1' + i * Size + j);
                }
            }
            NotifyObservers();
        }

        public bool MakeMove(int cell, char playerSymbol)
        {
            int row = (cell - 1) / Size;
            int col = (cell - 1) % Size;

            if (Grid[row, col] != 'X' && Grid[row, col] != 'O')
            {
                Grid[row, col] = playerSymbol;
                NotifyObservers();
                return true;
            }
            return false;
        }

        public char CheckWinner()
        {
            for (int i = 0; i < Size; i++)
            {
                if (Grid[i, 0] == Grid[i, 1] && Grid[i, 1] == Grid[i, 2])
                    return Grid[i, 0];

                if (Grid[0, i] == Grid[1, i] && Grid[1, i] == Grid[2, i])
                    return Grid[0, i];
            }

            if (Grid[0, 0] == Grid[1, 1] && Grid[1, 1] == Grid[2, 2])
                return Grid[0, 0];

            if (Grid[0, 2] == Grid[1, 1] && Grid[1, 1] == Grid[2, 0])
                return Grid[0, 2];

            return ' ';
        }

        public bool IsFull()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Grid[i, j] != 'X' && Grid[i, j] != 'O')
                        return false;
                }
            }
            return true;
        }
        public void AddObserver(IBoardObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IBoardObserver observer)
        {
            _observers.Remove(observer);
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}