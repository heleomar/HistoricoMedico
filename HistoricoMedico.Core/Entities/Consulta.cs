using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Core.Entities
{
    public class Consulta : BaseEntity
    {
        public Consulta(int idUsuario, int idMedico, string sintomas, DateTime dataConsulta)
        {
            IdUsuario = idUsuario;
            IdMedico = idMedico;
            Sintomas = sintomas;            
            DataConsulta = dataConsulta;
            DataCadastro = DateTime.Now;
        }
        
        public int IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        public int IdMedico { get; private set; }
        public Medico Medico { get; private set; }
        public string Sintomas { get; private set; }
        public string PrescricaoMedica { get; private set; }
        public string Observacoes { get; private set; }        
        public string Conclusoes { get; private set; }
        public DateTime DataConsulta { get; set; }       
        public DateTime DataCadastro { get; private set; }
        


        public void Atualizar(string sintomas, string prescricaoMedica, string observacoes, string conclusoes, DateTime dataConsulta)
        {
            Sintomas = sintomas;
            PrescricaoMedica = prescricaoMedica;
            Observacoes = observacoes;
            Conclusoes = conclusoes;
            DataConsulta = dataConsulta;
        }

    }
}
