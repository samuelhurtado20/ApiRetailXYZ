using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;

namespace ApiRetailXYZ.Repositories
{
    public class EncuestadoRepository : Repository<Encuestado>, IEncuestadoRepository
    {
        private readonly RetailXyzContext _context;
        public EncuestadoRepository(RetailXyzContext context) : base(context)
        {
            _context = context;
        }
    }
}
