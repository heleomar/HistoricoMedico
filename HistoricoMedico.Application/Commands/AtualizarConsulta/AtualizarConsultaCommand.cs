using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.AtualizarConsulta
{
    public class AtualizarConsultaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Sintomas { get; set; }
        public string PrescricaoMedica { get; set; }
        public string Observacoes { get; set; }
        public string Conclusoes { get; set; }
        public DateTime DataConsulta { get; set; }
    }
}
