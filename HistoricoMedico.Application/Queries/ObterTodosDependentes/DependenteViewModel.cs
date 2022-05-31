using HistoricoMedico.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterTodosDependentes
{
    public class DependenteViewModel
    {
        public DependenteViewModel(int id, string nome, DateTime dataNascimento, ParentescoEnum parentesco)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Parentesco = parentesco;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public ParentescoEnum Parentesco { get; private set; }
    }
}
