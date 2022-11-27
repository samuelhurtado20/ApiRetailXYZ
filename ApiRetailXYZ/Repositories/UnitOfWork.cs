using ApiRetailXYZ.Data.Models;
using ApiRetailXYZ.Interfaces;

namespace ApiRetailXYZ.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RetailXyzContext _db;
        public IEncuestaRepository Encuesta { get; private set; }
        public IEncuestadoRepository Encuestado { get; private set; }
        public IPreguntaRepository Pregunta { get; private set; }
        public IRespuestaRepository Respuesta { get; private set; }
        public ISucursalRepository Sucursal { get; private set; }

        public UnitOfWork(RetailXyzContext db)
        {
            _db = db;
            Encuesta = new EncuestaRepository(_db);
            Encuestado = new EncuestadoRepository(_db);
            Pregunta = new PreguntaRepository(_db);
            Respuesta = new RespuestaRepository(_db);
            Sucursal = new SucursalRepository(_db);
        }

        public void Save() => _db.SaveChanges();

        public void Dispose() => _db.Dispose();
    }
}
