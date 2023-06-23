using Colibri.Models.Commands.Portfolio;
using Colibri.Models.Statistics;
using Colibri.Models.TeamMembers;

namespace Colibri.Infrastructure;

public interface IStatisticService
{
    Task<Statistic> Create(CreatePortfolioCommand command, CancellationToken token);
    Task<Statistic> Get(GetPortfolioCommand command, CancellationToken token);
    Task<IEnumerable<Statistic>> GetAll(GetAllPortfolioCommand command, CancellationToken token);
    Task<Statistic> Update(UpdatePortfolioCommand command, CancellationToken token);
    Task Delete(DeletePortfolioCommand command, CancellationToken token);
}