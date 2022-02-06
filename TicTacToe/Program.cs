/*
 * Console tic tac toe game.
 */

using System;
using System.Diagnostics;

namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool playing = true;
            string input;
            
            while (playing)
            {
                Console.WriteLine("Type START to play the game!");
                input = Console.ReadLine();
                
                if (input.ToLower().Equals("start"))
                {
                    Console.Clear();
                    StartGame();
                }
                else
                {
                    Console.WriteLine("[ERROR] Invalid input!");
                }
            }
        }

        public static void StartGame()
        {
            char[,] tiles =
            {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            };
            
            int player = 1;
            char letter = 'O';
            char input = '0';
            int turns = 0;

            bool running = true;
            while (running)
            {
                switch (player) // Sets the letter based on whose turn it is.
                {
                    case 1:
                        letter = 'O';
                        break;
                    case 2:
                        letter = 'X';
                        break;
                    default:
                        Console.WriteLine("[ERROR] Switch statement!");
                        break;
                }
                
                ShowGameBoard(tiles);
                
                Console.Write($"Player {player} Choose your tile: ");

                bool notValid = true;
                while (notValid)
                {
                    try // Incase the input is not a number 1-9.
                    {
                        input = char.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        input = '0';
                    }
                    
                    if (input == '1' && tiles[0, 0] == '1') // Manually check every input versus the tile.
                    {
                        tiles[0, 0] = letter;
                        notValid = false;
                    }
                    else if (input == '2' && tiles[0, 1] == '2')
                    {
                        tiles[0, 1] = letter;
                        notValid = false;
                    }
                    else if (input == '3' && tiles[0, 2] == '3')
                    {
                        tiles[0, 2] = letter;
                        notValid = false;
                    }
                    else if (input == '4' && tiles[1, 0] == '4')
                    {
                        tiles[1, 0] = letter;
                        notValid = false;
                    }
                    else if (input == '5' && tiles[1, 1] == '5')
                    {
                        tiles[1, 1] = letter;
                        notValid = false;
                    }
                    else if (input == '6' && tiles[1, 2] == '6')
                    {
                        tiles[1, 2] = letter;
                        notValid = false;
                    }
                    else if (input == '7' && tiles[2, 0] == '7')
                    {
                        tiles[2, 0] = letter;
                        notValid = false;
                    }
                    else if (input == '8' && tiles[2, 1] == '8')
                    {
                        tiles[2, 1] = letter;
                        notValid = false;
                    }
                    else if (input == '9' && tiles[2, 2] == '9')
                    {
                        tiles[2, 2] = letter;
                        notValid = false;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR] Invalid input!!!");
                        Console.Write("Choose a new tile: ");
                        notValid = true;
                    }
                }
                turns++; // Increments turns after every round.
                
                Console.Clear();
                
                if (CheckWin(tiles, player)) // Checks for wins after every round
                {
                    ShowWin(1, player, tiles);
                    running = false;
                }
                else if (turns > 8 && !CheckWin(tiles, player))
                {
                    ShowWin(3, player, tiles);
                    running = false;
                }
                else
                {
                    ShowWin(2, player, tiles);
                }
                
                if (player == 1)
                    player = 2;
                else
                    player = 1;
            }
        }
        public static bool CheckWin(char[,] tiles, int player) // Checks who wins, returns false if no one wins.
        {
            bool isWin = false;
            char letter;

            if (player == 1)
                letter = 'O';
            else
                letter = 'X';
            
            // Check for horizontal wins.
            if (tiles[0, 0] == letter && tiles[0, 1] == letter && tiles[0, 2] == letter)
                isWin = true;
            else if (tiles[1, 0] == letter && tiles[1, 1] == letter && tiles[1, 2] == letter)
                isWin = true;
            else if (tiles[2, 0] == letter && tiles[2, 1] == letter && tiles[2, 2] == letter)
                isWin = true;

            // Check for vertical wins.
            if (tiles[0, 0] == letter && tiles[1, 0] == letter && tiles[2, 0] == letter)
                isWin = true;
            else if (tiles[0, 1] == letter && tiles[1, 1] == letter && tiles[2, 1] == letter)
                isWin = true;
            else if (tiles[0, 2] == letter && tiles[1, 2] == letter && tiles[2, 2] == letter)
                isWin = true;
            
            // Check for diagonal wins.
            if (tiles[0, 0] == letter && tiles[1, 1] == letter && tiles[2, 2] == letter)
                isWin = true;
            else if (tiles[2, 0] == letter && tiles[1, 1] == letter && tiles[0, 2] == letter)
                isWin = true;

            return isWin;
        }

        public static void ShowWin(int type, int player, char[,] tiles) // Shows gameboard depending on win.
        {
            if (type != 2)
            {
                ShowGameBoard(tiles);
            }
            
            if (type == 1)
                Console.WriteLine($"Player {player} WINS!!!");
            if (type == 3)
                Console.WriteLine($"Cats game, no one wins!");
        }

        public static void ShowGameBoard(char[,] tiles) // Prints the gameboard to the console.
        {
            Console.WriteLine("   |   |   "); // Prints out the game board in standard tic tac toe fashion.
            Console.WriteLine($" {tiles[0, 0]} | {tiles[0, 1]} | {tiles[0, 2]} ");
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine($" {tiles[1, 0]} | {tiles[1, 1]} | {tiles[1, 2]} ");
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine($" {tiles[2, 0]} | {tiles[2, 1]} | {tiles[2, 2]} ");
            Console.WriteLine("   |   |   ");
        }
    }
}