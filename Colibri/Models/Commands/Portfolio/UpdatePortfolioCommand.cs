namespace Colibri.Models.Commands.Portfolio;

public record UpdatePortfolioCommand(    
    int Id, 
    string BrandName,
    string Description,
    string Image
    );