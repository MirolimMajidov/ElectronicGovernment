using AutoMapper;
using ElectronicGovernment.API.Models;
using ElectronicGovernment.API.Repositories;
using ElectronicGovernment.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicGovernment.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(policy: "AdminOnly")]
public class DocumentTemplateController : ControllerBase
{
    private readonly ILogger<DocumentTemplateController> _logger;
    private readonly ISQLRepository<DocumentTemplate> _repository;
    private readonly IMapper _mapper;

    public DocumentTemplateController(ILogger<DocumentTemplateController> logger, ISQLRepository<DocumentTemplate> repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("AllTemplates")]
    public ActionResult<IEnumerable<DocumentTemplateInfo>> GetAllTemplates(Guid departmentId)
    {
        var employees = _repository.GetAll().Where(t => t.DepartmentId == departmentId);
        return Ok(_mapper.Map<List<DocumentTemplateInfo>>(employees));
    }

    [HttpGet("AllTemplatesForApply")]
    public ActionResult<IEnumerable<DocumentTemplateInfo>> GetAllTemplatesForApply(Guid departmentId)
    {
        var employees = _repository.GetAll().Where(t => t.DepartmentId == departmentId && t.Status);
        return Ok(_mapper.Map<List<DocumentTemplateInfo>>(employees));
    }

    [HttpGet("GetById")]
    public ActionResult<EmployeeInfo> Get(Guid id)
    {
        var item = _repository.GetById(id);
        if (item is null)
            return NotFound();

        return Ok(_mapper.Map<DocumentTemplateInfo>(item));
    }

    [HttpPost("Create")]
    public ActionResult<EmployeeInfo> Post(CreateDocumentTemplate item)
    {
        var message = Validation(item);
        if (!string.IsNullOrEmpty(message))
            return BadRequest(message);

        var _item = _mapper.Map<DocumentTemplate>(item);
        var createdItem = _repository.TryCreate(_item, out message);
        if (createdItem is null)
            return BadRequest(message);

        return Ok(_mapper.Map<EmployeeInfo>(null));
    }

    string Validation(UpdateDocumentTemplate item)
    {
        if (string.IsNullOrEmpty(item.Name))
            return "The name cannot be empty";

        return string.Empty;
    }

    [HttpPut("Update")]
    public ActionResult<string> Put([FromQuery] Guid id, [FromBody] UpdateDocumentTemplate item)
    {
        var message = Validation(item);
        if (!string.IsNullOrEmpty(message))
            return BadRequest(message);

        var _item = _repository.GetById(id);
        if (_item is null)
            return NotFound();

        _item.Name = item.Name;
        _item.Description = item.Description;
        var updated = _repository.TryUpdate(_item, out message);
        if (!updated)
            return BadRequest(message);

        return Ok("Successfully updated");
    }

    [HttpPut("UploadTemplateFile")]
    public ActionResult<string> UpdateTemplate([FromQuery] Guid id, [FromForm(Name = "TemplateFile")] IFormFile templateFile)
    {
        var _item = _repository.GetById(id);
        if (_item is null)
            return NotFound();

        // Check if the uploaded file is valid
        if (templateFile == null || templateFile.Length == 0)
            return BadRequest("No file uploaded.");

        // Validate file extension
        var fileExtension = Path.GetExtension(templateFile.FileName);
        if (fileExtension == null || !(fileExtension.Equals(".docx", StringComparison.OrdinalIgnoreCase) || fileExtension.Equals(".doc", StringComparison.OrdinalIgnoreCase)))
        {
            return BadRequest("Invalid file format. Only .docx files are allowed.");
        }

        // Validate MIME type (optional, but adds extra security)
        if (!(templateFile.ContentType.Equals("application/vnd.openxmlformats-officedocument.wordprocessingml.document", StringComparison.OrdinalIgnoreCase) || templateFile.ContentType.Equals("application/msword", StringComparison.OrdinalIgnoreCase)))
        {
            return BadRequest("Invalid file type. Only .docx files are allowed.");
        }

        // Ensure the Files directory exists
        var filesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Files");
        if (!Directory.Exists(filesDirectory))
        {
            Directory.CreateDirectory(filesDirectory);
        }

        // Generate a unique file name
        var fileName = $"{Guid.NewGuid()}.docx";
        var filePath = Path.Combine(filesDirectory, fileName);

        // Save the file
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            templateFile.CopyTo(stream);
        }

        var oldFile = _item.FileName;
        // Update the item with the new file name
        _item.FileName = fileName;
        var updated = _repository.TryUpdate(_item, out string message);
        if (!updated)
            return BadRequest(message);

        if (!string.IsNullOrEmpty(oldFile))
        {
            var oldFilePath = Path.Combine(filesDirectory, oldFile);
            if(System.IO.File.Exists(oldFilePath))
            {
                try
                {
                    System.IO.File.Delete(oldFilePath);
                }
                catch
                {
                }
            }
        }

        return Ok("Successfully updated");
    }

    [HttpDelete("Delete")]
    public ActionResult<string> Delete([FromQuery] Guid id)
    {
        var deleted = _repository.TryDelete(id, out string message);
        if (!deleted)
            return BadRequest(message);

        return Ok("Successfully deleted");
    }
}
