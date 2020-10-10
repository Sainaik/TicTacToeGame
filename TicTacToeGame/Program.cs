using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!, Welcome to TicTac Toe Game");


            char[] ticTacToeBoard = CreateTicTacToeBoard();

            Console.WriteLine("Board is Created \n");

            //to choose Symbol

            char userSymbol = ChoosePlayerSymbil();

            char systemSymbol = 'X';

            if(systemSymbol == userSymbol)
            {
                systemSymbol = 'O';
            }

            Console.WriteLine("User Symbol : " + userSymbol);

            Console.WriteLine("Computer Symbol : " + systemSymbol);
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

        public static char  ChoosePlayerSymbil()
        {
            Console.WriteLine("choose your playing symbol(O or X):");

            String playerSymbol = Console.ReadLine();

            bool correctSymbol = true;

            while (correctSymbol)
            {
                if (!playerSymbol.Equals("X") && !playerSymbol.Equals("O"))
                {
                    Console.WriteLine("please choose playing symbol between (O or X):");
                    playerSymbol = Console.ReadLine();
                }
                else
                {
                    correctSymbol = false;
                }

            }

            return char.ToUpper(playerSymbol[0]);

        }
    }



    


}
