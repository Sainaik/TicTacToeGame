using System;
using System.Text.RegularExpressions;

namespace TicTacToeGame
{
    class Program
    {
        
        static char userSymbol;
        static char computerSymbol = 'X';
        const int PLAYER = 1;
        const int COMPUTER = 2;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello!, Welcome to TicTac Toe Game");


            char[] ticTacToeBoard = CreateTicTacToeBoard();

            Console.WriteLine("Board is Created \n");

            //to show the playing board
            ShowBoard(ticTacToeBoard);

            //to choose Symbol
            userSymbol = ChoosePlayerSymbol();

            //to choose the first player
            int whoStartsGame = Toss();

            bool isWinner = false;

            //to play a move

            if (whoStartsGame == PLAYER)
            {
                Console.WriteLine("User Starts playing first");
                UsersMove(userSymbol, ticTacToeBoard);
                isWinner = IsWinner(userSymbol,ticTacToeBoard);
            }
            else
            {
                Console.WriteLine("Computer Starts playing first");
                int computerMove = ComputerMove(ticTacToeBoard);
                Console.WriteLine("Computer move is: " + computerMove);
                //isWinner = IsWinner(userSymbol,ticTacToeBoard);
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
        public static void ShowBoard(char[] ticTacToeBoard) 
        {
            Console.WriteLine(ticTacToeBoard[1] + "  |  " + ticTacToeBoard[2] + "  |  " + ticTacToeBoard[3]);
            Console.WriteLine(ticTacToeBoard[4] + "  |  " + ticTacToeBoard[5] + "  |  " + ticTacToeBoard[6]);
            Console.WriteLine(ticTacToeBoard[7] + "  |  " + ticTacToeBoard[8] + "  |  " + ticTacToeBoard[9]);
        }

        /* UC 4 & 5*/
        public static void UsersMove(char userSymbol, char[] ticTacToeBoard)
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
                        ShowBoard(ticTacToeBoard);
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

        /*UC7*/
        static bool IsWinner(char ch, char[]board)
        {
            bool isWin = false;

            if ((board[1] == ch && board[2] == ch && board[3] == ch) ||
               ( board[4] == ch && board[5] == ch && board[6] == ch) ||
               ( board[7] == ch && board[8] == ch && board[9] == ch) ||
               ( board[1] == ch && board[4] == ch && board[7] == ch) ||
               ( board[2] == ch && board[5] == ch && board[8] == ch) ||
               ( board[3] == ch && board[6] == ch && board[9] == ch) ||
               ( board[1] == ch && board[5] == ch && board[9] == ch) ||
               ( board[3] == ch && board[5] == ch && board[7] == ch))
            {
                isWin = true;
            }
            return isWin;

        }

        //UC8 
        static int ComputerMove(char[] ticTacToeBoard)
        {
            int computerMove = -1;

            // check if computer wins
            computerMove = GetPostion(computerSymbol, ticTacToeBoard);

            if(computerMove != -1)
            {
                return computerMove;
            }


            // check if opponent wins
            computerMove = GetPostion(userSymbol, ticTacToeBoard);

            if (computerMove != -1)
            {
                return computerMove;
            }

            //check the corners

            int[] corners = {1, 3, 7, 9 };

            foreach(int corner in corners)
            {
                if(ticTacToeBoard[corner]== ' ' )
                {
                    computerMove = corner;
                    break;
                }
            }

            //check the center
            int boardCenter = 5;

            if (ticTacToeBoard[boardCenter] == ' ')
            {
                computerMove = boardCenter;
                return computerMove;   
            }

            //check the corners

            int[] otherPositions = { 2, 4, 6, 8 };

            foreach (int postion in otherPositions)
            {
                if (ticTacToeBoard[postion] == ' ')
                {
                    computerMove = postion;
                    break;
                }
            }


            return computerMove;
        }


        static int GetPostion(char symbol, char[] ticTacToeBoard)
        {
            int computerMove = -1;
            for (int i = 1; i <= 9; i++)
            {
                char[] copyOfBoard = GetCopyOfBoard(ticTacToeBoard);


                if (copyOfBoard[i] == ' ')
                {
                    copyOfBoard[i] = computerSymbol;
                }

                if (IsWinner(symbol, copyOfBoard))
                {
                    computerMove = i;
                    break;
                }

            }
            return computerMove;

        }

        static char[] GetCopyOfBoard(char[] board)
        {
            char[] boardCopy = new char[10];

            Array.Copy(board, 0, boardCopy, 0, board.Length);

            return boardCopy;
        }

    }






}

