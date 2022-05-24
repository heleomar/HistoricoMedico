using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.InputModels
{
    public class AtualizarConsultaInputModel
    {
        public AtualizarConsultaInputModel(int id, string sintomas, string prescricaoMedica, string observacoes, string conclusoes, DateTime dataConsulta)
        {
            Id = id;
            Sintomas = sintomas;
            PrescricaoMedica = prescricaoMedica;
            Observacoes = observacoes;
            Conclusoes = conclusoes;
            DataConsulta = dataConsulta;
        }

        public int Id { get; private set; }
        public string Sintomas { get; private set; }
        public string PrescricaoMedica { get; private set; }
        public string Observacoes { get; private set; }
        public string Conclusoes { get; private set; }
        public DateTime DataConsulta { get; set; }
        

    }
}
