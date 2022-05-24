using HistoricoMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.ViewsModels
{
    public class MedicoUnicoViewModel
    {
        public MedicoUnicoViewModel(int id, string nome, int idUsuario, string especialidade, int telefone, int celular, Endereco endereco, string usuario)
        {
            Nome = nome;
            Id = id;
            IdUsuario = idUsuario;
            Especialidade = especialidade;
            Telefone = telefone;
            Celular = celular;
            Endereco = endereco;
            Usuario = usuario;
        }


        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int IdUsuario { get; private set; }
        public string Especialidade { get; private set; }
        public int Telefone { get; private set; }
        public int Celular { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Usuario { get; private set; }
        public List<Consulta> Consultas { get; private set; }

    }
}
