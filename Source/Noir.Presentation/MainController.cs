using Noir.Application;
using Noir.Application.Commands;
using Noir.Presentation.Abstractions;

namespace Noir.Presentation;

public class MainController : BaseConsoleController
{
    protected override string Title { get; } = "Noir";

    public MainController()
    {
        Commands.AddRange([
            new(
                Titles: ["Movies", "M"],
                Action: MoviesManagement
            ),
            new(
                Titles: ["Episodes", "E"],
                Action: EpisodesManagement
            ),
        ]);
    }

    private static void MoviesManagement()
    {
        RenameProcessTemplate(renameService: new MovieRenameService());
    }

    private static void EpisodesManagement()
    {
        RenameProcessTemplate(renameService: new EpisodeRenameService());
    }

    private static void RenameProcessTemplate(IRenameService renameService)
    {
        Console.Write("Path: ");
        var path = Console.ReadLine();
        try
        {
            var previewContexts = renameService.Execute(new RenamePreviewCommand(path));
            PrintRenameContexts(
                items: previewContexts,
                consoleColor: ConsoleColor.Yellow
            );

            Console.Write("Confirm [y/n]? ");
            var conformation = Console.ReadLine();
            if (conformation?.ToLower() == "y")
            {
                var renameContexts = renameService.Execute(new RenameCommand(path));
                PrintRenameContexts(
                    items: renameContexts,
                    consoleColor: ConsoleColor.Green
                );
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static void PrintRenameContexts(IEnumerable<RenameContext> items, ConsoleColor consoleColor)
    {
        foreach (var item in items.OrderBy(i => i.NewName))
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{item.OldName} --> ");

            Console.ForegroundColor = consoleColor;
            Console.WriteLine(item.NewName);
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
}
