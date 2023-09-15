using AutoMapper;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Partners;
using Colibri.Models.Products;

namespace Colibri.Configuration.AutoMapper;

public class PartnerProfile : Profile
{
    public PartnerProfile()
    {
        CreateMap<PartnerRow, Partner>();
    }
}