using Colibri.Models.Commands.Portfolio;
using Colibri.Models.Services;

namespace Colibri.Infrastructure;

public interface IProductService
{
    Task<Product> Create(CreatePortfolioCommand command, CancellationToken token);
    Task<Product> Get(GetPortfolioCommand command, CancellationToken token);
    Task<IEnumerable<Product>> GetAll(GetAllPortfolioCommand command, CancellationToken token);
    Task<Product> Update(UpdatePortfolioCommand command, CancellationToken token);
    Task Delete(DeletePortfolioCommand command, CancellationToken token);
}