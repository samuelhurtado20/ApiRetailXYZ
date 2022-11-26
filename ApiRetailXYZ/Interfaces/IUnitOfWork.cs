namespace ApiRetailXYZ.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEncuestaRepository Encuesta { get; }
        void Save();
    }
}
