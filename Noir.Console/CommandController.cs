using Noir.Domain.Contracts;
using Noir.Service;
using Noir.Service.Contracts;

namespace Noir.Console
{
    internal static class CommandController
    {
        internal static void PrintCommands()
        {
            System.Console.WriteLine("movie, m");
            System.Console.WriteLine("series, s");
            System.Console.WriteLine("help, h");
            System.Console.WriteLine("exit, e");
        }

        internal static void ProcessMovie()
        {
            RenameProcessTemplate(renameService: new MovieRenameService());
        }

        internal static void ProcessSeries()
        {
            RenameProcessTemplate(renameService: new SeriesRenameService());
        }

        private static void RenameProcessTemplate(IRenameService renameService)
        {
            System.Console.Write("Path: ");
            var path = System.Console.ReadLine();
            try
            {
                var previewContexts = renameService.Preview(path);
                PrintRenameContexts(previewContexts);

                System.Console.WriteLine("");
                System.Console.Write("Confirm [y/n]?");
                var conformation = System.Console.ReadLine();
                if (conformation?.ToLower() == "y")
                {
                    var renameContexts = renameService.Rename(path);
                    PrintRenameContexts(renameContexts);
                }
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }

        private static void PrintRenameContexts(IEnumerable<RenameContext> items)
        {
            foreach (var item in items)
            {
                System.Console.WriteLine($"{item.OldName} --> {item.NewName}");
            }
        }
    }
}