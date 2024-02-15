using APIV1.Domain;

namespace APIV1.Persistence
{
    public interface IPersistenceGroup : IAPIV1Base<Group>
    {
        Task<Group?> GetByName(string name);
    }
}