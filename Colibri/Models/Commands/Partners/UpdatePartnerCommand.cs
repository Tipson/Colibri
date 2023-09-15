using Colibri.Models.Partners;

namespace Colibri.Models.Commands.Partners;

public record UpdatePartnerCommand(int Id,
    string Name,
    string Logo,
    ImportanceType Importance,
    string Url,
    string? Twitter, 
    string? Medium,
    string? Linkedin,
    string? Telegram,
    string? Instagram,
    string? Youtube,
    string? Facebook,
    PartnerType Type,
    
    bool IsShow = true);