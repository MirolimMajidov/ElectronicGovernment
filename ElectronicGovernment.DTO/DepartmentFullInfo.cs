﻿namespace ElectronicGovernment.DTO;

public class DepartmentFullInfo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? LeaderId { get; set; }
    public Guid? OperatorId { get; set; }
}
