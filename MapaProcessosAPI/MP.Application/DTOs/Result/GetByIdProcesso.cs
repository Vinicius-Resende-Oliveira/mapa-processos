using MP.Domain.Entities;

namespace MP.Application.DTOs.Result
{
    public class GetByIdProcesso
    {
        public Guid Id { get; set; }
        public GetByIdProcesso? ProcessoPai { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
