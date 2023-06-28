using AutoMapper;
using Colibri.Infrastructure.DbContext;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Commands.TeamMember;
using Colibri.Models.TeamMembers;
using Microsoft.EntityFrameworkCore;

namespace Colibri.Infrastructure.Services;

public class TeamMemberService : ITeamMemberService
{
    private readonly ColibriDbContext _dbContext;
    private readonly IMapper _mapper;

    public TeamMemberService(ColibriDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TeamMember> Create(CreateTeamMemberCommand command, CancellationToken token)
    {
        var row = new TeamMemberRow(
            command.Name,
            command.Position,
            command.Photo,
            command.Twitter,
            command.Linkedin,
            command.IsShow ? 1 : 0
        );

        await _dbContext.TeamMembers
            .AddAsync(row, token)
            .ConfigureAwait(false);
        await _dbContext

            .SaveChangesAsync(token)
            .ConfigureAwait(false);

        return _mapper.Map<TeamMember>(row);
    }

    public async Task<TeamMember> Get(GetTeamMemberCommand command, CancellationToken token)
    {
        var row = await _dbContext.TeamMembers
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The TeamMember with id = {command.Id} not found");
        }
        return _mapper.Map<TeamMember>(row);    
    }

    public async Task<IEnumerable<TeamMember>> GetAll(GetAllTeamMemberCommand command, CancellationToken token)
    {
        var rows = await _dbContext.TeamMembers
            .AsNoTracking()
            .ToListAsync(token);
        
        var model = _mapper.Map<List<TeamMember>>(rows);
        return model;    
    }

    public async Task<TeamMember> Update(UpdateTeamMemberCommand command, CancellationToken token)
    {
        var row = await _dbContext.TeamMembers
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The TeamMember with id = {command.Id} not found");
        }

        row.Name = command.Name;
        row.Position = command.Position;
        row.Twitter = command.Twitter;
        row.Linkedin = command.Linkedin;
        row.Photo = command.Photo;
        
        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);
        return _mapper.Map<TeamMember>(row);        
    }

    public async Task Delete(DeleteTeamMemberCommand command, CancellationToken token)
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
    
    public async Task<TeamMember> UpdateVisibility(UpdateVisibilityTeamMemberCommand command, CancellationToken token)
    {
        var row = await _dbContext.TeamMembers
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);
        if (row is null)
        {
            throw new InvalidOperationException($"The TeamMember with id = {command.Id} not found");
        }
        
        row.IsShow = command.IsShow ? 1:0;
        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);
        return _mapper.Map<TeamMember>(row);
    }
}