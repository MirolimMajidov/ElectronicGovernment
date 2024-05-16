namespace ElectronicGovernment.Mobile.Models;

public class Document
{
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<DocumentHistory>  Histories { get; set; }
}