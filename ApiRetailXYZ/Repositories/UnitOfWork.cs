using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;

namespace ApiRetailXYZ.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RetailXyzContext _db;
        public IEncuestaRepository Encuesta { get; private set; }

        public UnitOfWork(RetailXyzContext db)
        {
            _db = db;
            Encuesta = new EncuestaRepository(_db);
        }

        public void Save() => _db.SaveChanges();

        public void Dispose() => _db.Dispose();
    }
}
