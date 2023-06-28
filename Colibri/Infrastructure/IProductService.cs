using Colibri.Models.Commands.Product;
using Colibri.Models.Products;

namespace Colibri.Infrastructure;

public interface IProductService
{
    Task<Product> Create(CreateProductCommand command, CancellationToken token);
    Task<Product> Get(GetProductCommand command, CancellationToken token);
    Task<IEnumerable<Product>> GetAll(GetAllProductCommand command, CancellationToken token);
    Task<Product> Update(UpdateProductCommand command, CancellationToken token);
    Task Delete(DeleteProductCommand command, CancellationToken token);
    Task<Product> UpdateVisibility(UpdateVisibilityProductCommand command, CancellationToken token);

}