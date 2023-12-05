using FluentValidation;
namespace Produtor.Dominio.Command.CreateUsuario
{
    public class CreateUsuarioValidator : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioValidator()
        {
            RuleFor(command => command.Altura)
                .NotEmpty().WithMessage("O campo Altura é obrigatório.");

            RuleFor(command => command.Peso)
                .NotEmpty().WithMessage("O campo Peso é obrigatório.");

            RuleFor(command => command.DataNascimento)
                .NotEmpty().WithMessage("O campo DataNascimento é obrigatório.");

            RuleFor(command => command.Idade)
                .NotEmpty().WithMessage("O campo Idade é obrigatório.");

            RuleFor(command => command.Fumante)
                .NotEmpty().WithMessage("O campo Fumante é obrigatório.");

            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");

            RuleFor(command => command.Idade)
                .NotEmpty().WithMessage("O campo Idade é obrigatório.");

            RuleFor(command => command.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.");
        }
    }
}
