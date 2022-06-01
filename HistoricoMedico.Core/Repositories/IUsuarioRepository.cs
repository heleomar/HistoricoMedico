using HistoricoMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUmUsuario(int id);
        Task Criar(Usuario usuario);
        Task Deletar(Usuario usuario);
        Task SalvarAlteracoes();

        
    }
}
