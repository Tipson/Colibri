namespace Colibri.Models.Commands.Review;

public record UpdateReviewCommand(
    string Id,
    string Name,
    string CompanyName,
    string Description,
    string Position,
    string Logo,
    string Photo);