using Microsoft.EntityFrameworkCore;
using MP.Domain.Entities;
using MP.Domain.Interfaces.Repository;

namespace MP.Infra.Data.Repository
{
    public class ProcessoRespository : IProcessoRepository
    {
        private readonly MapaProcessosDbContext _context;

        public ProcessoRespository(MapaProcessosDbContext context)
        {
            _context = context;
        }

        public async Task<Processo> AddAsync(Processo processo)
        {
            try
            {
                var result = await _context.Processos.AddAsync(processo);

                return result.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Processo processo)
        {
            try
            {
                processo.DeleteProcesso();
                _context.Processos.Update(processo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Processo>> GetAllAsync()
        {
            return await _context.Processos
                .Where(p => p.IsActive)
                .Include(p => p.SubsProcessosNavigation.Where(sp => sp.IsActive))
                .ToListAsync();
        }

        public async Task<Processo?> GetbyId(Guid id)
        {
            return await _context.Processos
                .Where(p => p.IsActive)
                .Include(p => p.SubsProcessosNavigation.Where(sp => sp.IsActive))
                .Include(p => p.ProcessoPai)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Processo>> GetSubProcesso(Guid idProcessoPai)
        {
            return await _context.Processos
                .Where(p => p.IdProcessoPai == idProcessoPai && p.IsActive)
                .Include(p => p.SubsProcessosNavigation.Where(sp => sp.IsActive))
                .ToListAsync();
        }

        public Processo Update(Processo processo)
        {
            try
            {
                var result = _context.Processos.Update(processo);
                return result.Entity;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public void UpdateRange(List<Processo> processos)
        {
            try
            {
                _context.Processos.UpdateRange(processos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
