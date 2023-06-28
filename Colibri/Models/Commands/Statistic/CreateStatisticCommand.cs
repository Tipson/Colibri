namespace Colibri.Models.Commands.Statistic;

public record CreateStatisticCommand(
    string Name,
    string Description,
    string Logo,
    int CountFollowers,
    int CountViews,
    bool IsShow);