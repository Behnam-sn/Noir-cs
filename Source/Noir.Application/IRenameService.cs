using Noir.Application.Commands;

namespace Noir.Application;

public interface IRenameService
{
    IEnumerable<RenameContext> Execute(RenamePreviewCommand command);

    IEnumerable<RenameContext> Execute(RenameCommand command);
}
