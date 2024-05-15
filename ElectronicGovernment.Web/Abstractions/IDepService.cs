using ElectronicGovernment.DTO;

namespace EGovernment.Web.Abstractions
{
	public interface IDepService
	{
		Task<List<DepartmentInfo>> GetAllDeps();
		Task<List<DocumentTemplateInfo>> GetAllDocs(Guid id);
	}
}
