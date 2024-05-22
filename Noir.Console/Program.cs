using Noir.Service;

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
                ProcessMovie();
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

    private static void ProcessMovie()
    {
        System.Console.Write("Path: ");
        var path = System.Console.ReadLine();
        try
        {
            var movieService = new MovieRenameService();
            var previewData = movieService.Preview(path);

            foreach (var item in previewData)
            {
                System.Console.WriteLine($"{item.OldName} --> {item.NewName}");
            }

            var conformation = System.Console.ReadLine();
            if (conformation?.ToLower() == "y")
            {
                var items = movieService.Rename(path);
                foreach (var item in items)
                {
                    System.Console.WriteLine($"{item.OldName} --> {item.NewName}");
                }
            }
        }
        catch (Exception exception)
        {
            System.Console.WriteLine(exception.Message);
        }
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
