namespace Noir.Console;

public static class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            System.Console.Write("Command: ");
            var command = System.Console.ReadLine()?.ToLower();

            switch (command)
            {
                case "help" or "h":
                    CommandController.PrintCommands();
                    break;

                case "movie" or "m":
                    CommandController.ProcessMovie();
                    break;

                case "episode" or "e":
                    CommandController.ProcessEpisode();
                    break;

                case "exit" or "x":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
