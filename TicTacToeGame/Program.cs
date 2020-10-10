using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!, Welcome to TicTac Toe Game");


            char[] ticTacToeBoard = CreateTicTacToeBoard();
        }

        public static char[] CreateTicTacToeBoard()
        {
            char[] ticTacToeBoard = new char[10];

            for(int i = 1; i< 10;i++)
            {
                ticTacToeBoard[i] = ' ';
            }
            
            return ticTacToeBoard;
        }
    }
}
