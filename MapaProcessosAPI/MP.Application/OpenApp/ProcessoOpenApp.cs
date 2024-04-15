using AutoMapper;
using MP.Application.DTOs.Request;
using MP.Application.DTOs.Result;
using MP.Application.Interfaces;
using MP.Domain.Entities;
using MP.Domain.Interfaces.Services;

namespace MP.Application.OpenApp
{
    public class ProcessoOpenApp : IProcessoOpenApp
    {
        private readonly IProcessosService _processosService;
        private readonly IMapper _mapper;

        public ProcessoOpenApp(IProcessosService processosService, IMapper mapper)
        {
            _processosService = processosService;
            _mapper = mapper;
        }

        public async Task<AddProcessoResult> AddAsync(AddProcessoRequest request)
        {
            request.Validate();

            var result = await _processosService.AddAsync(_mapper.Map<Processo>(request));

            return _mapper.Map<AddProcessoResult>(result);
        }

        public async Task<List<GetProcessoResult>> GetAllAsync()
        {
            var result = await _processosService.GetAllAsync();

            return _mapper.Map<List<GetProcessoResult>>(result);
        }

        public async Task<GetByIdProcesso> GetByIdAsync(GetByIdProcessoRequest request)
        {
            request.Validate();

            var result = await _processosService.GetbyId(request.Id);

            return _mapper.Map<GetByIdProcesso>(result);
        }

        public async Task<List<GetProcessoResult>> GetSubProcessosAsync(GetByIdProcessoRequest request)
        {
            request.Validate();

            var result = await _processosService.GetSubProcesso(request.Id);

            return _mapper.Map<List<GetProcessoResult>>(result);
        }

        public async Task RemoveAsync(RemoveProcessoRequest request)
        {
            request.Validate();

            await _processosService.Delete(request.Id);
        }

        public async Task<UpdateProcessoResult> UpdateAsync(UpdateProcessoRequest request)
        {
            request.Validate();

            var result = await _processosService.Update(_mapper.Map<Processo>(request));

            return _mapper.Map<UpdateProcessoResult>(result);
        }

        public async Task<UpdateProcessoResult> UpdateProcessoPaiAsync(UpdateProcessoPaiRequest request)
        {
            request.Validate();

            var result = await _processosService.UpdateProcessoPai(request.Id, request.IdProcessoPai);

            return _mapper.Map<UpdateProcessoResult>(result);
        }
    }
}
