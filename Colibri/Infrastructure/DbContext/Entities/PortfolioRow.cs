namespace Colibri.Infrastructure.Entities;

public class PortfolioRow
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    public PortfolioRow(
        string brandName,
        string description,
        string image)
    {
        BrandName = brandName;
        Description = description;
        Image = image;
    }
    
    public PortfolioRow()
    {
        
    }
}