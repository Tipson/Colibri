using Colibri.Models.Commands.Error;
using Colibri.Models.Errors;

namespace Colibri.Infrastructure;

public interface IErrorService
{
    Task<Error> Create(CreateErrorCommand command, CancellationToken token);
    Task<Error> Get(GetErrorCommand command, CancellationToken token);
}