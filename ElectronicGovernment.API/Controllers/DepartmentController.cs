using AutoMapper;
using ElectronicGovernment.API.Models;
using ElectronicGovernment.API.Repositories;
using ElectronicGovernment.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicGovernment.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class DepartmentController : ControllerBase
{
    private readonly ILogger<DepartmentController> _logger;
    private readonly ISQLRepository<Department> _repository;
    private readonly IMapper _mapper;

    public DepartmentController(ILogger<DepartmentController> logger, ISQLRepository<Department> repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet(Name = "All")]
    public ActionResult<IEnumerable<DepartmentInfo>> Get()
    {
        var departments = _repository.GetAll();

        return _mapper.Map<List<DepartmentInfo>>(departments);
    }

    [HttpGet("GetById")]
    public virtual async Task<ActionResult<DepartmentInfo>> Get(Guid id)
    {
        var item = await _repository.GetById(id);
        if (item is null)
            return NotFound();

        return Ok(_mapper.Map<DepartmentInfo>(item));
    }

    [HttpPost("Create")]
    [Authorize(policy: "AdminOnly")]
    public virtual ActionResult<DepartmentInfo> Post([FromBody] CommandDepartment item)
    {
        if (string.IsNullOrEmpty(item.Name))
        {
            return BadRequest("The name cannot be empty");
        }
        else
        {
            var _item = _mapper.Map<Department>(item);
            var createdItem = _repository.TryCreate(_item, out string message);
            if (createdItem is null)
                return BadRequest(message);

            return Ok(_mapper.Map<DepartmentInfo>(createdItem));
        }
    }

    [HttpPut("Update")]
    [Authorize(policy: "AdminOnly")]
    public virtual ActionResult<string> Put([FromQuery] Guid id, [FromBody] CommandDepartment item)
    {
        if (string.IsNullOrEmpty(item.Name))
        {
            return BadRequest("The name cannot be empty");
        }
        else
        {
            var _item = _mapper.Map<Department>(item);
            var updated = _repository.TryUpdate(_item, out string message);
            if (!updated)
                return BadRequest(message);

            return Ok("Successfully updated");
        }
    }

    [HttpDelete("Delete")]
    [Authorize(policy: "AdminOnly")]
    public virtual ActionResult<string> Delete([FromQuery] Guid id)
    {
        var deleted = _repository.TryDelete(id, out string message);
        if (!deleted)
            return BadRequest(message);

        return Ok("Successfully deleted");
    }
}
