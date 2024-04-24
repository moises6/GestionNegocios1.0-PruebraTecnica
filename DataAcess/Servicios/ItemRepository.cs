using CadenasComerciales_PruebraTecnica.DataAcess.Interfaces;
using GestionNegocios_PruebraTecnica.Data;
using GestionNegocios_PruebraTecnica.DataAcess.Servicios;
using GestionNegocios_PruebraTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace CadenasComerciales_PruebraTecnica.DataAcess.Servicios
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly AplicationDbContext _context;

        public ItemRepository(AplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<Item>> GetItemsBySucursalAsync(int sucursalId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserAuthorizedToModifyAsync(int itemId, string userId)
        {
            throw new NotImplementedException();
        }
    }

}
