namespace Colibri.Infrastructure.DbContext.Entities;

public partial class PartnerRow
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Logo { get; set; }
    public int? Important { get; set; }
    public string? Url { get; set; }
    public int IsShow { get; set; }
    public int? Type { get; set; }

    
    public string? Twitter { get; set; }
    public string? Medium { get; set; }
    public string? Linkedin { get; set; }
    public string? Telegram { get; set; }
    public string? Instagram { get; set; }
    public string? Youtube { get; set; }
    public string? Facebook { get; set; }
    

    public PartnerRow(
        string name,
        string logo,
        int important,
        string url,
        int isShow,
        int type,
        string? twitter,
        string? medium,
        string? linkedin,
        string? telegram,
        string? instagram,
        string? youtube,
        string? facebook
    )
    {
        Name = name;
        Logo = logo;
        Important = important;
        IsShow = isShow;
        Type = type;
        Url = url;
        Twitter = twitter;
        Medium = medium;
        Linkedin = linkedin;
        Telegram = telegram;
        Instagram = instagram;
        Youtube = youtube;
        Facebook = facebook;
    }

    public PartnerRow()
    {
        
    }
}

