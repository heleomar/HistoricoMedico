using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.ViewsModels
{
    public  class DadosClinicoViewModel
    {
        public DadosClinicoViewModel(string tipoSanguineo, float altura, float peso, string doenca, string alergia, string medicacao)
        {
            TipoSanguineo = tipoSanguineo;
            Altura = altura;
            Peso = peso;
            Doenca = doenca;
            Alergia = alergia;
            Medicacao = medicacao;
        }

        
        public string TipoSanguineo { get; private set; }
        public float Altura { get; private set; }
        public float Peso { get; private set; }
        public string Doenca { get; private set; }
        public string Alergia { get; private set; }
        public string Medicacao { get; private set; }
    }
}
