namespace Colibri.Models.Commands.TeamMember;

public record CreateTeamMemberCommand(
    string Name,
    string Position,
    string Photo,
    string Twitter,
    string Linkedin);