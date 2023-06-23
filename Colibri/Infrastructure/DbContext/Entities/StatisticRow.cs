namespace Colibri.Infrastructure.Entities;

public class StatisticRow
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Logo { get; set; }
    public int CountViews { get; set; }
    public int CountFollowers { get; set; }

    public StatisticRow(
        string name,
        string description,
        string logo,
        int countFollowers,
        int countViews)
    {
        Name = name;
        Description = description;
        Logo = logo;
        CountViews = countViews;
        CountFollowers = countFollowers;
    }
}
