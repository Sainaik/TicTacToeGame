using System;
using System.Text.RegularExpressions;

namespace TicTacToeGame
{
    class Program
    {
        static char[] ticTacToeBoard;
        static char userSymbol;
        static char computerSymbol = 'X';
        const int PLAYER = 1;
        const int COMPUTER = 2;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello!, Welcome to TicTac Toe Game");


            ticTacToeBoard = CreateTicTacToeBoard();

            Console.WriteLine("Board is Created \n");

            //to show the playing board
            ShowBoard();

            //to choose Symbol
            userSymbol = ChoosePlayerSymbol();

            //to choose the first player
            int whoStartsGame = Toss();

            bool notwin = true;

            //to play a move

            if (whoStartsGame == PLAYER)
            {
                Console.WriteLine("User Starts playing first");
                UsersMove(userSymbol);

            }
            else
            {
                Console.WriteLine("Computer Starts playing first");
                UsersMove(computerSymbol);
            }

         
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

            char userSymbol = char.ToUpper(playerSymbol[0]);


            if (computerSymbol == userSymbol)
            {
                computerSymbol = 'O';
            }

            Console.WriteLine("User Symbol : " + userSymbol);

            Console.WriteLine("Computer Symbol : " + computerSymbol + "\n");


            return userSymbol;

        }

        /* UC3 */
        public static void ShowBoard()
        {
            Console.WriteLine(ticTacToeBoard[1] + "  |  " + ticTacToeBoard[2] + "  |  " + ticTacToeBoard[3]);
            Console.WriteLine(ticTacToeBoard[4] + "  |  " + ticTacToeBoard[5] + "  |  " + ticTacToeBoard[6]);
            Console.WriteLine(ticTacToeBoard[7] + "  |  " + ticTacToeBoard[8] + "  |  " + ticTacToeBoard[9]);
        }

        /* UC 4 & 5*/
        public static void UsersMove(char userSymbol )
        {
            int userMove = -1;

            Console.WriteLine("Enter the your move between 1 to 9");
            string move = Console.ReadLine();
            string pattern = "^[1-9]$";
            Regex regex = new Regex(pattern);

            bool shouldNotBreak = true;
            while (shouldNotBreak)
            {
                if (regex.IsMatch(move))
                {
                    userMove = Convert.ToInt32(move);
                    if (ticTacToeBoard[userMove] == ' ')
                    {
                        Console.WriteLine("The position is marked with "+userSymbol+"\n");
                        ticTacToeBoard[userMove] = userSymbol;
                        ShowBoard();
                        shouldNotBreak = false;
                    }
                    else
                    {
                        Console.WriteLine("The position is occupied, try other position");
                        move = Console.ReadLine();
                    }

                }
                else
                {
                    Console.WriteLine("Enter correct input");
                    move = Console.ReadLine();
                }

            }
           
        }

        /*UC6*/
        static int Toss()
        {
            Random random = new Random();
            return random.Next(1, 3);
        }



        
    }

}
