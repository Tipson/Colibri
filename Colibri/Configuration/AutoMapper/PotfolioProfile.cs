using AutoMapper;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Portfolios;
using Colibri.Models.TeamMembers;

namespace Colibri.Configuration.AutoMapper;

public class PortfolioProfile : Profile
{
    public PortfolioProfile()
    {
        CreateMap<PortfolioRow, Portfolio>();
    }
}