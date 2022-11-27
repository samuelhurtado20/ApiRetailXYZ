namespace ApiRetailXYZ.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEncuestaRepository Encuesta { get; }
        IEncuestadoRepository Encuestado { get; }
        IPreguntaRepository Pregunta { get; }
        IRespuestaRepository Respuesta { get; }
        ISucursalRepository Sucursal { get; }
        void Save();
    }
}
