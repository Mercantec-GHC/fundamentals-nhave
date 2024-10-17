using System.Numerics;
using System;

namespace ChallengeFoodMiniGame
{
    internal class Program
    {
        static Random random = new Random();
        static int height = Console.WindowHeight - 1;
        static int width = Console.WindowWidth - 5;

        static bool shouldExit = false;

        // Console position of the player
        static int playerX = 0;
        static int playerY = 0;

        // Console position of the food
        static int foodX = 0;
        static int foodY = 0;

        // Available player and food strings
        static string[] states = { "('-')", "(^-^)", "(X_X)" };
        static string[] foods = { "@@@@@", "$$$$$", "#####" };

        // Current player string displayed in the Console
        static string player = states[0];

        // Index of the current food
        static int food = 0;

        // Returns true if the Terminal was resized 
        static bool TerminalResized()
        {
            return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
        }

        // Displays random food at a random location
        static void ShowFood()
        {
            // Update food to a random index
            food = random.Next(0, foods.Length);

            // Update food position to a random location
            foodX = random.Next(0, width - player.Length);
            foodY = random.Next(0, height - 1);

            // Display the food at the location
            Console.SetCursorPosition(foodX, foodY);
            Console.Write(foods[food]);
        }

        // Returns true if the player location matches the food location
        static bool GotFood()
        {
            return playerY == foodY && playerX == foodX;
        }

        // Returns true if the player appearance represents a sick state
        static bool PlayerIsSick()
        {
            return player.Equals(states[2]);
        }

        // Returns true if the player appearance represents a fast state
        static bool PlayerIsFaster()
        {
            return player.Equals(states[1]);
        }

        // Changes the player to match the food consumed
        static void ChangePlayer()
        {
            player = states[food];
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(player);
        }

        // Temporarily stops the player from moving
        static void FreezePlayer()
        {
            System.Threading.Thread.Sleep(1000);
            player = states[0];
        }

        // Reads directional input from the Console and moves the player
        static void Move(int speed = 1, bool otherKeysExit = false)
        {
            int lastX = playerX;
            int lastY = playerY;

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    playerY--;
                    break;
                case ConsoleKey.DownArrow:
                    playerY++;
                    break;
                case ConsoleKey.LeftArrow:
                    playerX -= speed;
                    break;
                case ConsoleKey.RightArrow:
                    playerX += speed;
                    break;
                case ConsoleKey.Escape:
                    shouldExit = true;
                    break;
                default:
                    // Exit if any other keys are pressed
                    shouldExit = otherKeysExit;
                    break;
            }

            // Clear the characters at the previous position
            Console.SetCursorPosition(lastX, lastY);
            for (int i = 0; i < player.Length; i++)
            {
                Console.Write(" ");
            }

            // Keep player position within the bounds of the Terminal window
            playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
            playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

            // Draw the player at the new location
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(player);
        }

        // Clears the console, displays the food and player
        static void InitializeGame()
        {
            Console.Clear();
            ShowFood();
            Console.SetCursorPosition(0, 0);
            Console.Write(player);
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            InitializeGame();
            while (!shouldExit)
            {
                if (TerminalResized())
                {
                    Console.Clear();
                    Console.Write("Console was resized. Program exiting.");
                    shouldExit = true;
                }
                else
                {
                    if (PlayerIsFaster())
                    {
                        Move(1, false);
                    }
                    else if (PlayerIsSick())
                    {
                        FreezePlayer();
                    }
                    else
                    {
                        Move(otherKeysExit: false);
                    }
                    if (GotFood())
                    {
                        ChangePlayer();
                        ShowFood();
                    }
                }
            }
        }
    }
}
