using AutoMapper;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Services;

namespace Colibri.Configuration.AutoMapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductRow, Product>();
    }
}