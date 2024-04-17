﻿using DefensieTrainer.Domain.Dto;
namespace DefensieTrainer.Domain.IServices;


public interface IRequirementServices
{
    public void CreateRequirement(RequirementDto requirementDto);

    public void ChangeRequirement(RequirementDto requirementDto);

    public void RemoveRequirement(int companyId);

    public void RemoveRequirement(List<int> companyIds);
}
