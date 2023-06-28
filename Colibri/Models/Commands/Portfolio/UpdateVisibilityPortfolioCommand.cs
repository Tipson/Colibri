namespace Colibri.Models.Commands.Portfolio;

public record UpdateVisibilityPortfolioCommand(
    int Id,
    bool IsShow);