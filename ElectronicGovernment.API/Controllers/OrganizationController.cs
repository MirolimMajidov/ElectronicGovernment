using AutoMapper;
using BankManagementSystem.Infrastructure;
using ElectronicGovernment.API.Infrastructure;
using ElectronicGovernment.API.Models;
using ElectronicGovernment.API.Repositories;
using ElectronicGovernment.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicGovernment.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(policy: "AdminOnly")]
public class OrganizationController : ControllerBase
{
    private readonly ILogger<OrganizationController> _logger;
    private readonly ISQLRepository<Organization> _repository;
    private readonly IMapper _mapper;

    public OrganizationController(ILogger<OrganizationController> logger, ISQLRepository<Organization> repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<OrganizationInfo> Get()
    {
        var item = _repository.GetById(IEGContext.GlobalId);
        if (item is null)
            return NotFound();

        return Ok(_mapper.Map<OrganizationInfo>(item));
    }

    [HttpPut("Update")]
    public ActionResult<string> Put([FromBody] UpdateOrganization item)
    {
        if (string.IsNullOrEmpty(item.Name))
            return BadRequest("The name cannot be empty");

        var _item = _repository.GetById(IEGContext.GlobalId);
        if (_item is null)
            return NotFound();

        UpdateRole(item, _item);
        _item.Name = item.Name;
        _item.Description = item.Description;
        _item.CEOId = item.LeaderId;
        _item.OperatorId = item.OperatorId;
        var updated = _repository.TryUpdate(_item, out string message);
        if (!updated)
            return BadRequest(message);

        return Ok("Successfully updated");
    }

    void UpdateRole(UpdateOrganization item, Organization existingOrganization)
    {
        var context = _repository.GetContext() as EGContext;
        if (existingOrganization is not null)
        {
            var leaderRule = context.GetEntities<UserRole>().FirstOrDefault(x => x.UserId == existingOrganization.CEOId && x.RoleType == RoleType.CEO);
            if (leaderRule != null)
                context.UserRoles.Remove(leaderRule);

            var operatorRule = context.GetEntities<UserRole>().FirstOrDefault(x => x.UserId == existingOrganization.OperatorId && x.RoleType == RoleType.GlobalOperator);
            if (operatorRule != null)
                context.UserRoles.Remove(operatorRule);
        }

        if (item.LeaderId != null)
        {
            var leaderRule = new UserRole
            {
                UserId = (Guid)item.LeaderId,
                RoleType = RoleType.CEO
            };
            context.UserRoles.Add(leaderRule);
        }

        if (item.OperatorId != null)
        {
            var operatorRule = new UserRole
            {
                UserId = (Guid)item.OperatorId,
                RoleType = RoleType.GlobalOperator
            };
            context.UserRoles.Add(operatorRule);
        }
    }
}
