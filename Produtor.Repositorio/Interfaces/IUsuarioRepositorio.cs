using Produtor.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtor.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task AdicionarAsync(Usuario usuario, CancellationToken cancellationToken = default);
    }
}
