using Colibri.Models.Commands.Portfolio;
using Colibri.Models.Portfolios;

namespace Colibri.Infrastructure;

public interface IPortfolioService
{
    Task<Portfolio> Create(CreatePortfolioCommand command, CancellationToken token);
    Task<Portfolio> Get(GetPortfolioCommand command, CancellationToken token);
    Task<IEnumerable<Portfolio>> GetAll(GetAllPortfolioCommand command, CancellationToken token);
    Task<Portfolio> Update(UpdatePortfolioCommand command, CancellationToken token);
    Task Delete(DeletePortfolioCommand command, CancellationToken token);
    Task<Portfolio> UpdateVisibility(UpdateVisibilityPortfolioCommand command, CancellationToken token);
}