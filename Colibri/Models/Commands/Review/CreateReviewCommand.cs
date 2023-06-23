namespace Colibri.Models.Commands.Review;

public record CreateReviewCommand(string Name,
    string CompanyName,
    string Description,
    string Position,
    string Logo,
    string Photo);