using Colibri.Models.Commands.Portfolio;
using Colibri.Models.Commands.Product;
using Colibri.Models.Services;

namespace Colibri.Infrastructure;

public interface IProductService
{
    Task<Product> Create(CreateProductCommand command, CancellationToken token);
    Task<Product> Get(GetProductCommand command, CancellationToken token);
    Task<IEnumerable<Product>> GetAll(GetAllProductCommand command, CancellationToken token);
    Task<Product> Update(UpdateProductCommand command, CancellationToken token);
    Task Delete(DeleteProductCommand command, CancellationToken token);
}