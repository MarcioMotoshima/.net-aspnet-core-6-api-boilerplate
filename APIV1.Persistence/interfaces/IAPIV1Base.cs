namespace APIV1.Persistence
{
    public interface IAPIV1Base<T>
    {
        Task<IEnumerable<T>?> GetAll();
        Task<T?> GetById(int id);
        Task<T?> Create(T entity);
        Task<T?> Update(T entity);
        Task<bool> Delete(int id);
    }
}