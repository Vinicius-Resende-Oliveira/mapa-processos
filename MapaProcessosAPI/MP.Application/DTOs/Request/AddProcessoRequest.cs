using FluentValidation;
using MP.Application.Validators;

namespace MP.Application.DTOs.Request
{
    public class AddProcessoRequest
    {
        public Guid? IdProcessoPai { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        public void Validate()
        {
            AddProcessoRequestValidator validator = new();
            validator.ValidateAndThrow(this);
        }
    }
}
