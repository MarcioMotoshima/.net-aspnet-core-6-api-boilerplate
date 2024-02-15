using APIV1.Persistence;
using APIV1.Application.Interfaces;
using APIV1.Domain;
using APIV1.Domain.Dto;

namespace APIV1.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IPersistenceGroup _groupPersistence;

        public GroupService(IPersistenceGroup groupPersistence)
        {
            _groupPersistence = groupPersistence;
        }

        public async Task<IEnumerable<Group>?> Get()
        {
            return await _groupPersistence.GetAll();
        }

        public async Task<Group?> GetById(int id)
        {
            return await _groupPersistence.GetById(id);
        }

        public async Task<Group?> Create(GroupCreateDto request)
        {
            if (request.Name == null)
            {
                return null;
            }

            if (await _groupPersistence.GetByName(request.Name) != null)
            {
                return null;
            }

            Group newGroup = new Group
            {
                Name = request.Name,
                Description = request.Description,
                Active = 1,
                Created_at = DateTimeHelper.ConvertToTimeZone(DateTime.Now, "America/Sao_Paulo")
            };

            return await _groupPersistence.Create(newGroup);
        }
    }
}