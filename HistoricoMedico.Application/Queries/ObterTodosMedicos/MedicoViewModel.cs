using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterTodosMedicos
{
    public class MedicoViewModel
    {
        public MedicoViewModel(int id, string nome, string especialidade)
        {
            Id = id;
            Nome = nome;
            Especialidade = especialidade;
        }
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Especialidade { get; private set; }        
       
    }
}
