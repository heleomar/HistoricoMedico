using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.InputModels
{
    public class NovaConsultaInputModel
    {
        public NovaConsultaInputModel(int idUsuario, int idMedico, string sintomas, DateTime dataConsulta)
        {
            IdUsuario = idUsuario;
            IdMedico = idMedico;
            Sintomas = sintomas;
            DataConsulta = dataConsulta;
        }

        public int IdUsuario { get; private set; }
        public int IdMedico { get; private set; }
        public string Sintomas { get; private set; }
        public DateTime DataConsulta { get; private set; }
        
    }
}
