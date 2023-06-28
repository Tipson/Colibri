namespace Colibri.Infrastructure.DbContext.Entities;

public class ProductRow
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description1 { get; set; }
    public string Description2 { get; set; }
    public int Price { get; set; }
    public string Logo { get; set; }
    public int IsShow { get; set; }


    public ProductRow(
        string title,
        string description1,
        string description2,
        int price,
        string logo,
        int isShow)
    {
        Title = title;
        Description1 = description1;
        Description2 = description2;
        Price = price;
        Logo = logo;
        IsShow = isShow;
    }

    public ProductRow()
    {
        
    }
}