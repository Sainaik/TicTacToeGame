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

            char userSymbol = ChoosePlayerSymbol();

            char systemSymbol = 'X';

            if(systemSymbol == userSymbol)
            {
                systemSymbol = 'O';
            }

            Console.WriteLine("User Symbol : " + userSymbol);

            Console.WriteLine("Computer Symbol : " + systemSymbol+"\n");

            ShowBoard(ticTacToeBoard);
        }

        /*UC 1*/
        public static char[] CreateTicTacToeBoard()
        {
            char[] ticTacToeBoard = new char[10];

            for(int i = 1; i< 10;i++)
            {
                ticTacToeBoard[i] = ' ';
            }
            
            return ticTacToeBoard;
        }

        /*UC 2*/
        public static char  ChoosePlayerSymbol()
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

        static void ShowBoard(char[] ticTacToeBoard)
        {

            for (int i = 1; i < 10;)
            {

                for (int j = 1; j <= 3; j++)
                {

                    if (j != 3)
                    {
                        Console.Write(ticTacToeBoard[i] + "  |");
                    }
                    else
                    {
                        Console.Write(ticTacToeBoard[i]);
                    }
                    i++;
                }

                Console.WriteLine("\n");
            }

        }

    }






}
