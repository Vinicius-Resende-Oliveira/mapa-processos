using FluentValidation;
using MP.Application.DTOs.Request;

namespace MP.Application.Validators
{
    public class RemoveProcessoRequestValidator : AbstractValidator<RemoveProcessoRequest>
    {
        public RemoveProcessoRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O id do processo não pode ser vazio")
                .NotNull()
                .WithMessage("O id do processo não pode ser nulo");
        }
    }
}
