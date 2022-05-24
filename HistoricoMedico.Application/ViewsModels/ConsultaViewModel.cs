using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.ViewsModels
{
    public class ConsultaViewModel
    {
        public ConsultaViewModel(int id, DateTime dataConsulta)
        {
            Id = id;
            DataConsulta = dataConsulta;
        }

        public int Id { get; private set; }
        public DateTime DataConsulta { get; private set; }

    }
}

 
