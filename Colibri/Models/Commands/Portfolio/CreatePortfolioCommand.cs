namespace Colibri.Models.Commands.Portfolio;

public record CreatePortfolioCommand(
    string BrandName,
    string Description,
    string Image
    );