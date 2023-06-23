using AutoMapper;
using Colibri.Infrastructure.DbContext;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Commands.Error;
using Colibri.Models.Errors;
using Microsoft.EntityFrameworkCore;

namespace Colibri.Infrastructure.Services;

public class ErrorService : IErrorService
{
    private readonly ColibriDbContext _dbContext;
    private readonly IMapper _mapper;

    public ErrorService(ColibriDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    

    public async Task<Error> Get(GetErrorCommand command, CancellationToken token)
    {
        var row = await _dbContext.Errors
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"$The Error with id = {command.Id} not found");
        }
        
        return _mapper.Map<Error>(row);
    }

    public async Task<Error> Create(CreateErrorCommand command, CancellationToken token)
    {
        var row = new ErrorRow(
            command.Message,
            command.Controller,
            command.Method,
            command.Source
        );
        
        await _dbContext.Errors
            .AddAsync(row, token)
            .ConfigureAwait(false);
        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);
        
        return _mapper.Map<Error>(row);    
    }
}