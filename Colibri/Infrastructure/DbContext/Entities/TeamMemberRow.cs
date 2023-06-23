namespace Colibri.Infrastructure.DbContext.Entities;

public class TeamMemberRow
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string Photo { get; set; }
    public string Twitter { get; set; }
    public string Linkedin { get; set; }

    public TeamMemberRow(
        string name,
        string position,
        string photo,
        string twitter,
        string linkedin)
    {
        Name = name;
        Position = position;
        Photo = photo;
        Twitter = twitter;
        Linkedin = linkedin;
    }
}