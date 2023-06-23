using Colibri.Models.Commands.Portfolio;
using Colibri.Models.Portfolios;

namespace Colibri.Infrastructure.Services;

public class StatisticService : IPortfolioService
{
    public Task<Portfolio> Create(CreatePortfolioCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Portfolio> Get(GetPortfolioCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Portfolio>> GetAll(GetAllPortfolioCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Portfolio> Update(UpdatePortfolioCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task Delete(DeletePortfolioCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}