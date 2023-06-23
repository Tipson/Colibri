using AutoMapper;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.Errors;

namespace Colibri.Configuration.AutoMapper;

public class ErrorProfile : Profile
{
    public ErrorProfile()
    {
        CreateMap<ErrorRow, Error>();
    }
}