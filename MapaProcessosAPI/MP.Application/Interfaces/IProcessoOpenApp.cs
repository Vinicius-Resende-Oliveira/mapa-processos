using MP.Application.DTOs.Request;
using MP.Application.DTOs.Result;

namespace MP.Application.Interfaces
{
    public interface IProcessoOpenApp
    {
        Task<AddProcessoResult> AddAsync(AddProcessoRequest request);
        Task RemoveAsync(RemoveProcessoRequest request);
        Task<UpdateProcessoResult> UpdateAsync(UpdateProcessoRequest request);
        Task<UpdateProcessoResult> UpdateProcessoPaiAsync(UpdateProcessoPaiRequest request);
        Task<List<GetProcessoResult>> GetAllAsync();
        Task<GetByIdProcesso> GetByIdAsync(GetByIdProcessoRequest request);
        Task<List<GetProcessoResult>> GetSubProcessosAsync(GetByIdProcessoRequest request);
    }
}
