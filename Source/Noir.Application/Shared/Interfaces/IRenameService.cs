using Noir.Application.Shared.Commands;
using Noir.Application.Shared.Queries;
using Noir.Application.Shared.Responses;

namespace Noir.Application.Shared.Interfaces;

public interface IRenameService
{
    IEnumerable<RenameContext> Execute(RenamePreviewQuery command);

    IEnumerable<RenameContext> Execute(RenameCommand command);
}
