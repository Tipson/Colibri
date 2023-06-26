using AutoMapper;
using Colibri.Infrastructure.DbContext;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Commands.Portfolio;
using Colibri.Models.Commands.Product;
using Colibri.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace Colibri.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly ColibriDbContext _dbContext;
    private readonly IMapper _mapper;

    public ProductService(ColibriDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<Product> Create(CreateProductCommand command, CancellationToken token)
    {
        var row = new ProductRow(
            command.Title,
            command.Description1,
            command.Description2,
            command.Price,
            command.Logo
        );

        await _dbContext.Products
            .AddAsync(row, token)
            .ConfigureAwait(false);
        await _dbContext

            .SaveChangesAsync(token)
            .ConfigureAwait(false);

        return _mapper.Map<Product>(row);    
    }

    public async Task<Product> Get(GetProductCommand command, CancellationToken token)
    {
        var row = await _dbContext.Products
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The Product with id = {command.Id} not found");
        }
        return _mapper.Map<Product>(row);        
    }

    public async Task<IEnumerable<Product>> GetAll(GetAllProductCommand command, CancellationToken token)
    {
        var rows = await _dbContext.Products
            .AsNoTracking()
            .ToListAsync(token);
        
        var model = _mapper.Map<List<Product>>(rows);
        return model;        
    }

    public async Task<Product> Update(UpdateProductCommand command, CancellationToken token)
    {
        var row = await _dbContext.Products
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The Product with id = {command.Id} not found");
        }

        row.Title = command.Title;
        row.Description1 = command.Description1;
        row.Description2 = command.Description2;
        row.Price = command.Price;
        row.Logo = command.Logo;

        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);
        return _mapper.Map<Product>(row);           }

    public async Task Delete(DeleteProductCommand command, CancellationToken token)
    {
        var row = await _dbContext.TeamMembers
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);
        if (row is null)
        {
            return;
        }

        _dbContext.Remove(row);
        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);       
    }
}