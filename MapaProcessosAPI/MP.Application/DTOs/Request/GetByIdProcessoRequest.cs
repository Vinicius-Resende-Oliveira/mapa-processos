using FluentValidation;
using MP.Application.Validators;

namespace MP.Application.DTOs.Request
{
    public class GetByIdProcessoRequest
    {
        public Guid Id { get; set; }


        public void Validate()
        {
            GetByIdProcessoRequestValidator validator = new();
            validator.ValidateAndThrow(this);
        }
    }
}
