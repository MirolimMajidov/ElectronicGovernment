using System.Text.Json.Serialization;

namespace ElectronicGovernment.DTO;

public record DocumentTemplateInfo
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    [JsonIgnore]
    public string FileName { get; set; }

    public string FilePath => string.IsNullOrEmpty(FileName)?string.Empty: Path.Combine("Files", FileName);

    public bool Status { get; set; } = false;

    public Guid DepartmentId { get; set; }
}
