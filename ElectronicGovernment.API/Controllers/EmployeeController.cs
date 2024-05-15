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
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly ISQLRepository<Employee> _repository;
    private readonly IMapper _mapper;

    public EmployeeController(ILogger<EmployeeController> logger, ISQLRepository<Employee> repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet(Name = "All")]
    public ActionResult<IEnumerable<EmployeeInfo>> Get()
    {
        var employees = _repository.GetAll();
        return _mapper.Map<List<EmployeeInfo>>(employees);
    }

    [HttpGet("GetById")]
    public ActionResult<EmployeeInfo> Get(Guid id)
    {
        var item = _repository.GetById(id);
        if (item is null)
            return NotFound();

        return Ok(_mapper.Map<EmployeeInfo>(item));
    }

    [HttpPost("Create")]
    public ActionResult<EmployeeInfo> Post([FromBody] CommandEmployee item)
    {
        var message = Validation(item);
        if (!string.IsNullOrEmpty(message))
            return BadRequest(message);

        var _item = _mapper.Map<Employee>(item);
        var createdItem = _repository.TryCreate(_item, out message);
        if (createdItem is null)
            return BadRequest(message);

        return Ok(_mapper.Map<EmployeeInfo>(createdItem));
    }

    string Validation(CommandEmployee employeeInfo)
    {
        if (string.IsNullOrEmpty(employeeInfo.FirstName))
            return "The first name cannot be empty";

        if (string.IsNullOrEmpty(employeeInfo.Username))
            return "The Username cannot be empty";

        if (string.IsNullOrEmpty(employeeInfo.Password))
            return "The password cannot be empty";

        return string.Empty;
    }

    [HttpPut("Update")]
    public ActionResult<string> Put([FromQuery] Guid id, [FromBody] CommandEmployee item)
    {
        var message = Validation(item);
        if (!string.IsNullOrEmpty(message))
            return BadRequest(message);

        var _item = _repository.GetById(id);
        if (_item is null)
            return NotFound();

        _item.FirstName = item.FirstName;
        _item.LastName = item.LastName;
        _item.Username = item.Username;
        _item.Password = item.Password;
        var updated = _repository.TryUpdate(_item, out message);
        if (!updated)
            return BadRequest(message);

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
