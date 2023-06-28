namespace Colibri.Models.Commands.Product;

public record UpdateVisibilityProductCommand(
    int Id,
    bool IsShow);