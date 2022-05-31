using HistoricoMedico.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Commands.CriarMedico
{
    public class CriarMedicoCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public int Celular { get; set; }
        public int IdUsuario { get; set; }
        public Endereco Endereco { get; set; }
    }
}
