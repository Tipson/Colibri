namespace Colibri.Models.Errors;

public class Error
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Message { get; set; }
    public string Controller { get; set; }
    public string Method { get; set; }
    public string Source { get; set; }
}