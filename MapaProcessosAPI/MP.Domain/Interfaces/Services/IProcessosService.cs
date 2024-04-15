using MP.Domain.Entities;

namespace MP.Domain.Interfaces.Services
{
    public interface IProcessosService
    {
        Task<Processo> AddAsync(Processo processo);
        Task<Processo> Update(Processo processo);
        Task<Processo> UpdateProcessoPai(Guid id, Guid? idProcessoPai);
        Task Delete(Guid id);
        Task<List<Processo>> GetAllAsync();
        Task<Processo?> GetbyId(Guid id);
        Task<List<Processo>> GetSubProcesso(Guid id);
    }
}
