using HistoricoMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Core.Repositories
{
    public interface IConsultaRepository
    {
        Task<List<Consulta>> ObterTodas();
        Task<Consulta> ObterUmaConsulta(int id);
        Task Criar(Consulta consulta);
        Task Deletar(Consulta consulta);
        Task SalvarAlteracoes();
    }
}
