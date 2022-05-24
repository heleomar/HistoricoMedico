using HistoricoMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.InputModels
{
    public class AtualizarMedicoInputModel
    {
        public AtualizarMedicoInputModel(int id, string especialidade, int telefone, int celular, Endereco endereco)
        {
            Id = id;
            Especialidade = especialidade;
            Telefone = telefone;
            Celular = celular;
            Endereco = endereco;
        }

        public int Id { get; private set; }
        public string Especialidade { get; private set; }
        public int Telefone { get; private set; }
        public int Celular { get; private set; }
        public Endereco Endereco { get; private set; }
        
    }
}
