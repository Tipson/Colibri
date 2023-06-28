namespace Colibri.Infrastructure.DbContext.Entities;

public class StatisticRow
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Logo { get; set; }
    public int CountViews { get; set; }
    public int CountFollowers { get; set; }
    public int IsShow { get; set; }


    public StatisticRow(
        string name,
        string description,
        string logo,
        int countFollowers,
        int countViews,
        int isShow)
    {
        Name = name;
        Description = description;
        Logo = logo;
        CountViews = countViews;
        CountFollowers = countFollowers;
        IsShow = isShow;
    }
}
