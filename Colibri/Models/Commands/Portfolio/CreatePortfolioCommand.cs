namespace Colibri.Models.Commands.Portfolio;

public record CreatePortfolioCommand(
    string BrandName,
    string Description,
    bool IsShow,
    string Image
    );