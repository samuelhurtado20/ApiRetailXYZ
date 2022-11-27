using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;

namespace ApiRetailXYZ.Repositories
{
    public class RespuestaRepository : Repository<Respuestas>, IRespuestaRepository
    {
        private readonly RetailXyzContext _context;
        public RespuestaRepository(RetailXyzContext context) : base(context)
        {
            _context = context;
        }
    }
}
