using FluentValidation;
using MediatR;
using Produtor.Modelo;
using Produtor.Repositorio.Interfaces;
using System.Reflection;
namespace Produtor.Dominio.Command.CreateUsuario
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, bool>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IValidator<CreateUsuarioCommand> _validator;

        public CreateUsuarioHandler(IUsuarioRepositorio usuarioRepositorio, IValidator<CreateUsuarioCommand> validator)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _validator = validator;
        }

        public async Task<bool> Handle(CreateUsuarioCommand command, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
            {
                return false;
            }

            await _usuarioRepositorio.AdicionarAsync(command.ToUsuario(), cancellationToken);

            return true;
        }
    }
}
