using Colibri.Models.Commands.Review;
using Colibri.Models.Reviews;

namespace Colibri.Infrastructure;

public interface IReviewService
{
    Task<Review> Create(CreateReviewCommand command, CancellationToken token);
    Task<Review> Get(GetReviewCommand command, CancellationToken token);
    Task<IEnumerable<Review>> GetAll(GetAllReviewCommand command, CancellationToken token);
    Task<Review> Update(UpdateReviewCommand command, CancellationToken token);
    Task Delete(DeleteReviewCommand command, CancellationToken token);
    Task<Review> UpdateVisibility(UpdateVisibilityReviewCommand command, CancellationToken token);

}