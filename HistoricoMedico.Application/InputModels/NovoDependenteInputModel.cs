using HistoricoMedico.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.InputModels
{
    public class NovoDependenteInputModel
    {
        public NovoDependenteInputModel(string nome, int idUsuario, string sexo, DateTime dataNascimento, ParentescoEnum parentesco)
        {
            Nome = nome;
            IdUsuario = idUsuario;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Parentesco = parentesco;
        }

        public string Nome { get; private set; }
        public int IdUsuario { get; private set; }
        public string Sexo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public ParentescoEnum Parentesco { get; private set; }
    }
}
