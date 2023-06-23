namespace Colibri.Models.Commands.Review;

public record UpdateReviewCommand(
    int Id,
    string Name,
    string CompanyName,
    string Description,
    string Position,
    string Logo,
    string Photo);