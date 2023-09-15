using Colibri.Models.Partners;

namespace Colibri.Models.Commands.Partners;

public record CreatePartnerCommand
{
    public string Name { get; init; }
    public string Logo { get; init; }
    public ImportanceType Importance { get; init; }
    public bool IsShow { get; init; } = true;
    public PartnerType Type { get; init; }
    
    public string Url { get; init; }
    public string? Twitter { get; init; }
    public string? Medium { get; init; }
    public string? Linkedin { get; init; }
    public string? Telegram { get; init; }
    public string? Instagram  { get; init; }
    public string? Youtube { get; init; }
    public string? Facebook { get; init; }


    
}