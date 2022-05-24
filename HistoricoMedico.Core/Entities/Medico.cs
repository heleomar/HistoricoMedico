using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Core.Entities
{
    public class Medico : BaseEntity
    {
        public Medico(string nome, int idUsuario, string especialidade, int celular)
        {
            
            Nome = nome;
            IdUsuario = idUsuario;
            Especialidade = especialidade;            
            Celular = celular;              
          
        }

        public Medico(string nome, int idUsuario, string especialidade, int telefone, int celular, Endereco endereco)
        {

            Nome = nome;
            IdUsuario = idUsuario;
            Especialidade = especialidade;
            Telefone = telefone;
            Celular = celular;
            Endereco = endereco;

        }

        public string Nome { get; private set; }
        public int IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        public string Especialidade { get; private set; }
        public int Telefone { get; private set; }
        public int Celular { get; private set; }
        public Endereco Endereco { get; private set; }
        public List<Consulta> Consultas { get; set; }


        public void Atualizar(string especialidade, int telefone, int celular)
        {
            Especialidade = especialidade;
            Telefone = telefone;
            Celular = celular;
            
        }

    }

    
}
