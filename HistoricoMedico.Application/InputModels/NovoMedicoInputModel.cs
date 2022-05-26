using HistoricoMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.InputModels
{
    public class NovoMedicoInputModel
    {
        public NovoMedicoInputModel(int id, int idUsuario, string nome, string especialidade,  int celular, Endereco endereco)
        {
            Id = id;
            IdUsuario = idUsuario;
            Nome = nome;
            Especialidade = especialidade;           
            Celular = celular;
            Endereco = new Endereco()
            {
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
                Cep = endereco.Cep,

            };


        }

        public int Id { get; private set; }
        public string Nome { get; private set; }        
        public string Especialidade { get; private set; }
        public int Celular { get; private set; }        
        public int IdUsuario { get; private set; }
        public Endereco Endereco { get;  set; }

    }
}
