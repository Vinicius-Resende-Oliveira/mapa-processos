using AutoMapper;
using MP.Application.DTOs.Request;
using MP.Application.DTOs.Result;
using MP.Domain.Entities;

namespace MP.Application.Mapper
{
    public class ProcessoProfile : Profile
    {
        public ProcessoProfile()
        {
            CreateMap<AddProcessoRequest, Processo>();
            CreateMap<UpdateProcessoRequest, Processo>();
            CreateMap<AddProcessoRequest, Processo>();

            CreateMap<Processo, AddProcessoResult>();
            CreateMap<Processo, GetByIdProcesso>();
            CreateMap<Processo, GetProcessoResult>();
            CreateMap<Processo, UpdateProcessoResult>();
        }
    }
}
