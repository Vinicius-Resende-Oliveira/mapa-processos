using FluentValidation;
using MP.Application.Validators;

namespace MP.Application.DTOs.Request
{
    public class RemoveProcessoRequest
    {
        public Guid Id { get; set; }


        public void Validate()
        {
            RemoveProcessoRequestValidator validator = new();
            validator.ValidateAndThrow(this);
        }
    }
}
