using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;

namespace ApiRetailXYZ.Repositories
{
    public class EncuestaRepository : Repository<Encuesta>, IEncuestaRepository
    {
        private readonly RetailXyzContext _context;
        public EncuestaRepository(RetailXyzContext context) : base(context)
        {
            _context = context;
        }
    }
}
