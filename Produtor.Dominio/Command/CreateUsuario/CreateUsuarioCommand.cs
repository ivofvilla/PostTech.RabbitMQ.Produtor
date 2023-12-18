using MediatR;
using Produtor.Modelo;

namespace Produtor.Dominio.Command.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public bool Fumante { get; set; }
        public DateTime DataNascimento { get; set; }

        public Usuario ToUsuario()
        {
            return new Usuario(this.Id, this.Nome, this.Idade, this.Peso, this.Altura, this.Fumante, this.DataNascimento);
        }
    }    
}
