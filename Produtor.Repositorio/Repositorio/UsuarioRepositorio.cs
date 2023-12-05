using MassTransit;
using Microsoft.Extensions.Configuration;
using Produtor.Modelo;
using Produtor.Repositorio.Interfaces;

namespace Produtor.Repositorio.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;

        public UsuarioRepositorio(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        public async Task AdicionarAsync(Usuario usuario, CancellationToken cancellationToken = default)
        {
            var nomeFila = _configuration.GetSection("MassTransit")["NomeFila"] ?? string.Empty;
            var endPoint = await _bus.GetSendEndpoint(new Uri($"queue:{nomeFila}"));

            await endPoint.Send(usuario);
        }
    }
}
