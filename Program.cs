using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_13_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.StartGame();
        }
    }

    class TicTacToe
    {
        private char[,] board = new char[3, 3];
        private char currentPlayer;
        private Random random = new Random();

        public void StartGame()
        {
            InitializeBoard();
            currentPlayer = random.Next(2) == 0 ? 'X' : 'O';
            Console.WriteLine($"Player {currentPlayer} starts the game!");

            while (true)
            {
                PrintBoard();
                PlayerMove();
                if (CheckWin())
                {
                    PrintBoard();
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    break;
                }
                if (IsBoardFull())
                {
                    PrintBoard();
                    Console.WriteLine("The game is a draw!");
                    break;
                }
                SwitchPlayer();
            }
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        private void PrintBoard()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("-----");
            }
        }

        private void PlayerMove()
        {
            int row, col;
            while (true)
            {
                Console.WriteLine($"Player {currentPlayer}'s turn.");
                Console.Write("Enter row (1-3): ");
                row = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Enter column (1-3): ");
                col = Convert.ToInt32(Console.ReadLine()) - 1;

                if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
                {
                    board[row, col] = currentPlayer;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }
        }

        private void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        private bool CheckWin()
        {
            // Check rows and columns
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                    (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                {
                    return true;
                }
            }

            // Check diagonals
            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
            {
                return true;
            }

            return false;
        }

        private bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
