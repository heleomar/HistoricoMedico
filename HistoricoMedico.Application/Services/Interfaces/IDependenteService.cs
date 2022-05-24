using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Services.Interfaces
{
    public interface IDependenteService
    {
        List<DependenteViewModel> BuscarTodosDependentes();
        DependenteUnicoViewModel BuscarDependenteEspecifico(int id);
        int CriarNovoDependente(NovoDependenteInputModel inputModel);
        void AtualizarDependente(AtualizarDependenteInputModel InputModel);
        void DeletarDependente(int id);
    }
}
