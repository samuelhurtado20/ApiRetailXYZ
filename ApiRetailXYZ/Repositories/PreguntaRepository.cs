using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;

namespace ApiRetailXYZ.Repositories
{
    public class PreguntaRepository : Repository<Preguntas>, IPreguntaRepository
    {
        private readonly RetailXyzContext _context;
        public PreguntaRepository(RetailXyzContext context) : base(context)
        {
            _context = context;
        }
    }
}
