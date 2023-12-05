namespace Produtor.Modelo
{
    public class Usuario
    {
        public Usuario(int id, string nome, int idade, decimal peso, decimal altura, bool fumante, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Peso = peso;
            Altura = altura;
            Fumante = fumante;
            DataNascimento = dataNascimento;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public decimal Peso { get; private set; }
        public decimal Altura { get; private set; }
        public bool Fumante { get; private set; }
        public DateTime DataNascimento { get; private set; }
    }
}
