namespace Dominio.Interfaces.Repositories.Base;

public interface IRepository<T> where T : class
{
    Task<IList<T>> GetAll();
    Task<T> GetById(int id);
    Task Create(T entity);
    void Update(T entity);
    void Delete(int id);
}
