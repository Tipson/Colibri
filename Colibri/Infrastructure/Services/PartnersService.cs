using AutoMapper;
using Colibri.Infrastructure.DbContext;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Commands.Partners;
using Colibri.Models.Partners;
using Microsoft.EntityFrameworkCore;

namespace Colibri.Infrastructure.Services;

public class PartnersService : IPartnersService
{
    private readonly ColibriDbContext _dbContext;
    private readonly IMapper _mapper;

    public PartnersService(ColibriDbContext dbContext, 
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<Partner> Create(CreatePartnerCommand command, CancellationToken token)
    {
        var row = new PartnerRow(
            command.Name,
            command.Logo,
            (int)command.Importance,
            command.Url,
            command.IsShow ? 1 : 0,
            (int)command.Type,
            command.Twitter,
            command.Medium,
            command.Linkedin,
            command.Telegram,
            command.Instagram,
            command.Youtube,
            command.Facebook);

        await _dbContext.Partners
            .AddAsync(row, token)
            .ConfigureAwait(false);
        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);

        return _mapper.Map<Partner>(row);
    }

    public async Task<Partner> Get(GetPartnerCommand command, CancellationToken token)
    {
        var row = await _dbContext.Partners
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The Partners with id = {command.Id} not found");
        }
        
        var model = _mapper.Map<Partner>(row);

        return model;
    }

    public async Task<Partner> Update(UpdatePartnerCommand command, CancellationToken token)
    {
        var row = await _dbContext.Partners
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);

        if (row is null)
        {
            throw new InvalidOperationException($"The Partners with id = {command.Id} not found");
        }

        row.Name = command.Name;
        row.Logo = command.Logo;
        row.Important = (int)command.Importance;
        row.Url = command.Url;
        row.Twitter = command.Twitter;
        row.Medium = command.Medium;
        row.Facebook = command.Facebook;
        row.Linkedin = command.Linkedin;
        row.Telegram = command.Telegram;
        row.Instagram = command.Instagram;
        row.Youtube = command.Youtube;
        row.Type = (int)command.Type;
        

        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);
        return _mapper.Map<Partner>(row);
    }

    public async Task Delete(DeletePartnerCommand command, CancellationToken token)
    {
        var row = await _dbContext.Partners
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
    public async Task<PartnersGroupedCollection> GetGrouped(GetGroupedPartnerCommand command, CancellationToken token)
    {
        var rows = await _dbContext.Partners
            .Where(r => r.Id == 1 )
            .AsNoTracking()
            .OrderByDescending(r => r.Important)
            .ToListAsync(token);

        var models = _mapper.Map<List<Partner>>(rows);

        var sponsorPacksGroupByType = models.GroupBy(m => m.Type).ToList();

        return new PartnersGroupedCollection
        {
            MediaPartners = sponsorPacksGroupByType.SingleOrDefault(p => p.Key == PartnerType.MediaPartners)?.ToList(),
            Partners = sponsorPacksGroupByType.SingleOrDefault(p => p.Key == PartnerType.Partners)?.ToList(),

        };
    }

    public async Task<PartnerRow> GetAsRow(GetAsRowPartnerCommand command, CancellationToken token)
    {
        var row = await _dbContext.Partners
                .SingleOrDefaultAsync(r => r.Id == command.Id, token)
                .ConfigureAwait(false);
        if (row is null)
        {
            throw new InvalidOperationException();
        }
        return row;
    }

    public async Task<IEnumerable<Partner>> GetAll(GetAllPartnerCommand command, CancellationToken token)
    {
        var rows = await _dbContext.Partners
            .AsNoTracking()
            .OrderByDescending(r => r.Important)
            .ThenBy(r =>r.Id)
            .ToListAsync(token);

        var model = _mapper.Map<List<Partner>>(rows);
        return model;
    }

    public async Task<Partner> UpdateVisibility(UpdateVisibilityPartnerCommand command, CancellationToken token)
    {
        var row = await _dbContext.Partners
            .SingleOrDefaultAsync(r => r.Id == command.Id, token)
            .ConfigureAwait(false);
        if (row is null)
        {
            throw new InvalidOperationException($"The Partner with id = {command.Id} not found");
        }
        
        row.IsShow = command.IsShow ? 1:0;
        await _dbContext
            .SaveChangesAsync(token)
            .ConfigureAwait(false);
        return _mapper.Map<Partner>(row);
    }
}