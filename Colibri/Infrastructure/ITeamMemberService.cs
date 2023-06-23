using Colibri.Models.Commands.TeamMember;
using Colibri.Models.TeamMembers;

namespace Colibri.Infrastructure;

public interface ITeamMemberService
{
    Task<TeamMember> Create(CreateTeamMemberCommand command, CancellationToken token);
    Task<TeamMember> Get(GetTeamMemberCommand command, CancellationToken token);
    Task<IEnumerable<TeamMember>> GetAll(GetAllTeamMemberCommand command, CancellationToken token);
    Task<TeamMember> Update(UpdateTeamMemberCommand command, CancellationToken token);
    Task Delete(DeleteTeamMemberCommand command, CancellationToken token);
}