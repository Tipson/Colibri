namespace Colibri.Infrastructure.DbContext.Entities;

public class PortfolioRow
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int IsShow { get; set; }

    public PortfolioRow(
        string brandName,
        string description,
        int isShow,
        string image)
    {
        BrandName = brandName;
        Description = description;
        IsShow = isShow;
        Image = image;
    }
    
    public PortfolioRow()
    {
        
    }
}