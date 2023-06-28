namespace Colibri.Models.Commands.TeamMember;

public record UpdateVisibilityTeamMemberCommand(
    int Id,
    bool IsShow);