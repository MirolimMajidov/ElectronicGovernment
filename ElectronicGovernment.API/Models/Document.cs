using ElectronicGovernment.DTO;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text.Json;

namespace ElectronicGovernment.API.Models;
public class Document : BaseEntity
{
    public Guid TemplateId { get; set; }

    public DocumentTemplate Template { get; set; }

    public string Sender { get; set; }

    public string PhoneNumber { get; set; }

    public string FileName { get; set; }

    [NotMapped]
    public List<string> Attachments { get; set; } = new List<string>();

    public string AttachmentsJson
    {
        get => JsonSerializer.Serialize(Attachments);
        set => Attachments = string.IsNullOrEmpty(value) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(value);
    }

    public DocumentStatus Status { get; set; } = DocumentStatus.NotStarted;

    public DocumentInfo GetDocumentInfo()
    {
        return new DocumentFullInfo
        {
            Id = Id,
            Sender = Sender,
            PhoneNumber = PhoneNumber,
            TemplateName = Template.Name,
            Status = Status,
            Process = "5/7",//TODO
        };
    }
}
