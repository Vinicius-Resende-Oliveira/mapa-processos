using MP.Domain.Entities;

namespace MP.Application.DTOs.Result
{
    public class AddProcessoResult
    {
        public Guid Id { get; set; }
        public GetProcessoResult? ProcessoPai { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
