namespace Modolus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 100; i++)
            {
                // (i%3==0 ? "BANKE" : "") er en inline if statement
                Console.WriteLine($"Number: {i}\t{(i%3==0 ? "BANKE" : "")}{(i % 5 == 0 ? "BØF" : "")}");
            }
        }
    }
}
