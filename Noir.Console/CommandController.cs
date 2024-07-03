using Noir.Application;
using Noir.Application.Contracts;
using Noir.Application.Contracts.Commands;

namespace Noir.Console
{
    internal static class CommandController
    {
        internal static void PrintCommands()
        {
            System.Console.WriteLine("movie, m");
            System.Console.WriteLine("episode, e");
            System.Console.WriteLine("help, h");
            System.Console.WriteLine("exit, x");
        }

        internal static void ProcessMovie()
        {
            RenameProcessTemplate(renameService: new MovieRenameService());
        }

        internal static void ProcessEpisode()
        {
            RenameProcessTemplate(renameService: new EpisodeRenameService());
        }

        private static void RenameProcessTemplate(IRenameService renameService)
        {
            System.Console.Write("Path: ");
            var path = System.Console.ReadLine();
            try
            {
                var previewContexts = renameService.Execute(new RenamePreviewCommand(path));
                PrintRenameContexts(previewContexts, ConsoleColor.Yellow);

                System.Console.Write("Confirm [y/n]?");
                var conformation = System.Console.ReadLine();
                if (conformation?.ToLower() == "y")
                {
                    var renameContexts = renameService.Execute(new RenameCommand(path));
                    PrintRenameContexts(renameContexts, ConsoleColor.Green);
                }
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }

        private static void PrintRenameContexts(IEnumerable<RenameContext> items, ConsoleColor consoleColor)
        {
            foreach (var item in items)
            {
                System.Console.ForegroundColor = ConsoleColor.White;
                System.Console.Write($"{item.OldName} --> ");
                System.Console.ForegroundColor = consoleColor;
                System.Console.WriteLine(item.NewName);
            }
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
