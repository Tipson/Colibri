namespace Colibri.Models.Commands.Review;

public record CreateReviewCommand(string Name,
    string CompanyName,
    string Description,
    string Position,
    ImportanceType Importance,
    string Logo,
    string Photo,
    bool IsShow);