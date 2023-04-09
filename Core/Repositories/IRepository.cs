namespace Core.Repositories;

public interface IRepository<T1>
{
    public Task<IEnumerable<T1>> GetAll();
    public Task<T1> Get(long id);
    public Task Remove(long id);
    public Task Add(T1 item);
    public Task Update(T1 item);
}