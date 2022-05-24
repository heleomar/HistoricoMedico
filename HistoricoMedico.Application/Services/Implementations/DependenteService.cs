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
    public class DependenteService : IDependenteService
    {
        private readonly HistoricoMedicoDbContext _dbContext;

        public DependenteService(HistoricoMedicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AtualizarDependente(AtualizarDependenteInputModel InputModel)
        {
            var dependente = _dbContext.Dependentes.SingleOrDefault(d => d.Id == InputModel.Id);

            dependente.Atualizar(InputModel.Nome, InputModel.Parentesco);

            _dbContext.SaveChanges();
        }

        public DependenteUnicoViewModel BuscarDependenteEspecifico(int id)
        {
            var dependente = _dbContext.Dependentes
                .Include(d => d.Usuario)
                .SingleOrDefault(d => d.Id == id);

            if (dependente == null) return null; //só para evitar excessão Camada API - Parte 2 / 05:15

            var dependenteUnicoViewModel = new DependenteUnicoViewModel(
                dependente.Id,
                dependente.Nome,
                dependente.Sexo,
                dependente.DataNascimento,
                dependente.Parentesco            
                );

            return dependenteUnicoViewModel;
        }

        public List<DependenteViewModel> BuscarTodosDependentes()
        {
            var dependentes = _dbContext.Dependentes;
            var dependentesViewModel = dependentes
                .Select(d => new DependenteViewModel(d.Id, d.Nome, d.DataNascimento, d.Parentesco))
                .ToList();

            return dependentesViewModel;
        }

        public int CriarNovoDependente(NovoDependenteInputModel inputModel)
        {
            var dependente = new Dependente(inputModel.Nome, inputModel.IdUsuario, inputModel.Sexo, inputModel.DataNascimento, inputModel.Parentesco);
            
            _dbContext.Dependentes.Add(dependente);
            _dbContext.SaveChanges();
            
            return dependente.Id;

        }

        public void DeletarDependente(int id)
        {
            var dependente = _dbContext.Dependentes.SingleOrDefault(d => d.Id == id);

            _dbContext.Dependentes.Remove(dependente);
            _dbContext.SaveChanges();
        }
    }
}
