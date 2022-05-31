using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.CriarConsulta
{
    public class CriarConsultaCommand : IRequest<int>
    {
        public int IdUsuario { get; set; }
        public int IdMedico { get; set; }
        public string Sintomas { get; set; }
        public DateTime DataConsulta { get; set; }

    }
}
