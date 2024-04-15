using FluentValidation;
using MP.Application.DTOs.Request;

namespace MP.Application.Validators
{
    public class UpdateProcessoPaiRequestValidator : AbstractValidator<UpdateProcessoPaiRequest>
    {
        public UpdateProcessoPaiRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O id do processo não pode ser vazio")
                .NotNull()
                .WithMessage("O id do processo não pode ser nulo");

            RuleFor(x => x.IdProcessoPai)
                .NotEmpty()
                .WithMessage("O id do processo não pode ser vazio");
        }
    }
}
