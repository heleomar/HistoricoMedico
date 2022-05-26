using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Services.Interfaces
{
    public interface IDadosClinicoService
    {
       void AtualizarDadosClinico(DadosClinicosInputModel inputModel);
        DadosClinicoViewModel BuscarDadosClinico(int id);
        int CadastrarDadosClinico(DadosClinicosInputModel inputModel);        
        
    }
}
