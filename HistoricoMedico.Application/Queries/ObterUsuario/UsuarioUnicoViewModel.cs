using HistoricoMedico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Queries.ObterUsuario
{
    public class UsuarioUnicoViewModel
    {
        public UsuarioUnicoViewModel(string nome, string email, string sexo, int celular, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            Sexo = sexo;
            Celular = celular;
            DataNascimento = dataNascimento;
            
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Sexo { get; private set; }
        public int Celular { get; private set; }
        public DateTime DataNascimento { get; private set; }
       
        
    }
}
