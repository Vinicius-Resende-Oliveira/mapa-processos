using MP.Domain.Entities;

namespace MP.Domain.Interfaces.Repository
{
    public interface IProcessoRepository
    {
        Task<Processo> AddAsync(Processo processo);
        Processo Update(Processo processo);
        void UpdateRange(List<Processo> processos);
        void Delete(Processo processo);
        Task<List<Processo>> GetAllAsync();
        Task<Processo> GetbyId(Guid id);
        Task<List<Processo>> GetSubProcesso(Guid id);
    }
}
