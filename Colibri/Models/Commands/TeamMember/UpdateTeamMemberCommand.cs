namespace Colibri.Models.Commands.TeamMember;

public record UpdateTeamMemberCommand(
    int Id,
    string Name,
    string Position,
    string Photo,
    string Twitter,
    string Linkedin);