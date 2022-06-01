using HistoricoMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Core.Repositories
{
    public interface IDependenteRepository
    {
        Task<List<Dependente>> ObterTodos();
        Task<Dependente> ObterUmDependente(int id);
        Task Criar(Dependente dependente);
        Task Deletar(Dependente dependente);
        Task SalvarAlteracoes();
    }
}
