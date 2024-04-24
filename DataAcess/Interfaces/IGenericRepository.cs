using GestionNegocios_PruebraTecnica.Models;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<CadenaComercial> GetByIdWithUserAsync(int id);
    Task<int> SaveChangesAsync();
    Task AddAsync(Item item);
}
