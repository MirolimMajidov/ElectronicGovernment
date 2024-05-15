using AutoMapper;
using ElectronicGovernment.API.Models;
using ElectronicGovernment.API.Repositories;
using ElectronicGovernment.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicGovernment.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class DocumentController : ControllerBase
{
    private readonly ILogger<DocumentController> _logger;
    private readonly ISQLRepository<Document> _repository;
    private readonly IMapper _mapper;

    public DocumentController(ILogger<DocumentController> logger, ISQLRepository<Document> repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("AllDocuments")]
    public ActionResult<IEnumerable<DocumentInfo>> GetAllDocuments(Guid departmentId, DocumentStatus? documentStatus = null)
    {
        var documents = _repository.GetAll().Include(d => d.Template).Where(t => t.Template.DepartmentId == departmentId).AsQueryable();
        if (documentStatus is not null)
            documents = documents.Where(d => d.Status == documentStatus);

        var _documents = new List<DocumentInfo>();

        foreach (var document in documents)
            _documents.Add(document.GetDocumentInfo());

        return Ok(_mapper.Map<List<DocumentInfo>>(documents));
    }

    [HttpGet("GetById")]
    public ActionResult<DocumentFullInfo> Get(Guid id)
    {
        var item = _repository.GetAll().Include(d => d.Template).FirstOrDefault(t => t.Id == id);
        if (item is null)
            return NotFound();

        var document = item.GetDocumentInfo() as DocumentFullInfo;
        document.Attachments = item.Attachments;

        return Ok((document));
    }

    [HttpPost("Create")]
    public ActionResult<DocumentInfo> Post(CreateDocument item)
    {
        var message = Validation(item);
        if (!string.IsNullOrEmpty(message))
            return BadRequest(message);

        var _item = _mapper.Map<Document>(item);
        var createdItem = _repository.TryCreate(_item, out message);
        if (createdItem is null)
            return BadRequest(message);

        return Ok(_mapper.Map<DocumentInfo>(_item));
    }

    string Validation(UpdateDocument item)
    {
        if (string.IsNullOrEmpty(item.Sender))
            return "The sender cannot be empty";

        return string.Empty;
    }

    [HttpPut("Update")]
    public ActionResult<string> Put([FromQuery] Guid id, [FromBody] UpdateDocument item)
    {
        var message = Validation(item);
        if (!string.IsNullOrEmpty(message))
            return BadRequest(message);

        var _item = _repository.GetById(id);
        if (_item is null)
            return NotFound();

        _item.Sender = item.Sender;
        _item.PhoneNumber = item.PhoneNumber;
        var updated = _repository.TryUpdate(_item, out message);
        if (!updated)
            return BadRequest(message);

        return Ok("Successfully updated");
    }

    [HttpPut("UploadDocumentFile")]
    public ActionResult<string> UpdateTemplate([FromQuery] Guid id, [FromForm(Name = "DocumentFile")] IFormFile documentFile)
    {
        var _item = _repository.GetById(id);
        if (_item is null)
            return NotFound();

        // Check if the uploaded file is valid
        if (documentFile == null || documentFile.Length == 0)
            return BadRequest("No file uploaded.");

        // Validate file extension
        var fileExtension = Path.GetExtension(documentFile.FileName);
        if (fileExtension == null || !(fileExtension.Equals(".docx", StringComparison.OrdinalIgnoreCase) || fileExtension.Equals(".doc", StringComparison.OrdinalIgnoreCase)))
        {
            return BadRequest("Invalid file format. Only .docx files are allowed.");
        }

        // Validate MIME type (optional, but adds extra security)
        if (!(documentFile.ContentType.Equals("application/vnd.openxmlformats-officedocument.wordprocessingml.document", StringComparison.OrdinalIgnoreCase) || documentFile.ContentType.Equals("application/msword", StringComparison.OrdinalIgnoreCase)))
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
            documentFile.CopyTo(stream);
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
            if (System.IO.File.Exists(oldFilePath))
            {
                try
                {
                    System.IO.File.Delete(oldFilePath);
                }
                catch
                { }
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
