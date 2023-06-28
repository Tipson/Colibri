namespace Colibri.Infrastructure.DbContext.Entities;

public class ReviewRow
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CompanyName { get; set; }
    public string Description { get; set; }
    public string Position { get; set; }
    public string Logo { get; set; }
    public string Photo { get; set; }
    public int IsShow { get; set; }


    public ReviewRow(
        string name,
        string companyName,
        string description,
        string position,
        string logo,
        string photo,
        int isShow)
    {
        Name = name;
        CompanyName = companyName;
        Description = description;
        Position = position;
        Logo = logo;
        Photo = photo;
        IsShow = isShow;
    }
    
    public ReviewRow()
    {
        
    }
}