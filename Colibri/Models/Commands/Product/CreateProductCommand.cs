namespace Colibri.Models.Commands.Product;

public record CreateProductCommand(
    string Title,
    string Description1,
    string Description2,
    int Price,
    string Logo,
    bool IsShow);