using Colibri.Models.Commands.Portfolio;
using Colibri.Models.Reviews;

namespace Colibri.Infrastructure.Services;

public class ReviewService : IReviewService
{
    public Task<Review> Create(CreatePortfolioCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Review> Get(GetPortfolioCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Review>> GetAll(GetAllPortfolioCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<Review> Update(UpdatePortfolioCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task Delete(DeletePortfolioCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}