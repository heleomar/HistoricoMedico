using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Core.Entities
{
    public class Endereco : BaseEntity
    {
        public string Logradouro { get; private set; }        
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }
    }

}
