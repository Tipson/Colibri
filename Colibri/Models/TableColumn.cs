namespace Synopsis.Models
{
    public class TableColumn
    {
        public string id { get; set; }
        public string caption { get; set; }
        public string sort_by { get; set; }
        public int procent { get; set; }
        public bool selected { get; set; } = false;

    }
}