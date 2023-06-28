namespace Colibri.Models.Commands.Statistic;

public record UpdateVisibilityStatisticCommand(
    int Id,
    bool IsShow);