using HistoricoMedico.Core.Entities;
using HistoricoMedico.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterDependente
{
    public class DependenteUnicoViewModel
    {
        public DependenteUnicoViewModel(int id, string nome, string sexo, DateTime dataNascimento, ParentescoEnum parentesco)
        {
            Id = id;
            Nome = nome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Parentesco = parentesco;
            
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sexo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public ParentescoEnum Parentesco { get; private set; }
        
    }
}
