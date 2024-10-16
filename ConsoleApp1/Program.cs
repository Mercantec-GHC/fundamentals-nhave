namespace ConsoleApp1
{
    internal class Program
    {
        public static Random random = new Random();

        static bool ShouldPlay()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input != null)
                {
                    if (input.ToLower() == "y") return true;
                    else if (input.ToLower() == "n") break;
                    else Console.WriteLine("\nPlease press (Y/N)");
                }
            }
            return false;
        }

        static bool WinOrLose(int target, int roll)
        {
            return roll > target;
        }

        static void PlayGame()
        {
            var play = true;

            while (play)
            {
                int target = random.Next(1, 6);
                int roll = random.Next(1, 6);

                Console.WriteLine($"Roll a number greater than {target} to win!");
                Console.WriteLine($"You rolled a {roll}");
                Console.WriteLine(WinOrLose(target, roll));
                Console.WriteLine("\nPlay again? (Y/N)");

                play = ShouldPlay();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to play? (Y/N)");
            if (ShouldPlay())
            {
                PlayGame();
            }
        }
    }
}
