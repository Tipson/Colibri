namespace Colibri.Models.Partners;

public class Partner
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Url { get; set; }
    public PartnerType Type { get; set; }
    public ImportanceType Important { get; set; }

    public int IsShow { get; set; }
    
    public string Twitter { get; set; }
    public string Linkedin { get; set; }
    public string Medium { get; set; }
    public string Facebook { get; set; }
    public string Telegram { get; set; }
    public string Instagram { get; set; }
    public string Youtube { get; set; }
}