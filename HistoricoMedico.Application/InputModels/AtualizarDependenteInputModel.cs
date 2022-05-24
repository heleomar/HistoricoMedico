using HistoricoMedico.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.InputModels
{
    public class AtualizarDependenteInputModel
    {
        public AtualizarDependenteInputModel(int id, string nome, ParentescoEnum parentesco)
        {
            Id = id;
            Nome = nome;                    
            Parentesco = parentesco;
        }
        public int Id { get; private set; }
        public string Nome { get; private set; }                    
        public ParentescoEnum Parentesco { get; private set; }
    }
}
