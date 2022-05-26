using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Core.Entities
{
    public class Endereco : BaseEntity
    {
        public Endereco()
        {
        }

        public Endereco(string logradouro, int numero, string bairro, string complemento, string cidade, string estado, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }

        public string Logradouro { get;  set; }        
        public int Numero { get;  set; }
        public string Bairro { get;  set; }
        public string Complemento { get;  set; }
        public string Cidade { get;  set; }
        public string Estado { get;  set; }
        public string Cep { get;  set; }
    }

}
