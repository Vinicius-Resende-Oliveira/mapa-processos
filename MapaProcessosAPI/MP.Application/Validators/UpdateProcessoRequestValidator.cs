using FluentValidation;
using MP.Application.DTOs.Request;

namespace MP.Application.Validators
{
    public class UpdateProcessoRequestValidator : AbstractValidator<UpdateProcessoRequest>
    {
        public UpdateProcessoRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O id do processo não pode ser vazio")
                .NotNull()
                .WithMessage("O id do processo não pode ser nulo");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do processo não pode ser vazio")
                .NotNull()
                .WithMessage("O nome do processo não pode ser nulo");
        }
    }
}
