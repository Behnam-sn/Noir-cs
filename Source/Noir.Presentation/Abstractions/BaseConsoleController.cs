using Noir.Presentation.Contracts;

namespace Noir.Presentation.Abstractions;

public abstract class BaseConsoleController
{
    protected abstract string Title { get; }
    protected List<Command> Commands { get; } = [];

    public BaseConsoleController()
    {
        Commands.AddRange([
            new(
                Titles: ["Help", "H"],
                Action: PrintCommands
            ),
            new(
                Titles: ["Quit", "Q"],
                Action: () => {}
            )
        ]);
    }

    private void PrintCommands()
    {
        foreach (var command in Commands)
        {
            Console.WriteLine(
                string.Join(
                    separator: ", ",
                    values: command.Titles
                )
            );
        }
        Console.WriteLine("");
    }

    public void Run()
    {
        while (true)
        {
            Console.Write($"{Title} Command: ");
            var input = Console.ReadLine()?.ToLower();

            var command = Commands
                .FirstOrDefault(
                    i => i.Titles.Any(
                        j => j.Equals(input, StringComparison.CurrentCultureIgnoreCase)
                    )
                );

            if (command is null)
            {
                continue;
            }

            if (command.Titles.Contains("Quit"))
            {
                return;
            }

            try
            {
                command.Action();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
