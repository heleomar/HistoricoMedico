using HistoricoMedico.Application.InputModels;
using HistoricoMedico.Application.Services.Interfaces;
using HistoricoMedico.Application.ViewsModels;
using HistoricoMedico.Core.Entities;
using HistoricoMedico.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Application.Services.Implementations
{
    public class DadosClinicoService : IDadosClinicoService
    {

        private readonly HistoricoMedicoDbContext _dbContext;
        public DadosClinicoService(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
              

        public void AtualizarDadosClinico(DadosClinicosInputModel inputModel)
        {
            var dadosClinico = _dbContext.DadosClinicos.SingleOrDefault(d => d.Id == inputModel.Id);

            dadosClinico.AtualizarDadosClinico(inputModel.TipoSanguineo, inputModel.Altura, inputModel.Peso, inputModel.Doenca, inputModel.Alergia, inputModel.Medicacao);

            _dbContext.SaveChanges();
        }

        public DadosClinicoViewModel BuscarDadosClinico(int id)
        {
            var dadosClinico = _dbContext.DadosClinicos
                .Include(d => d.Usuario)
                .SingleOrDefault(d => d.Id == id);

            if (dadosClinico == null) return null; //só para evitar excessão Camada API - Parte 2 / 05:15

            var DadosClinicoViewModel = new DadosClinicoViewModel(
                dadosClinico.TipoSanguineo,
                dadosClinico.Altura,
                dadosClinico.Peso,
                dadosClinico.Doenca,
                dadosClinico.Alergia,
                dadosClinico.Medicacao
                );
            return DadosClinicoViewModel;
        }

        public int CadastrarDadosClinico(DadosClinicosInputModel inputModel)
        {
            var dadosClinico = new DadosClinico(inputModel.IdUsuario, inputModel.TipoSanguineo, inputModel.Altura, inputModel.Peso, inputModel.Doenca, inputModel.Alergia, inputModel.Medicacao);

            _dbContext.DadosClinicos.Add(dadosClinico);
            _dbContext.SaveChanges();

            return dadosClinico.Id;
        }
    }
}
