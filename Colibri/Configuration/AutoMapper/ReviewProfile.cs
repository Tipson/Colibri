using AutoMapper;
using Colibri.Infrastructure.DbContext;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Reviews;
using Colibri.Models.TeamMembers;

namespace Colibri.Configuration.AutoMapper;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<ReviewRow, Review>();
    }
}