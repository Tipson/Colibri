namespace Colibri.Models.Commands.Product;

public record UpdateProductCommand(
    int Id,
    string Title,
    string Description1,
    string Description2,
    int Price,
    string Logo);