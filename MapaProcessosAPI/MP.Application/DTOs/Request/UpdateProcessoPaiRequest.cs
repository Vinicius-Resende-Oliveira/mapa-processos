using FluentValidation;
using MP.Application.Validators;

namespace MP.Application.DTOs.Request
{
    public class UpdateProcessoPaiRequest
    {
        public Guid Id { get; set; }
        public Guid? IdProcessoPai { get; set; }


        public void Validate()
        {
            UpdateProcessoPaiRequestValidator validator = new();
            validator.ValidateAndThrow(this);
        }
    }
}
