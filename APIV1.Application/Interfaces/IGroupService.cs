using APIV1.Domain;
using APIV1.Domain.Dto;

namespace APIV1.Application.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>?> Get();
        Task<Group?> GetById(int id);
        Task<Group?> Create(GroupCreateDto request);
    }
}