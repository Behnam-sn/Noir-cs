namespace Noir.Domain.Contracts;

public interface IProcessor
{
    RenameContext? Rename(string fileNameWithPath);

    RenameContext? Preview(string fileNameWithPath);
}