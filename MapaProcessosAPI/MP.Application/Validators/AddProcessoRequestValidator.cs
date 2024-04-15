using FluentValidation;
using MP.Application.DTOs.Request;

namespace MP.Application.Validators
{
    public class AddProcessoRequestValidator : AbstractValidator<AddProcessoRequest>
    {
        public AddProcessoRequestValidator() 
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do processo não pode ser vazio")
                .NotNull()
                .WithMessage("O nome do processo não pode ser nulo");
        }
    }
}
