using AutoMapper;
using BankManagementSystem.Infrastructure;
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

    [HttpGet("All")]
    public ActionResult<IEnumerable<DepartmentInfo>> GetAll()
    {
        var departments = _repository.GetAll().Where(r => r.IsOnlyForWorkFlow == false);

        return Ok(_mapper.Map<List<DepartmentInfo>>(departments));
    }

    [HttpGet("WorkFlowDepartments")]
    public ActionResult<IEnumerable<DepartmentInfo>> WorkFlowDepartments()
    {
        var departments = _repository.GetAll();

        return Ok(_mapper.Map<List<DepartmentInfo>>(departments));
    }

    [HttpGet("GetById")]
    public ActionResult<DepartmentFullInfo> Get(Guid id)
    {
        var item = _repository.GetById(id);
        if (item is null || item.IsOnlyForWorkFlow)
            return NotFound();

        return Ok(_mapper.Map<DepartmentInfo>(item));
    }

    [HttpPost("Create")]
    [Authorize(policy: "AdminOnly")]
    public ActionResult<DepartmentInfo> Post([FromBody] CommandDepartment item)
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
    public ActionResult<string> Put([FromQuery] Guid id, [FromBody] CommandDepartment item)
    {
        if (string.IsNullOrEmpty(item.Name))
        {
            return BadRequest("The name cannot be empty");
        }
        else
        {
            var _item = _repository.GetById(id);
            if (_item is null || _item.IsOnlyForWorkFlow)
                return NotFound();

            UpdateRole(item, _item);
            _item.Name = item.Name;
            _item.Description = item.Description;
            _item.LeaderId = item.LeaderId;
            _item.OperatorId = item.OperatorId;
            var updated = _repository.TryUpdate(_item, out string message);
            if (!updated)
                return BadRequest(message);

            return Ok("Successfully updated");
        }
    }

    void UpdateRole(CommandDepartment item, Department existingDepartment)
    {
        var context = _repository.GetContext() as EGContext;
        if (existingDepartment is not null)
        {
            var leaderRule = context.GetEntities<UserRole>().FirstOrDefault(x => x.UserId == existingDepartment.LeaderId && x.RoleType == RoleType.Lead);
            if (leaderRule != null)
                context.UserRoles.Remove(leaderRule);

            var operatorRule = context.GetEntities<UserRole>().FirstOrDefault(x => x.UserId == existingDepartment.OperatorId && x.RoleType == RoleType.Operator);
            if (operatorRule != null)
                context.UserRoles.Remove(operatorRule);
        }

        if (item.LeaderId != null)
        {
            var leaderRule = new UserRole
            {
                UserId = (Guid)item.LeaderId,
                RoleType = RoleType.Lead
            };
            context.UserRoles.Add(leaderRule);
        }

        if (item.OperatorId != null)
        {
            var operatorRule = new UserRole
            {
                UserId = (Guid)item.OperatorId,
                RoleType = RoleType.Operator
            };
            context.UserRoles.Add(operatorRule);
        }
    }

    [HttpDelete("Delete")]
    [Authorize(policy: "AdminOnly")]
    public ActionResult<string> Delete([FromQuery] Guid id)
    {
        var item = _repository.GetById(id);
        if (item is null || item.IsOnlyForWorkFlow)
            return NotFound();

        var deleted = _repository.TryDelete(id, out string message);
        if (!deleted)
            return BadRequest(message);

        return Ok("Successfully deleted");
    }
}
