namespace Colibri.Models.Commands.Partners;

public record UpdateVisibilityPartnerCommand(
    int Id,
    bool IsShow
    );