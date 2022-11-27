using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;

namespace ApiRetailXYZ.Repositories
{
    public class SucursalRepository : Repository<Sucursal>, ISucursalRepository
    {
        private readonly RetailXyzContext _context;
        public SucursalRepository(RetailXyzContext context) : base(context)
        {
            _context = context;
        }
    }
}
