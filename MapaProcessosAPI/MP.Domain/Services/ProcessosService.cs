using MP.Domain.Entities;
using MP.Domain.Interfaces;
using MP.Domain.Interfaces.Services;

namespace MP.Domain.Services
{
    public class ProcessosService : IProcessosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcessosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Processo> AddAsync(Processo processo)
        {
            processo.AddProcesso();

            if(processo.IdProcessoPai.HasValue)
            {
                var processoPai = await _unitOfWork.ProcessoRepository.GetbyId(processo.IdProcessoPai.Value);

                processo.ProcessoPai = processoPai;

                if (processoPai == null)
                {
                    processo.IdProcessoPai = null;
                }
            }

            var result = await _unitOfWork.ProcessoRepository.AddAsync(processo);

            await _unitOfWork.Commit();

            return result;
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var processo = await GetbyId(id);

                if(processo.SubsProcessosNavigation.Count > 0)
                {
                    List<Processo> subProcessos = processo.SubsProcessosNavigation.Select(sp => sp.RemoveProcessoPai()).ToList();
                    _unitOfWork.ProcessoRepository.UpdateRange(subProcessos);
                }

                _unitOfWork.ProcessoRepository.Delete(processo);

                await _unitOfWork.Commit();
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Processo>> GetAllAsync()
        {
            var processos = await _unitOfWork.ProcessoRepository.GetAllAsync();

            if (processos.Count == 0)
                throw new Exception("Não contem resultado");

            return processos.Where(p => p.ProcessoPai == null).ToList();
        }

        public async Task<Processo> GetbyId(Guid id)
        {
            var processo = await _unitOfWork.ProcessoRepository.GetbyId(id);

            if (processo == null)
                throw new Exception($"Processo não encontrado. ID = {id}");

            return processo;
        }

        public async Task<List<Processo>> GetSubProcesso(Guid id)
        {
            var processo = await GetbyId(id);

            if (processo.SubsProcessosNavigation.Count == 0)
                throw new Exception("Nao contem resultado");

            var subprocessos = await _unitOfWork.ProcessoRepository.GetAllAsync();

            return subprocessos.Where(sp => sp.Id == id).First().SubsProcessosNavigation.ToList();
        }

        public async Task<Processo> Update(Processo processo)
        {
            var processoAntes = await GetbyId(processo.Id);

            processoAntes.UpdateProcesso(processo.Nome, processo.Descricao);

            var processoAtualizado = _unitOfWork.ProcessoRepository.Update(processoAntes);

            await _unitOfWork.Commit();

            return processoAtualizado;
        }

        public async Task<Processo> UpdateProcessoPai(Guid id, Guid? idProcessoPai)
        {
            var processoAntes = await GetbyId(id);

            if (idProcessoPai.HasValue)
            {
                var processoPai = await GetbyId(idProcessoPai.Value);
                processoAntes.UpdateProcessoPai(processoPai);
            }
            else
            {
                processoAntes.RemoveProcessoPai();
            }

            var processoAtualizado = _unitOfWork.ProcessoRepository.Update(processoAntes);

            await _unitOfWork.Commit();

            return processoAtualizado;
        }
    }
}
 