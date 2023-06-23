using AutoMapper;
using Colibri.Infrastructure.DbContext;
using Colibri.Infrastructure.Entities;
using Colibri.Models.Commands.Portfolio;
using Colibri.Models.Portfolios;
using Microsoft.EntityFrameworkCore;

namespace Colibri.Infrastructure.Services;

public class PortfolioService : IPortfolioService
{
    private readonly ColibriDbContext _dbContext;
    private readonly IMapper _mapper;

    public PortfolioService(ColibriDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<Portfolio> Create(CreatePortfolioCommand command, CancellationToken token)
    {
        var row = new PortfolioRow(
            command.BrandName,
            command.Description,
            command.Image
        );

        await _dbContext.Portfolios
            .AddAsync(row, token)
            .ConfigureAwait(false);
        await _dbContext

            .SaveChangesAsync(token)
            .ConfigureAwait(false);

        return _mapper.Map<Portfolio>(row);    
    }

    public async Task<Portfolio> Get(GetPortfolioCommand command, CancellationToken token)
    {
        var row = await _dbContext.Portfolios
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The Portfolio with id = {command.Id} not found");
        }
        return _mapper.Map<Portfolio>(row);        
    }

    public async Task<IEnumerable<Portfolio>> GetAll(GetAllPortfolioCommand command, CancellationToken token)
    {
        var rows = await _dbContext.Portfolios
            .AsNoTracking()
            .ToListAsync(token);
        
        var model = _mapper.Map<List<Portfolio>>(rows);
        return model;        
    }

    public async Task<Portfolio> Update(UpdatePortfolioCommand command, CancellationToken token)
    {
        var row = await _dbContext.Portfolios
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The TeamMember with id = {command.Id} not found");
        }

        row.BrandName = command.BrandName;
        row.Description = command.Description;
        row.Image = command.Image;

        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);
        return _mapper.Map<Portfolio>(row);           }

    public async Task Delete(DeletePortfolioCommand command, CancellationToken token)
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