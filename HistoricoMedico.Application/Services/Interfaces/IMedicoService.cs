using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Services.Interfaces
{
    public interface IMedicoService
    {
        List<MedicoViewModel> BuscarTodosMedicos();
        MedicoUnicoViewModel BuscarMedicoEspecifico(int id);
        int CriarNovoMedico(NovoMedicoInputModel inputModel);
        void AtualizarMedico(AtualizarMedicoInputModel InputModel);
        void DeletarMedico(int id);
    }
}






