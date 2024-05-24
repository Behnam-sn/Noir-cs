namespace Noir.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            System.Console.Write("Enter The Command: ");
            var command = System.Console.ReadLine()?.ToLower();

            if (command == "help" || command == "h")
            {
                CommandController.PrintCommands();
            }

            if (command == "movie" || command == "m")
            {
                CommandController.ProcessMovie();
            }

            if (command == "series" || command == "s")
            {
                CommandController.ProcessSeries();
            }

            if (command == "exit" || command == "e")
            {
                break;
            }
        }
    }
}