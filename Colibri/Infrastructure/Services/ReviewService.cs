using AutoMapper;
using Colibri.Infrastructure.DbContext;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Commands.Review;
using Colibri.Models.Reviews;
using Microsoft.EntityFrameworkCore;

namespace Colibri.Infrastructure.Services;

public class ReviewService : IReviewService
{
    private readonly ColibriDbContext _dbContext;
    private readonly IMapper _mapper;

    public ReviewService(ColibriDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<Review> Create(CreateReviewCommand command, CancellationToken token)
    {
        var row = new ReviewRow(
            command.Name,
            command.CompanyName,
            command.Description,
            command.Position,
            command.Logo,
            command.Photo,
            command.IsShow ? 1 : 0
        );

        await _dbContext.Reviews
            .AddAsync(row, token)
            .ConfigureAwait(false);
        await _dbContext

            .SaveChangesAsync(token)
            .ConfigureAwait(false);

        return _mapper.Map<Review>(row);    
    }

    public async Task<Review> Get(GetReviewCommand command, CancellationToken token)
    {
        var row = await _dbContext.Reviews
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The Review with id = {command.Id} not found");
        }
        return _mapper.Map<Review>(row);        
    }

    public async Task<IEnumerable<Review>> GetAll(GetAllReviewCommand command, CancellationToken token)
    {
        var rows = await _dbContext.Reviews
            .AsNoTracking()
            .ToListAsync(token);
        
        var model = _mapper.Map<List<Review>>(rows);
        return model;        
    }

    public async Task<Review> Update(UpdateReviewCommand command, CancellationToken token)
    {
        var row = await _dbContext.Reviews
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The Review with id = {command.Id} not found");
        }

        row.Name = command.Name;
        row.CompanyName = command.CompanyName;
        row.Position = command.Position;
        row.Logo = command.Logo;
        row.Photo = command.Photo;
        row.Description = command.Description;
        
        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);
        return _mapper.Map<Review>(row);           }

    public async Task Delete(DeleteReviewCommand command, CancellationToken token)
    {
        var row = await _dbContext.Reviews
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

    public async Task<Review> UpdateVisibility(UpdateVisibilityReviewCommand command, CancellationToken token)
    {
        var row = await _dbContext.Reviews
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);
        if (row is null)
        {
            throw new InvalidOperationException($"The Review with id = {command.Id} not found");
        }
        
        row.IsShow = command.IsShow ? 1:0;
        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);
        return _mapper.Map<Review>(row);
    }
}