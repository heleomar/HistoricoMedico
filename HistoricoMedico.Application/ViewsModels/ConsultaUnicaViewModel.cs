using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.ViewsModels
{
    public class ConsultaUnicaViewModel
    {
        public ConsultaUnicaViewModel(int id, int idUsuario, int idMedico, string sintomas, string prescricaoMedica, string observacoes, string conclusoes, DateTime dataConsulta, string usuario, string medico)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdMedico = idMedico;
            Sintomas = sintomas;
            PrescricaoMedica = prescricaoMedica;
            Observacoes = observacoes;
            Conclusoes = conclusoes;
            DataConsulta = dataConsulta;
            Usuario = usuario;
            Medico = medico;
            
        }

        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdMedico { get; private set; }
        public string Sintomas { get; private set; }
        public string PrescricaoMedica { get; private set; }
        public string Observacoes { get; private set; }
        public string Conclusoes { get; private set; }
        public DateTime DataConsulta { get; set; }
        public List<string> Exames { get; private set; }
        public string Usuario { get; private set; }
        public string Medico { get; private set; }
    }
}
