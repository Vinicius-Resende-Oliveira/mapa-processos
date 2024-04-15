using MP.Domain.Interfaces;
using MP.Domain.Interfaces.Repository;
using MP.Infra.Data.Repository;

namespace MP.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly MapaProcessosDbContext _context;

        private IProcessoRepository _processoRepository;

        public UnitOfWork(MapaProcessosDbContext context)
        {
            _context = context;
        }

        public IProcessoRepository ProcessoRepository
        {
            get
            {
                if (_processoRepository == null)
                    _processoRepository = new ProcessoRespository(_context);
                return _processoRepository;
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
