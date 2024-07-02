using Noir.Application.Contracts.Commands;

namespace Noir.Application.Contracts;

public interface IRenameService
{
    IEnumerable<RenameContext> Execute(RenamePreviewCommand command);

    IEnumerable<RenameContext> Execute(RenameCommand command);
}
