﻿using AutoMapper;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.TeamMembers;

namespace Colibri.Configuration.AutoMapper;

public class PorfolioProfile : Profile
{
    public PorfolioProfile()
    {
        CreateMap<TeamMemberRow, TeamMember>();
    }
}