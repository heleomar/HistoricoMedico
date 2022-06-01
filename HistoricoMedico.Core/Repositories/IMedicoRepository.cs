using HistoricoMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Core.Repositories
{
    public interface IMedicoRepository
    {
        Task<List<Medico>> ObterTodos();
        Task<Medico> ObterUmMedico(int id);
        Task Criar(Medico medico);
        Task Deletar(Medico medico);
        Task SalvarAlteracoes();
    }
}
