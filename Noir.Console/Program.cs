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
        // take the address as input
        System.Console.Write("Path: ");
        var path = System.Console.ReadLine();
        try
        {
            // give it to MovieService for rename preview
            var movieService = new MovieRenameService();
            // retrieve the information
            var previewData = movieService.Preview(path);
            // show it as preview
            foreach (var item in previewData)
            {
                System.Console.WriteLine($"{item.OldName} --> {item.NewName}");
            }
            // ask for conformation
            // give it to MovieService for rename

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
