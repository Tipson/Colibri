namespace Colibri.Models.Commands.Statistic;

public record UpdateStatisticCommand(
    int Id,
    string Name,
    string Description,
    string Logo,
    int CountFollowers,
    int CountViews);