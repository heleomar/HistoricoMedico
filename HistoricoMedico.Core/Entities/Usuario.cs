using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string senha, string email)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            DataCadastro = DateTime.Now;

        }
        public Usuario(string nome, string senha, string email, string sexo, int celular, DateTime dataNascimento) 
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Sexo = sexo;
            Celular = celular;
            DataNascimento = dataNascimento;         
            DataAtualizacao = DateTime.Now;
        }

       
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Sexo { get; private set; }
        public int Celular { get; private set; }
        public DateTime DataNascimento { get; private set; }        
        public List<Medico> Medicos { get; private set; }
        public List<Consulta> Consultas { get; private set; }
        public List<Dependente> Dependentes { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
       


        public void Atualizar(string email, int celular, string senha)
        {
            Email = email;
            Celular = celular;
            Senha = senha;



        }

    }
   
}
