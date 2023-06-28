namespace Colibri.Models.Commands.Review;

public record UpdateVisibilityReviewCommand(
    int Id,
    bool IsShow);