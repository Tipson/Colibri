﻿using AutoMapper;
using Colibri.Infrastructure.DbContext;
using Colibri.Infrastructure.DbContext.Entities;
using Colibri.Models.TeamMembers;

namespace Colibri.Configuration.AutoMapper;

public class TeamMemberProfile : Profile
{
    public TeamMemberProfile()
    {
        CreateMap<TeamMemberRow, TeamMember>();
    }
}