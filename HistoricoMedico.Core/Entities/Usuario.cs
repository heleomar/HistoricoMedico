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
            
        }
        public Usuario(string nome, string senha, string email, string sexo, int celular, DateTime dataNascimento, Endereco endereco, DadosClinico dadosClinico) 
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Sexo = sexo;
            Celular = celular;
            DataNascimento = dataNascimento;
            Endereco = endereco;            
            DataCadastro = DateTime.Now;
            DadosClinico = dadosClinico;
        }

        //public Usuario(DadosClinico dadosClinico)
        //{
           
        //    DadosClinico = dadosClinico;
           
        //}


        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Sexo { get; private set; }
        public int Celular { get; private set; }
        public DateTime DataNascimento { get; private set; }       
        public Endereco Endereco { get; private set; }
        public DadosClinico DadosClinico { get; private set; }
        public List<Medico> Medicos { get; private set; }
        public List<Consulta> Consultas { get; private set; }
        public List<Dependente> Dependentes { get; private set; }
        public DateTime DataCadastro { get; private set; }


        public void Atualizar(string email, int celular, Endereco endereco)
        {
            Email = email;
            Celular = celular;
            Endereco = endereco;
        }

    }
   
}
