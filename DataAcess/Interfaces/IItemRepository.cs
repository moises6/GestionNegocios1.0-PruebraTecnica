using GestionNegocios_PruebraTecnica.Models;

namespace CadenasComerciales_PruebraTecnica.DataAcess.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task<IEnumerable<Item>> GetItemsBySucursalAsync(int sucursalId);
        Task<bool> IsUserAuthorizedToModifyAsync(int itemId, string userId);
    }

}
