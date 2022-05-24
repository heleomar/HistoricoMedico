using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Services.Interfaces
{
    public interface IConsultaService
    {
        List<ConsultaViewModel> BuscarTodasConsultas();
        ConsultaUnicaViewModel BuscarConsultaEspecifica(int id);
        int CriarNovaConsulta(NovaConsultaInputModel inputModel);
        void AtulizarConsulta(AtualizarConsultaInputModel InputModel);
        void DeletarConsulta(int id);

    }
}
