using AutoMapper;
using Colibri.Infrastructure.DbContext;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Commands.Statistic;
using Colibri.Models.Statistics;
using Microsoft.EntityFrameworkCore;

namespace Colibri.Infrastructure.Services;

public class StatisticService : IStatisticService
{
     private readonly ColibriDbContext _dbContext;
    private readonly IMapper _mapper;

    public StatisticService(ColibriDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<Statistic> Create(CreateStatisticCommand command, CancellationToken token)
    {
        var row = new StatisticRow(
            command.Name,
            command.Description,
            command.Logo,
            command.CountFollowers,
            command.CountViews,
            command.IsShow ? 1 : 0
        );

        await _dbContext.Statistics
            .AddAsync(row, token)
            .ConfigureAwait(false);
        await _dbContext

            .SaveChangesAsync(token)
            .ConfigureAwait(false);

        return _mapper.Map<Statistic>(row);    
    }

    public async Task<Statistic> Get(GetStatisticCommand command, CancellationToken token)
    {
        var row = await _dbContext.Statistics
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The Statistic with id = {command.Id} not found");
        }
        return _mapper.Map<Statistic>(row);        
    }

    public async Task<IEnumerable<Statistic>> GetAll(GetAllStatisticCommand command, CancellationToken token)
    {
        var rows = await _dbContext.Statistics
            .AsNoTracking()
            .ToListAsync(token);
        
        var model = _mapper.Map<List<Statistic>>(rows);
        return model;        
    }

    public async Task<Statistic> Update(UpdateStatisticCommand command, CancellationToken token)
    {
        var row = await _dbContext.Statistics
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The Statistic with id = {command.Id} not found");
        }

        row.Name = command.Name;
        row.Description = command.Description;
        row.CountFollowers = command.CountFollowers;
        row.Logo = command.Logo;
        row.CountViews = command.CountViews;
        
        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);
        return _mapper.Map<Statistic>(row);           }

    public async Task Delete(DeleteStatisticCommand command, CancellationToken token)
    {
        var row = await _dbContext.Statistics
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
    
    public async Task<Statistic> UpdateVisibility(UpdateVisibilityStatisticCommand command, CancellationToken token)
    {
        var row = await _dbContext.Statistics
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);
        if (row is null)
        {
            throw new InvalidOperationException($"The Statistic with id = {command.Id} not found");
        }
        
        row.IsShow = command.IsShow ? 1:0;
        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);
        return _mapper.Map<Statistic>(row);
    }
}