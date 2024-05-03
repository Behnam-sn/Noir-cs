namespace Noir.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            System.Console.Write("Enter The Command: ");
            var command = System.Console.ReadLine()?.ToLower();

            if (command == "movie" || command == "m")
            {
                HandleMovie();
            }

            if (command == "series" || command == "s")
            {
                HandleSeries();
            }

            if (command == "help" || command == "h")
            {
                PrintCommands();
            }

            if (command == "exit" || command == "e")
            {
                break;
            }
        }
    }

    private static void HandleMovie()
    {
        throw new NotImplementedException();
    }

    private static void HandleSeries()
    {
        throw new NotImplementedException();
    }

    private static void PrintCommands()
    {
        System.Console.WriteLine("movie, m");
        System.Console.WriteLine("series, s");
        System.Console.WriteLine("help, h");
        System.Console.WriteLine("exit, e");
    }
}