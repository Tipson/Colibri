using AutoMapper;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Statistics;

namespace Colibri.Configuration.AutoMapper;

public class StatisticProfile : Profile
{
    public StatisticProfile()
    {
        CreateMap<StatisticRow, Statistic>();
    }
}