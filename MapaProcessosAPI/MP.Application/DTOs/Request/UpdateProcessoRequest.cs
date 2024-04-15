using FluentValidation;
using MP.Application.Validators;

namespace MP.Application.DTOs.Request
{
    public class UpdateProcessoRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public void Validate()
        {
            UpdateProcessoRequestValidator validator = new();
            validator.ValidateAndThrow(this);
        }
    }
}
