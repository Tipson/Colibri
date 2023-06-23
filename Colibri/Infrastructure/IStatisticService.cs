using Colibri.Models.Commands.Statistic;
using Colibri.Models.Statistics;

namespace Colibri.Infrastructure;

public interface IStatisticService
{
    Task<Statistic> Create(CreateStatisticCommand command, CancellationToken token);
    Task<Statistic> Get(GetStatisticCommand command, CancellationToken token);
    Task<IEnumerable<Statistic>> GetAll(GetAllStatisticCommand command, CancellationToken token);
    Task<Statistic> Update(UpdateStatisticCommand command, CancellationToken token);
    Task Delete(DeleteStatisticCommand command, CancellationToken token);
}