using MP.Domain.Interfaces.Repository;

namespace MP.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IProcessoRepository ProcessoRepository { get; }
        Task Commit();
    }
}
