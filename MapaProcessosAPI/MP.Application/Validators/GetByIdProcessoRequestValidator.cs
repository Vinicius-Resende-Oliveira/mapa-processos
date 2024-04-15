using FluentValidation;
using MP.Application.DTOs.Request;

namespace MP.Application.Validators
{
    public class GetByIdProcessoRequestValidator : AbstractValidator<GetByIdProcessoRequest>
    {
        public GetByIdProcessoRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O id do processo não pode ser vazio")
                .NotNull()
                .WithMessage("O id do processo não pode ser nulo");
        }
    }
}
