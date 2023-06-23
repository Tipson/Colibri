using Colibri.Models.Commands.Portfolio;
using Colibri.Models.Reviews;

namespace Colibri.Infrastructure;

public interface IReviewService
{
    Task<Review> Create(CreatePortfolioCommand command, CancellationToken token);
    Task<Review> Get(GetPortfolioCommand command, CancellationToken token);
    Task<IEnumerable<Review>> GetAll(GetAllPortfolioCommand command, CancellationToken token);
    Task<Review> Update(UpdatePortfolioCommand command, CancellationToken token);
    Task Delete(DeletePortfolioCommand command, CancellationToken token);
}