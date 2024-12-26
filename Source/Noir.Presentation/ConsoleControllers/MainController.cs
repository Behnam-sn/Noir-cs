using Noir.Application;
using Noir.Application.Commands;

namespace Noir.Presentation.ConsoleControllers;

public class MainController : BaseController
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
        System.Console.Write("Path: ");
        var path = System.Console.ReadLine();
        try
        {
            var previewContexts = renameService.Execute(new RenamePreviewCommand(path));
            PrintRenameContexts(
                items: previewContexts,
                consoleColor: ConsoleColor.Yellow
            );

            System.Console.Write("Confirm [y/n]? ");
            var conformation = System.Console.ReadLine();
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
            System.Console.WriteLine(exception.Message);
        }
    }

    private static void PrintRenameContexts(IEnumerable<RenameContext> items, ConsoleColor consoleColor)
    {
        foreach (var item in items.OrderBy(i => i.NewName))
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write($"{item.OldName} --> ");

            System.Console.ForegroundColor = consoleColor;
            System.Console.WriteLine(item.NewName);
        }
        System.Console.ForegroundColor = ConsoleColor.White;
    }
}
