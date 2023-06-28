namespace Colibri.Models.Reviews;

public class Review
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CompanyName { get; set; }
    public string Description { get; set; }
    public string Position { get; set; }
    public string Logo { get; set; }
    public string Photo { get; set; }
    public int IsShow { get; set; }

}