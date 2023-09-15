using Colibri.Models;
using Colibri.Models.Partners;

namespace Synopsis.Models.Partners;

public class PartnerItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Url { get; set; }
    public int TypeAlias { get; set; }
    public PartnerType Type { get; set; }
    public string TypeName { get; set; }
    public ImportanceType Important { get; set; }
    public int IsShow { get; set; }
    
    public string Twitter { get; set; }
    public string Linkedin { get; set; }
    public string Medium { get; set; }
    public string Facebook { get; set; }
}   