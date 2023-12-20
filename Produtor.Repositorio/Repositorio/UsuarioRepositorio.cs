using MassTransit;
using Microsoft.Extensions.Configuration;
using Produtor.Modelo;
using Produtor.Repositorio.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

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
            var servidor = _configuration.GetSection("MassTransit")["Servidor"] ?? string.Empty;
            var nomeFila = _configuration.GetSection("MassTransit")["NomeFila"] ?? string.Empty;
            var userName = _configuration.GetSection("MassTransit")["Usuario"] ?? string.Empty;
            var Password = _configuration.GetSection("MassTransit")["Senha"] ?? string.Empty;

            var f = new ConnectionFactory { 
                HostName = servidor,
                UserName = userName,
                Password = Password
            };

            using (var connection = f.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                            queue: nomeFila,
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                    var msg = JsonSerializer.Serialize(usuario);

                    var body = Encoding.UTF8.GetBytes(msg);

                    channel.BasicPublish(
                            exchange: "",
                            routingKey: nomeFila,
                            basicProperties: null,
                            body: body
                        );
                }
            }
        }
    }
}
